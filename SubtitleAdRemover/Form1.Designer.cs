namespace SubtitleAdRemover
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
            this.textBoxDirList = new System.Windows.Forms.TextBox();
            this.textBoxSubtitlesList = new System.Windows.Forms.TextBox();
            this.textBoxSearchWordsList = new System.Windows.Forms.TextBox();
            this.textBoxShowMatches = new System.Windows.Forms.TextBox();
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
            // 
            // textBoxDirList
            // 
            this.textBoxDirList.Location = new System.Drawing.Point(71, 77);
            this.textBoxDirList.Multiline = true;
            this.textBoxDirList.Name = "textBoxDirList";
            this.textBoxDirList.Size = new System.Drawing.Size(169, 89);
            this.textBoxDirList.TabIndex = 7;
            this.textBoxDirList.Text = "DirList";
            // 
            // textBoxSubtitlesList
            // 
            this.textBoxSubtitlesList.Location = new System.Drawing.Point(74, 172);
            this.textBoxSubtitlesList.Multiline = true;
            this.textBoxSubtitlesList.Name = "textBoxSubtitlesList";
            this.textBoxSubtitlesList.Size = new System.Drawing.Size(166, 191);
            this.textBoxSubtitlesList.TabIndex = 8;
            this.textBoxSubtitlesList.Text = "SubtitleList";
            // 
            // textBoxSearchWordsList
            // 
            this.textBoxSearchWordsList.Location = new System.Drawing.Point(344, 74);
            this.textBoxSearchWordsList.Multiline = true;
            this.textBoxSearchWordsList.Name = "textBoxSearchWordsList";
            this.textBoxSearchWordsList.Size = new System.Drawing.Size(124, 92);
            this.textBoxSearchWordsList.TabIndex = 9;
            this.textBoxSearchWordsList.Text = "SearchWordsList";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxShowMatches);
            this.Controls.Add(this.textBoxSearchWordsList);
            this.Controls.Add(this.textBoxSubtitlesList);
            this.Controls.Add(this.textBoxDirList);
            this.Controls.Add(this.buttonSaveChanges);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonBrowseForSubDir);
            this.Name = "Form1";
            this.Text = "Subtitle Ad Remover";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowseForSubDir;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonSaveChanges;
        private System.Windows.Forms.TextBox textBoxDirList;
        private System.Windows.Forms.TextBox textBoxSubtitlesList;
        private System.Windows.Forms.TextBox textBoxSearchWordsList;
        private System.Windows.Forms.TextBox textBoxShowMatches;
    }
}

