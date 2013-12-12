using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Threading;

namespace FfxivXmlLogParser
{
    public partial class MainForm : Form
    {
        // Enabled logs
        private HashSet<LogType> _enabledTypes = new HashSet<LogType>();

        // Logs that are currently open in the window
        private List<XmlLog> _logs = new List<XmlLog>();

        public MainForm()
        {
            InitializeComponent();

            // Setup Event handlers
            logWindow.DragEnter += new DragEventHandler(logWindow_OnDragEnter);
            logWindow.DragDrop += new DragEventHandler(logWindow_OnDrop);

            // Attach tag data -- parent controls
            sayEmoteCheckbox.Tag = sayEmoteTypes;
            partyCheckbox.Tag = partyTypes;
            tellsCheckbox.Tag = tellsTypes;
            linkshellsCheckbox.Tag = linkshellTypes;

            // Attach tag data -- linkshells context menu
            linkshell1Enabled.Tag = LogType.Linkshell1;
            linkshell2Enabled.Tag = LogType.Linkshell2;
            linkshell3Enabled.Tag = LogType.Linkshell3;
            linkshell4Enabled.Tag = LogType.Linkshell4;
            linkshell5Enabled.Tag = LogType.Linkshell5;
            linkshell6Enabled.Tag = LogType.Linkshell6;
            linkshell7Enabled.Tag = LogType.Linkshell7;
            linkshell8Enabled.Tag = LogType.Linkshell8;
            freeCompanyEnabled.Tag = LogType.FreeCompany;

            // By default all the log types are enabled
            foreach (LogType type in (LogType[])Enum.GetValues(typeof(LogType)))
            {
                _enabledTypes.Add(type);
            }
            // But don't enable 'unknown'
            _enabledTypes.Remove(LogType.Unknown);
        }

        void logWindow_OnDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void logWindow_OnDrop(object sender, DragEventArgs e)
        {
            // Clear the log list
            _logs.Clear();

            // Get the new list of logs to show
            string[] filenames = e.Data.GetData(DataFormats.FileDrop) as string[];
            foreach (string filename in filenames)
            {
                // Load each log file
                _logs.Add(new XmlLog(filename));
            }

            // Update the window
            createBackgroundWorker().RunWorkerAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
        }

        // Helper flag to indicate the parent/child control is updating, so the child/parent code should not
        private bool linkshellParentUpdating;
        private bool linkshellChildrenUpdating;

        // A lock is likely unnecessary, as all the updates /should/ be coming from the same (UI) thread, but I do not trust
        private Object linkshellLock = new Object();

        // Create lists for which are enabled/disabled for each checkbox
        private LogType[] sayEmoteTypes = { LogType.Say, LogType.Emote, LogType.EmoteFreeform };
        private LogType[] partyTypes = { LogType.Party };
        private LogType[] tellsTypes = { LogType.TellSent, LogType.TellReceived };
        private LogType[] linkshellTypes = { LogType.FreeCompany, LogType.Linkshell1, LogType.Linkshell2, LogType.Linkshell3, LogType.Linkshell4, LogType.Linkshell5, LogType.Linkshell6, LogType.Linkshell7, LogType.Linkshell8 };

        /// <summary>
        /// Manages the high level enable/disable checkbox changed state for things like say/emote, as well as enabling
        /// or disabling *all* linkshells, and free company chat, together
        /// </summary>
        private void groupCheckboxes_CheckStateChanged(object sender, EventArgs e)
        {
            // If the event is fired by child code updating, drop it
            if (linkshellChildrenUpdating && sender == linkshellsCheckbox)
            {
                return;
            }

            // Just for sanity
            if (sender.GetType() != typeof(CheckBox))
            {
                // ??? How?
                return;
            }

            // Get the updated state
            bool enabed = ((CheckBox)sender).Checked;

            // And the list to update (from the tags)
            Object objTag = ((CheckBox)sender).Tag;

            // The list we're updating now
            LogType[] enableDisableSet;
            try
            {
                enableDisableSet = (LogType[])objTag;
            }
            catch (InvalidCastException)
            {
                // Somehow?
                return;
            }

            // Special processing for the linkshell types (because of the child control)
            if (enableDisableSet == linkshellTypes)
            {
                // Because there's the entire list based here in the context menu, we need to update it to be accurate
                lock (linkshellLock)
                {
                    ToolStripMenuItem[] contextMenuCheckboxes = new ToolStripMenuItem[] { linkshell1Enabled, linkshell2Enabled, linkshell3Enabled, linkshell4Enabled, linkshell5Enabled, linkshell6Enabled, linkshell7Enabled, linkshell8Enabled, freeCompanyEnabled };

                    linkshellParentUpdating = true;
                    foreach (ToolStripMenuItem item in contextMenuCheckboxes)
                    {
                        item.Checked = enabed;
                    }
                    linkshellParentUpdating = false;
                }
            }

            // Add or remove?
            if (enabed)
            {
                // Enable logs
                foreach (LogType type in enableDisableSet)
                {
                    _enabledTypes.Add(type);
                }
            }
            else
            {
                // Disable logs
                foreach (LogType type in enableDisableSet)
                {
                    _enabledTypes.Remove(type);
                }
            }

            // Update the window
            createBackgroundWorker().RunWorkerAsync();
        }

