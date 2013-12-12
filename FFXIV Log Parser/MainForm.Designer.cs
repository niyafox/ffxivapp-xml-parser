namespace FfxivXmlLogParser
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.logWindow = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sayEmoteCheckbox = new System.Windows.Forms.CheckBox();
            this.partyCheckbox = new System.Windows.Forms.CheckBox();
            this.tellsCheckbox = new System.Windows.Forms.CheckBox();
            this.linkshellsCheckbox = new System.Windows.Forms.CheckBox();
            this.linkshellsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.freeCompanyEnabled = new System.Windows.Forms.ToolStripMenuItem();
            this.linkshell1Enabled = new System.Windows.Forms.ToolStripMenuItem();
            this.linkshell2Enabled = new System.Windows.Forms.ToolStripMenuItem();
            this.linkshell3Enabled = new System.Windows.Forms.ToolStripMenuItem();
            this.linkshell4Enabled = new System.Windows.Forms.ToolStripMenuItem();
            this.linkshell5Enabled = new System.Windows.Forms.ToolStripMenuItem();
            this.linkshell6Enabled = new System.Windows.Forms.ToolStripMenuItem();
            this.linkshell7Enabled = new System.Windows.Forms.ToolStripMenuItem();
            this.linkshell8Enabled = new System.Windows.Forms.ToolStripMenuItem();
            this.linkshellsTooltip = new System.Windows.Forms.ToolTip(this.components);
            this.linkshellsContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // logWindow
            // 
            this.logWindow.AcceptsReturn = true;
            this.logWindow.AllowDrop = true;
            this.logWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logWindow.Location = new System.Drawing.Point(13, 13);
            this.logWindow.Multiline = true;
            this.logWindow.Name = "logWindow";
            this.logWindow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logWindow.Size = new System.Drawing.Size(757, 507);
            this.logWindow.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 526);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Include:";
            // 
            // sayEmoteCheckbox
            // 
            this.sayEmoteCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sayEmoteCheckbox.AutoSize = true;
            this.sayEmoteCheckbox.Checked = true;
            this.sayEmoteCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sayEmoteCheckbox.Location = new System.Drawing.Point(76, 526);
            this.sayEmoteCheckbox.Name = "sayEmoteCheckbox";
            this.sayEmoteCheckbox.Size = new System.Drawing.Size(98, 21);
            this.sayEmoteCheckbox.TabIndex = 2;
            this.sayEmoteCheckbox.Text = "Say/Emote";
            this.sayEmoteCheckbox.UseVisualStyleBackColor = true;
            this.sayEmoteCheckbox.CheckedChanged += new System.EventHandler(this.groupCheckboxes_CheckStateChanged);
            // 
            // partyCheckbox
            // 
            this.partyCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.partyCheckbox.AutoSize = true;
            this.partyCheckbox.Checked = true;
            this.partyCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.partyCheckbox.Location = new System.Drawing.Point(180, 526);
            this.partyCheckbox.Name = "partyCheckbox";
            this.partyCheckbox.Size = new System.Drawing.Size(63, 21);
            this.partyCheckbox.TabIndex = 3;
            this.partyCheckbox.Text = "Party";
            this.partyCheckbox.UseVisualStyleBackColor = true;
            this.partyCheckbox.CheckedChanged += new System.EventHandler(this.groupCheckboxes_CheckStateChanged);
            // 
            // tellsCheckbox
            // 
            this.tellsCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tellsCheckbox.AutoSize = true;
            this.tellsCheckbox.Checked = true;
            this.tellsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tellsCheckbox.Location = new System.Drawing.Point(249, 526);
            this.tellsCheckbox.Name = "tellsCheckbox";
            this.tellsCheckbox.Size = new System.Drawing.Size(60, 21);
            this.tellsCheckbox.TabIndex = 4;
            this.tellsCheckbox.Text = "Tells";
            this.tellsCheckbox.UseVisualStyleBackColor = true;
            this.tellsCheckbox.CheckedChanged += new System.EventHandler(this.groupCheckboxes_CheckStateChanged);
            // 
            // linkshellsCheckbox
            // 
            this.linkshellsCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkshellsCheckbox.AutoSize = true;
            this.linkshellsCheckbox.Checked = true;
            this.linkshellsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.linkshellsCheckbox.ContextMenuStrip = this.linkshellsContextMenu;
            this.linkshellsCheckbox.Location = new System.Drawing.Point(315, 526);
            this.linkshellsCheckbox.Name = "linkshellsCheckbox";
            this.linkshellsCheckbox.Size = new System.Drawing.Size(92, 21);
            this.linkshellsCheckbox.TabIndex = 6;
            this.linkshellsCheckbox.Text = "Linkshells";
            this.linkshellsTooltip.SetToolTip(this.linkshellsCheckbox, "Right-click to enable or disable specific linkshells or the free company chat");
            this.linkshellsCheckbox.UseVisualStyleBackColor = true;
            this.linkshellsCheckbox.CheckedChanged += new System.EventHandler(this.groupCheckboxes_CheckStateChanged);
            // 
            // linkshellsContextMenu
            // 
            this.linkshellsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.freeCompanyEnabled,
            this.linkshell1Enabled,
            this.linkshell2Enabled,
            this.linkshell3Enabled,
            this.linkshell4Enabled,
            this.linkshell5Enabled,
            this.linkshell6Enabled,
            this.linkshell7Enabled,
            this.linkshell8Enabled});
            this.linkshellsContextMenu.Name = "linkshellsContextMenu";
            this.linkshellsContextMenu.Size = new System.Drawing.Size(165, 220);
            // 
            // freeCompanyEnabled
            // 
            this.freeCompanyEnabled.Checked = true;
            this.freeCompanyEnabled.CheckOnClick = true;
            this.freeCompanyEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.freeCompanyEnabled.Name = "freeCompanyEnabled";
            this.freeCompanyEnabled.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.freeCompanyEnabled.ShowShortcutKeys = false;
            this.freeCompanyEnabled.Size = new System.Drawing.Size(164, 24);
            this.freeCompanyEnabled.Text = "&Free Company";
            this.freeCompanyEnabled.CheckStateChanged += new System.EventHandler(this.linkshells_CheckStateChanged);
            // 
            // linkshell1Enabled
            // 
            this.linkshell1Enabled.Checked = true;
            this.linkshell1Enabled.CheckOnClick = true;
            this.linkshell1Enabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.linkshell1Enabled.Name = "linkshell1Enabled";
            this.linkshell1Enabled.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D1)));
            this.linkshell1Enabled.ShowShortcutKeys = false;
            this.linkshell1Enabled.Size = new System.Drawing.Size(164, 24);
            this.linkshell1Enabled.Text = "Linkshell &1";
            this.linkshell1Enabled.CheckStateChanged += new System.EventHandler(this.linkshells_CheckStateChanged);
            // 
            // linkshell2Enabled
            // 
            this.linkshell2Enabled.Checked = true;
            this.linkshell2Enabled.CheckOnClick = true;
            this.linkshell2Enabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.linkshell2Enabled.Name = "linkshell2Enabled";
            this.linkshell2Enabled.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D2)));
            this.linkshell2Enabled.ShowShortcutKeys = false;
            this.linkshell2Enabled.Size = new System.Drawing.Size(164, 24);
            this.linkshell2Enabled.Text = "Linkshell &2";
            this.linkshell2Enabled.CheckStateChanged += new System.EventHandler(this.linkshells_CheckStateChanged);
            // 
            // linkshell3Enabled
            // 
            this.linkshell3Enabled.Checked = true;
            this.linkshell3Enabled.CheckOnClick = true;
            this.linkshell3Enabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.linkshell3Enabled.Name = "linkshell3Enabled";
            this.linkshell3Enabled.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D3)));
            this.linkshell3Enabled.ShowShortcutKeys = false;
            this.linkshell3Enabled.Size = new System.Drawing.Size(164, 24);
            this.linkshell3Enabled.Text = "Linkshell &3";
            this.linkshell3Enabled.CheckStateChanged += new System.EventHandler(this.linkshells_CheckStateChanged);
            // 
            // linkshell4Enabled
            // 
            this.linkshell4Enabled.Checked = true;
            this.linkshell4Enabled.CheckOnClick = true;
            this.linkshell4Enabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.linkshell4Enabled.Name = "linkshell4Enabled";
            this.linkshell4Enabled.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D4)));
            this.linkshell4Enabled.ShowShortcutKeys = false;
            this.linkshell4Enabled.Size = new System.Drawing.Size(164, 24);
            this.linkshell4Enabled.Text = "Linkshell &4";
            this.linkshell4Enabled.CheckStateChanged += new System.EventHandler(this.linkshells_CheckStateChanged);
            // 
            // linkshell5Enabled
            // 
            this.linkshell5Enabled.Checked = true;
            this.linkshell5Enabled.CheckOnClick = true;
            this.linkshell5Enabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.linkshell5Enabled.Name = "linkshell5Enabled";
            this.linkshell5Enabled.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D5)));
            this.linkshell5Enabled.ShowShortcutKeys = false;
            this.linkshell5Enabled.Size = new System.Drawing.Size(164, 24);
            this.linkshell5Enabled.Text = "Linkshell &5";
            this.linkshell5Enabled.CheckStateChanged += new System.EventHandler(this.linkshells_CheckStateChanged);
            // 
            // linkshell6Enabled
            // 
            this.linkshell6Enabled.Checked = true;
            this.linkshell6Enabled.CheckOnClick = true;
            this.linkshell6Enabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.linkshell6Enabled.Name = "linkshell6Enabled";
            this.linkshell6Enabled.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D6)));
            this.linkshell6Enabled.ShowShortcutKeys = false;
            this.linkshell6Enabled.Size = new System.Drawing.Size(164, 24);
            this.linkshell6Enabled.Text = "Linkshell &6";
            this.linkshell6Enabled.CheckStateChanged += new System.EventHandler(this.linkshells_CheckStateChanged);
            // 
            // linkshell7Enabled
            // 
            this.linkshell7Enabled.Checked = true;
            this.linkshell7Enabled.CheckOnClick = true;
            this.linkshell7Enabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.linkshell7Enabled.Name = "linkshell7Enabled";
            this.linkshell7Enabled.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D7)));
            this.linkshell7Enabled.ShowShortcutKeys = false;
            this.linkshell7Enabled.Size = new System.Drawing.Size(164, 24);
            this.linkshell7Enabled.Text = "Linkshell &7";
            this.linkshell7Enabled.CheckStateChanged += new System.EventHandler(this.linkshells_CheckStateChanged);
            // 
            // linkshell8Enabled
            // 
            this.linkshell8Enabled.Checked = true;
            this.linkshell8Enabled.CheckOnClick = true;
            this.linkshell8Enabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.linkshell8Enabled.Name = "linkshell8Enabled";
            this.linkshell8Enabled.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D8)));
            this.linkshell8Enabled.ShowShortcutKeys = false;
            this.linkshell8Enabled.Size = new System.Drawing.Size(164, 24);
            this.linkshell8Enabled.Text = "Linkshell &8";
            this.linkshell8Enabled.CheckStateChanged += new System.EventHandler(this.linkshells_CheckStateChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 555);
            this.Controls.Add(this.linkshellsCheckbox);
            this.Controls.Add(this.tellsCheckbox);
            this.Controls.Add(this.partyCheckbox);
            this.Controls.Add(this.sayEmoteCheckbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logWindow);
            this.Name = "MainForm";
            this.Text = "FFXIV XML Log Parser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.logWindow_OnDrop);
            this.linkshellsContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logWindow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox sayEmoteCheckbox;
        private System.Windows.Forms.CheckBox partyCheckbox;
        private System.Windows.Forms.CheckBox tellsCheckbox;
        private System.Windows.Forms.CheckBox linkshellsCheckbox;
        private System.Windows.Forms.ContextMenuStrip linkshellsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem linkshell1Enabled;
        private System.Windows.Forms.ToolStripMenuItem freeCompanyEnabled;
        private System.Windows.Forms.ToolStripMenuItem linkshell2Enabled;
        private System.Windows.Forms.ToolStripMenuItem linkshell3Enabled;
        private System.Windows.Forms.ToolStripMenuItem linkshell4Enabled;
        private System.Windows.Forms.ToolStripMenuItem linkshell5Enabled;
        private System.Windows.Forms.ToolStripMenuItem linkshell6Enabled;
        private System.Windows.Forms.ToolStripMenuItem linkshell7Enabled;
        private System.Windows.Forms.ToolStripMenuItem linkshell8Enabled;
        private System.Windows.Forms.ToolTip linkshellsTooltip;

    }
}

