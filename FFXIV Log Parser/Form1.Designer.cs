namespace FfxivXmlLogParser
{
    partial class Form1
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
            this.logWindow = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sayEmoteCheckbox = new System.Windows.Forms.CheckBox();
            this.partyCheckbox = new System.Windows.Forms.CheckBox();
            this.tellsCheckbox = new System.Windows.Forms.CheckBox();
            this.freeCompanyCheckbox = new System.Windows.Forms.CheckBox();
            this.linkshellsCheckbox = new System.Windows.Forms.CheckBox();
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
            this.sayEmoteCheckbox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
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
            this.partyCheckbox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
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
            this.tellsCheckbox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // freeCompanyCheckbox
            // 
            this.freeCompanyCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.freeCompanyCheckbox.AutoSize = true;
            this.freeCompanyCheckbox.Checked = true;
            this.freeCompanyCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.freeCompanyCheckbox.Location = new System.Drawing.Point(315, 526);
            this.freeCompanyCheckbox.Name = "freeCompanyCheckbox";
            this.freeCompanyCheckbox.Size = new System.Drawing.Size(122, 21);
            this.freeCompanyCheckbox.TabIndex = 5;
            this.freeCompanyCheckbox.Text = "Free Company";
            this.freeCompanyCheckbox.UseVisualStyleBackColor = true;
            this.freeCompanyCheckbox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // linkshellsCheckbox
            // 
            this.linkshellsCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linkshellsCheckbox.AutoSize = true;
            this.linkshellsCheckbox.Checked = true;
            this.linkshellsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.linkshellsCheckbox.Location = new System.Drawing.Point(443, 526);
            this.linkshellsCheckbox.Name = "linkshellsCheckbox";
            this.linkshellsCheckbox.Size = new System.Drawing.Size(92, 21);
            this.linkshellsCheckbox.TabIndex = 6;
            this.linkshellsCheckbox.Text = "Linkshells";
            this.linkshellsCheckbox.UseVisualStyleBackColor = true;
            this.linkshellsCheckbox.CheckedChanged += new System.EventHandler(this.OnCheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 555);
            this.Controls.Add(this.linkshellsCheckbox);
            this.Controls.Add(this.freeCompanyCheckbox);
            this.Controls.Add(this.tellsCheckbox);
            this.Controls.Add(this.partyCheckbox);
            this.Controls.Add(this.sayEmoteCheckbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logWindow);
            this.Name = "Form1";
            this.Text = "FFXIV XML Log Parser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.OnDrop);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logWindow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox sayEmoteCheckbox;
        private System.Windows.Forms.CheckBox partyCheckbox;
        private System.Windows.Forms.CheckBox tellsCheckbox;
        private System.Windows.Forms.CheckBox freeCompanyCheckbox;
        private System.Windows.Forms.CheckBox linkshellsCheckbox;

    }
}

