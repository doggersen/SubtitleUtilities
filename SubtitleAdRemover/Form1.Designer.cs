﻿namespace SubtitleAdRemover
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
            this.buttonBrowseForSubDir = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonSaveChanges = new System.Windows.Forms.Button();
            this.textBoxShowMatches = new System.Windows.Forms.TextBox();
            this.listBoxDirectory = new System.Windows.Forms.ListBox();
            this.listBoxSubtitles = new System.Windows.Forms.ListBox();
            this.listBoxSearchWords = new System.Windows.Forms.ListBox();
            this.folderBrowserDialogSubtitleDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.listBoxMovies = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelErrorMessages = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBrowseForSubDir
            // 
            this.buttonBrowseForSubDir.Location = new System.Drawing.Point(71, 48);
            this.buttonBrowseForSubDir.Name = "buttonBrowseForSubDir";
            this.buttonBrowseForSubDir.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseForSubDir.TabIndex = 0;
            this.buttonBrowseForSubDir.Text = "Browse ...";
            this.buttonBrowseForSubDir.UseVisualStyleBackColor = true;
            this.buttonBrowseForSubDir.Click += new System.EventHandler(this.buttonBrowseForSubDir_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(344, 48);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(124, 20);
            this.textBoxSearch.TabIndex = 3;
            this.textBoxSearch.Text = "Search for ad words";
            // 
            // buttonSaveChanges
            // 
            this.buttonSaveChanges.Location = new System.Drawing.Point(418, 381);
            this.buttonSaveChanges.Name = "buttonSaveChanges";
            this.buttonSaveChanges.Size = new System.Drawing.Size(130, 33);
            this.buttonSaveChanges.TabIndex = 6;
            this.buttonSaveChanges.Text = "Remove lines and save";
            this.buttonSaveChanges.UseVisualStyleBackColor = true;
            this.buttonSaveChanges.Click += new System.EventHandler(this.buttonSaveChanges_Click);
            // 
            // textBoxShowMatches
            // 
            this.textBoxShowMatches.Location = new System.Drawing.Point(344, 172);
            this.textBoxShowMatches.Multiline = true;
            this.textBoxShowMatches.Name = "textBoxShowMatches";
            this.textBoxShowMatches.Size = new System.Drawing.Size(260, 134);
            this.textBoxShowMatches.TabIndex = 10;
            this.textBoxShowMatches.Text = "ShowMatches";
            // 
            // listBoxDirectory
            // 
            this.listBoxDirectory.FormattingEnabled = true;
            this.listBoxDirectory.Location = new System.Drawing.Point(71, 74);
            this.listBoxDirectory.Name = "listBoxDirectory";
            this.listBoxDirectory.Size = new System.Drawing.Size(169, 95);
            this.listBoxDirectory.TabIndex = 11;
            this.listBoxDirectory.SelectedIndexChanged += new System.EventHandler(this.listBoxDirectory_SelectedIndexChanged);
            this.listBoxDirectory.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBoxDirectory_KeyDown);
            // 
            // listBoxSubtitles
            // 
            this.listBoxSubtitles.FormattingEnabled = true;
            this.listBoxSubtitles.Location = new System.Drawing.Point(71, 172);
            this.listBoxSubtitles.Name = "listBoxSubtitles";
            this.listBoxSubtitles.Size = new System.Drawing.Size(169, 134);
            this.listBoxSubtitles.TabIndex = 12;
            this.listBoxSubtitles.SelectedIndexChanged += new System.EventHandler(this.listBoxSubtitles_SelectedIndexChanged);
            // 
            // listBoxSearchWords
            // 
            this.listBoxSearchWords.FormattingEnabled = true;
            this.listBoxSearchWords.Location = new System.Drawing.Point(344, 74);
            this.listBoxSearchWords.Name = "listBoxSearchWords";
            this.listBoxSearchWords.Size = new System.Drawing.Size(172, 95);
            this.listBoxSearchWords.TabIndex = 13;
            this.listBoxSearchWords.SelectedIndexChanged += new System.EventHandler(this.listBoxSearchWords_SelectedIndexChanged);
            // 
            // listBoxMovies
            // 
            this.listBoxMovies.FormattingEnabled = true;
            this.listBoxMovies.Location = new System.Drawing.Point(619, 74);
            this.listBoxMovies.Name = "listBoxMovies";
            this.listBoxMovies.Size = new System.Drawing.Size(192, 238);
            this.listBoxMovies.TabIndex = 14;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelErrorMessages});
            this.statusStrip1.Location = new System.Drawing.Point(0, 440);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(966, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelErrorMessages
            // 
            this.toolStripStatusLabelErrorMessages.Name = "toolStripStatusLabelErrorMessages";
            this.toolStripStatusLabelErrorMessages.Size = new System.Drawing.Size(0, 17);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 462);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listBoxMovies);
            this.Controls.Add(this.listBoxSearchWords);
            this.Controls.Add(this.listBoxSubtitles);
            this.Controls.Add(this.listBoxDirectory);
            this.Controls.Add(this.textBoxShowMatches);
            this.Controls.Add(this.buttonSaveChanges);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonBrowseForSubDir);
            this.Name = "Form1";
            this.Text = "Subtitle Ad Remover";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowseForSubDir;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSaveChanges;
        private System.Windows.Forms.TextBox textBoxShowMatches;
        private System.Windows.Forms.ListBox listBoxSubtitles;
        private System.Windows.Forms.ListBox listBoxSearchWords;
        public System.Windows.Forms.ListBox listBoxDirectory;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogSubtitleDirectory;
        private System.Windows.Forms.ListBox listBoxMovies;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelErrorMessages;
    }
}

