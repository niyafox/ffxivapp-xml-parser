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
        private HashSet<Type> _enabledTypes = new HashSet<Type>();

        // Logs that are currently open in the window
        private List<XmlLog> _logs = new List<XmlLog>();

        public MainForm()
        {
            InitializeComponent();

            // Setup background worker
            logWindowTextUpdater.DoWork += new DoWorkEventHandler(logWindowTextUpdater_DoWork);
            logWindowTextUpdater.RunWorkerCompleted += new RunWorkerCompletedEventHandler(logWindowTextUpdater_RunWorkerCompleted);

            // Setup Event handlers
            logWindow.DragEnter += new DragEventHandler(logWindow_OnDragEnter);
            logWindow.DragDrop += new DragEventHandler(logWindow_OnDrop);

            // By default all the log types are enabled
            _enabledTypes.Add(typeof(SayLogLine));
            _enabledTypes.Add(typeof(TellSentLogLine));
            _enabledTypes.Add(typeof(TellReceivedLogLine));
            _enabledTypes.Add(typeof(PartyLogLine));
            _enabledTypes.Add(typeof(EmoteLogLine));
            _enabledTypes.Add(typeof(FreeformEmoteLogLine));
            _enabledTypes.Add(typeof(LinkshellLogLine));
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
            logWindowTextUpdater.RunWorkerAsync();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
        }

        private void OnCheckedChanged(object sender, EventArgs e)
        {
            // Create lists for which are enabled/disabled for each checkbox
            Type[] sayEmoteTypes = { typeof(SayLogLine), typeof(EmoteLogLine), typeof(FreeformEmoteLogLine) };
            Type[] partyTypes = { typeof(PartyLogLine) };
            Type[] tellsTypes = { typeof(TellReceivedLogLine), typeof(TellSentLogLine) };
            Type[] linkshellTypes = { typeof(LinkshellLogLine) };

            // The list we're updating now
            Type[] enableDisableSet;

            if (sender == sayEmoteCheckbox)
            {
                enableDisableSet = sayEmoteTypes;
            }
            else if (sender == partyCheckbox)
            {
                enableDisableSet = partyTypes;
            }
            else if (sender == tellsCheckbox)
            {
                enableDisableSet = tellsTypes;
            }
            else if (sender == linkshellsCheckbox)
            {
                enableDisableSet = linkshellTypes;
            }
            else
            {
                // I don't know...
                return;
            }

            // Add or remove?
            if (_enabledTypes.Contains(enableDisableSet[0]))
            {
                // Disable logs
                foreach (Type type in enableDisableSet)
                {
                    _enabledTypes.Remove(type);
                }
            }
            else
            {
                // Enable logs
                foreach (Type type in enableDisableSet)
                {
                    _enabledTypes.Add(type);
                }
            }

            // Update the window
            logWindowTextUpdater.RunWorkerAsync();
        }

        // Our StringBuilder so we don't waste time creating/destroying it each time
        private StringBuilder sb = new StringBuilder();

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
            // Start over
            sb.Clear();

            // Go through all loaded files
            foreach (XmlLog log in _logs)
            {
                sb.AppendFormat("=== {0} ==={1}", log.Path, Environment.NewLine);
                foreach (XmlLogLine line in log.Lines)
                {
                    // Only add enabled line types
                    if (_enabledTypes.Contains(line.GetType()))
                    {
                        sb.Append(line).Append(Environment.NewLine);
                    }
                }
            }

            // Done with our work
            return sb.ToString();
        }
    }


}
