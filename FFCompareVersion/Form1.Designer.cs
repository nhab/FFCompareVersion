namespace FFCompareVersion
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSrc = new Button();
            folderBrowserDialog1 = new FolderBrowserDialog();
            btnDestination = new Button();
            txtSource = new TextBox();
            txtDest = new TextBox();
            btnLoadToTreeview = new Button();
            treeViewSource = new TreeView();
            btnSaveToText = new Button();
            treeView1 = new TreeView();
            btnOpen = new Button();
            btnSave2sqlite = new Button();
            SuspendLayout();
            // 
            // btnSrc
            // 
            btnSrc.Location = new Point(12, 12);
            btnSrc.Name = "btnSrc";
            btnSrc.Size = new Size(75, 23);
            btnSrc.TabIndex = 0;
            btnSrc.Text = "Source";
            btnSrc.UseVisualStyleBackColor = true;
            btnSrc.Click += btnSrc_Click;
            // 
            // btnDestination
            // 
            btnDestination.Location = new Point(413, 12);
            btnDestination.Name = "btnDestination";
            btnDestination.Size = new Size(75, 23);
            btnDestination.TabIndex = 0;
            btnDestination.Text = "Destination";
            btnDestination.UseVisualStyleBackColor = true;
            btnDestination.Click += btnDestination_Click;
            // 
            // txtSource
            // 
            txtSource.BorderStyle = BorderStyle.FixedSingle;
            txtSource.Location = new Point(12, 41);
            txtSource.Name = "txtSource";
            txtSource.ReadOnly = true;
            txtSource.Size = new Size(385, 23);
            txtSource.TabIndex = 1;
            txtSource.Text = "D:\\root\\prjs\\github\\auxalia";
            // 
            // txtDest
            // 
            txtDest.BorderStyle = BorderStyle.FixedSingle;
            txtDest.Location = new Point(413, 41);
            txtDest.Name = "txtDest";
            txtDest.ReadOnly = true;
            txtDest.Size = new Size(419, 23);
            txtDest.TabIndex = 1;
            // 
            // btnLoadToTreeview
            // 
            btnLoadToTreeview.Location = new Point(12, 70);
            btnLoadToTreeview.Name = "btnLoadToTreeview";
            btnLoadToTreeview.Size = new Size(111, 23);
            btnLoadToTreeview.TabIndex = 2;
            btnLoadToTreeview.Text = "Load to TreeView";
            btnLoadToTreeview.UseVisualStyleBackColor = true;
            btnLoadToTreeview.Click += btnLoadToTreeview_Click;
            // 
            // treeViewSource
            // 
            treeViewSource.Location = new Point(13, 99);
            treeViewSource.Name = "treeViewSource";
            treeViewSource.Size = new Size(383, 172);
            treeViewSource.TabIndex = 4;
            // 
            // btnSaveToText
            // 
            btnSaveToText.Location = new Point(129, 70);
            btnSaveToText.Name = "btnSaveToText";
            btnSaveToText.Size = new Size(102, 23);
            btnSaveToText.TabIndex = 2;
            btnSaveToText.Text = "Save to text";
            btnSaveToText.UseVisualStyleBackColor = true;
            btnSaveToText.Click += btnSaveToText_Click;
            // 
            // treeView1
            // 
            treeView1.Location = new Point(413, 99);
            treeView1.Name = "treeView1";
            treeView1.Size = new Size(383, 172);
            treeView1.TabIndex = 4;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(413, 70);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(75, 23);
            btnOpen.TabIndex = 2;
            btnOpen.Text = "Open..";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnSave2sqlite
            // 
            btnSave2sqlite.Location = new Point(237, 70);
            btnSave2sqlite.Name = "btnSave2sqlite";
            btnSave2sqlite.Size = new Size(102, 23);
            btnSave2sqlite.TabIndex = 2;
            btnSave2sqlite.Text = "Save to SQLite";
            btnSave2sqlite.UseVisualStyleBackColor = true;
            btnSave2sqlite.Click += btnSave2sqlite_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(844, 285);
            Controls.Add(treeView1);
            Controls.Add(treeViewSource);
            Controls.Add(btnOpen);
            Controls.Add(btnSave2sqlite);
            Controls.Add(btnSaveToText);
            Controls.Add(btnLoadToTreeview);
            Controls.Add(txtDest);
            Controls.Add(txtSource);
            Controls.Add(btnDestination);
            Controls.Add(btnSrc);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSrc;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button btnDestination;
        private TextBox txtSource;
        private TextBox txtDest;
        private Button btnLoadToTreeview;
        private TreeView treeViewSource;
        private Button btnSaveToText;
        private TreeView treeView1;
        private Button btnOpen;
        private Button btnSave2sqlite;
    }
}