        /// <summary>
        /// Manages the enabling or disabling of specific linkshells or free company chat
        /// </summary>
        private void linkshells_CheckStateChanged(object sender, EventArgs e)
        {
            // If the parent is updating, ignore the "clicks"
            if (linkshellParentUpdating)
            {
                return;
            }

            // Just verify the data first
            if (sender.GetType() != typeof(ToolStripMenuItem))
            {
                return;
            }

            // Cast it so we can use it more easily
            ToolStripMenuItem senderItem = (ToolStripMenuItem)sender;

            // Now check the tag data
            if (senderItem.Tag.GetType() != typeof(LogType))
            {
                // ???
                return;
            }

            // Get the selected type from the tag
            LogType selectedType = (LogType)senderItem.Tag;

            bool enabled = senderItem.Checked;
            if (enabled)
            {
                _enabledTypes.Add(selectedType);
            }
            else
            {
                _enabledTypes.Remove(selectedType);
            }

            // Not done yet! We need to update our outer control to show whether *all* linkshells, and the free company
            // chat are enabled, disabled, or if it's a mix
            lock (linkshellLock)
            {
                ToolStripMenuItem[] contextMenuCheckboxes = new ToolStripMenuItem[] { linkshell1Enabled, linkshell2Enabled, linkshell3Enabled, linkshell4Enabled, linkshell5Enabled, linkshell6Enabled, linkshell7Enabled, linkshell8Enabled, freeCompanyEnabled };

                // We might not have to check many items, because if any one of them doesn't match the state of this one
                // it's the indeterminate state

                // Let's be hopeful! If this one is on (or off) the rest are probably too... right?
                CheckState newCheckState = (enabled) ? CheckState.Checked : CheckState.Unchecked;
                foreach (ToolStripMenuItem item in contextMenuCheckboxes)
                {
                    if (item.Checked != enabled)
                    {
                        // Nope! It's Indeterminate!
                        newCheckState = CheckState.Indeterminate;
                        break;
                    }
                }

                // Update the parent control
                linkshellChildrenUpdating = true;
                linkshellsCheckbox.CheckState = newCheckState;
                linkshellChildrenUpdating = false;
            }

            // Update the window
            createBackgroundWorker().RunWorkerAsync();
        }

        // Our StringBuilder so we don't waste time creating/destroying it each time
        private StringBuilder workerStringBuilder = new StringBuilder();

        private BackgroundWorker createBackgroundWorker()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(logWindowTextUpdater_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(logWindowTextUpdater_RunWorkerCompleted);
            return worker;
        }

        private void logWindowTextUpdater_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event.
            BackgroundWorker worker = sender as BackgroundWorker;

            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the 
            // RunWorkerCompleted eventhandler.
            e.Result = UpdateLogs(worker, e);
        }

        private void logWindowTextUpdater_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                logWindow.Text = e.Result as string;
            }
        }

        private string UpdateLogs(BackgroundWorker worker, DoWorkEventArgs e)
        {
            // Because of the lock, we want to get the string builder's buffer before leaving the critical section
            string returnString;

            lock (workerStringBuilder)
            {
                // Start over
                workerStringBuilder.Clear();

                // Go through all loaded files
                foreach (XmlLog log in _logs)
                {
                    workerStringBuilder.AppendFormat("=== {0} ==={1}", log.Path, Environment.NewLine);
                    foreach (XmlLogLine line in log.Lines)
                    {
                        // Only add enabled line types
                        if (_enabledTypes.Contains(line.EntryType))
                        {
                            workerStringBuilder.Append(line).Append(Environment.NewLine);
                        }
                    }
                }

                // Save the buffer
                returnString = workerStringBuilder.ToString();
            }

            // Done with our work
            return returnString;
        }
    }


}
