
namespace DataHoarder_DL
{
    partial class DownloaderUI
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
            this.txtDLDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDLDirBrowse = new System.Windows.Forms.Button();
            this.chkVerbose = new System.Windows.Forms.CheckBox();
            this.btnProcessQueue = new System.Windows.Forms.Button();
            this.lsvQueue = new System.Windows.Forms.ListView();
            this.chkAllowOverwrite = new System.Windows.Forms.CheckBox();
            this.btnIGScrape = new System.Windows.Forms.Button();
            this.txtIGPass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIGUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIGScrapeAcct = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddToQueue = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpageYoutube = new System.Windows.Forms.TabPage();
            this.tpageInstagram = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btnIGRemoveUser = new System.Windows.Forms.Button();
            this.btnIGAddUser = new System.Windows.Forms.Button();
            this.lsvIGFollowed = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.btnIGValidate = new System.Windows.Forms.Button();
            this.ptnIGParseOnly = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nudIGMaxToScrape = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkIGMediaMetadata = new System.Windows.Forms.CheckBox();
            this.chkIGProfileMetadata = new System.Windows.Forms.CheckBox();
            this.rtbLogger = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tpageInstagram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIGMaxToScrape)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDLDir
            // 
            this.txtDLDir.Location = new System.Drawing.Point(4, 595);
            this.txtDLDir.Name = "txtDLDir";
            this.txtDLDir.Size = new System.Drawing.Size(394, 23);
            this.txtDLDir.TabIndex = 1;
            this.txtDLDir.TextChanged += new System.EventHandler(this.txtDLDir_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 577);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Download Directory";
            // 
            // btnDLDirBrowse
            // 
            this.btnDLDirBrowse.Location = new System.Drawing.Point(404, 595);
            this.btnDLDirBrowse.Name = "btnDLDirBrowse";
            this.btnDLDirBrowse.Size = new System.Drawing.Size(35, 23);
            this.btnDLDirBrowse.TabIndex = 3;
            this.btnDLDirBrowse.Text = "...";
            this.btnDLDirBrowse.UseVisualStyleBackColor = true;
            // 
            // chkVerbose
            // 
            this.chkVerbose.AutoSize = true;
            this.chkVerbose.Location = new System.Drawing.Point(445, 597);
            this.chkVerbose.Name = "chkVerbose";
            this.chkVerbose.Size = new System.Drawing.Size(108, 19);
            this.chkVerbose.TabIndex = 5;
            this.chkVerbose.Text = "Verbose Output";
            this.chkVerbose.UseVisualStyleBackColor = true;
            // 
            // btnProcessQueue
            // 
            this.btnProcessQueue.Location = new System.Drawing.Point(1057, 572);
            this.btnProcessQueue.Name = "btnProcessQueue";
            this.btnProcessQueue.Size = new System.Drawing.Size(309, 44);
            this.btnProcessQueue.TabIndex = 6;
            this.btnProcessQueue.Text = "Process Queue";
            this.btnProcessQueue.UseVisualStyleBackColor = true;
            // 
            // lsvQueue
            // 
            this.lsvQueue.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lsvQueue.HideSelection = false;
            this.lsvQueue.Location = new System.Drawing.Point(1057, 27);
            this.lsvQueue.Name = "lsvQueue";
            this.lsvQueue.Size = new System.Drawing.Size(309, 539);
            this.lsvQueue.TabIndex = 7;
            this.lsvQueue.UseCompatibleStateImageBehavior = false;
            this.lsvQueue.View = System.Windows.Forms.View.List;
            // 
            // chkAllowOverwrite
            // 
            this.chkAllowOverwrite.AutoSize = true;
            this.chkAllowOverwrite.Location = new System.Drawing.Point(445, 572);
            this.chkAllowOverwrite.Name = "chkAllowOverwrite";
            this.chkAllowOverwrite.Size = new System.Drawing.Size(110, 19);
            this.chkAllowOverwrite.TabIndex = 8;
            this.chkAllowOverwrite.Text = "Allow Overwrite";
            this.chkAllowOverwrite.UseVisualStyleBackColor = true;
            // 
            // btnIGScrape
            // 
            this.btnIGScrape.Location = new System.Drawing.Point(701, 475);
            this.btnIGScrape.Name = "btnIGScrape";
            this.btnIGScrape.Size = new System.Drawing.Size(158, 23);
            this.btnIGScrape.TabIndex = 10;
            this.btnIGScrape.Text = "Scrape Selected";
            this.btnIGScrape.UseVisualStyleBackColor = true;
            this.btnIGScrape.Click += new System.EventHandler(this.btnIGScrape_Click);
            // 
            // txtIGPass
            // 
            this.txtIGPass.Location = new System.Drawing.Point(205, 21);
            this.txtIGPass.Name = "txtIGPass";
            this.txtIGPass.Size = new System.Drawing.Size(196, 23);
            this.txtIGPass.TabIndex = 10;
            this.txtIGPass.TextChanged += new System.EventHandler(this.txtIGPass_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(205, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Password";
            // 
            // txtIGUser
            // 
            this.txtIGUser.Location = new System.Drawing.Point(3, 21);
            this.txtIGUser.Name = "txtIGUser";
            this.txtIGUser.Size = new System.Drawing.Size(196, 23);
            this.txtIGUser.TabIndex = 8;
            this.txtIGUser.TextChanged += new System.EventHandler(this.txtIGUser_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Username";
            // 
            // txtIGScrapeAcct
            // 
            this.txtIGScrapeAcct.Location = new System.Drawing.Point(205, 118);
            this.txtIGScrapeAcct.Name = "txtIGScrapeAcct";
            this.txtIGScrapeAcct.Size = new System.Drawing.Size(196, 23);
            this.txtIGScrapeAcct.TabIndex = 7;
            this.txtIGScrapeAcct.TextChanged += new System.EventHandler(this.txtIGScrapeAcct_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Account Name";
            // 
            // btnAddToQueue
            // 
            this.btnAddToQueue.Location = new System.Drawing.Point(948, 572);
            this.btnAddToQueue.Name = "btnAddToQueue";
            this.btnAddToQueue.Size = new System.Drawing.Size(103, 23);
            this.btnAddToQueue.TabIndex = 1;
            this.btnAddToQueue.Text = "Add to Queue";
            this.btnAddToQueue.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpageYoutube);
            this.tabControl1.Controls.Add(this.tpageInstagram);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1039, 539);
            this.tabControl1.TabIndex = 9;
            // 
            // tpageYoutube
            // 
            this.tpageYoutube.BackColor = System.Drawing.Color.DimGray;
            this.tpageYoutube.Location = new System.Drawing.Point(4, 24);
            this.tpageYoutube.Name = "tpageYoutube";
            this.tpageYoutube.Padding = new System.Windows.Forms.Padding(3);
            this.tpageYoutube.Size = new System.Drawing.Size(1031, 511);
            this.tpageYoutube.TabIndex = 1;
            this.tpageYoutube.Text = "Youtube";
            // 
            // tpageInstagram
            // 
            this.tpageInstagram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tpageInstagram.Controls.Add(this.button1);
            this.tpageInstagram.Controls.Add(this.btnIGRemoveUser);
            this.tpageInstagram.Controls.Add(this.btnIGAddUser);
            this.tpageInstagram.Controls.Add(this.lsvIGFollowed);
            this.tpageInstagram.Controls.Add(this.btnIGValidate);
            this.tpageInstagram.Controls.Add(this.ptnIGParseOnly);
            this.tpageInstagram.Controls.Add(this.label2);
            this.tpageInstagram.Controls.Add(this.nudIGMaxToScrape);
            this.tpageInstagram.Controls.Add(this.groupBox1);
            this.tpageInstagram.Controls.Add(this.btnIGScrape);
            this.tpageInstagram.Controls.Add(this.txtIGPass);
            this.tpageInstagram.Controls.Add(this.label4);
            this.tpageInstagram.Controls.Add(this.label6);
            this.tpageInstagram.Controls.Add(this.txtIGScrapeAcct);
            this.tpageInstagram.Controls.Add(this.txtIGUser);
            this.tpageInstagram.Controls.Add(this.label5);
            this.tpageInstagram.Location = new System.Drawing.Point(4, 24);
            this.tpageInstagram.Name = "tpageInstagram";
            this.tpageInstagram.Padding = new System.Windows.Forms.Padding(3);
            this.tpageInstagram.Size = new System.Drawing.Size(1031, 511);
            this.tpageInstagram.TabIndex = 0;
            this.tpageInstagram.Text = "Instagram";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(701, 446);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnIGRemoveUser
            // 
            this.btnIGRemoveUser.Location = new System.Drawing.Point(865, 415);
            this.btnIGRemoveUser.Name = "btnIGRemoveUser";
            this.btnIGRemoveUser.Size = new System.Drawing.Size(158, 23);
            this.btnIGRemoveUser.TabIndex = 22;
            this.btnIGRemoveUser.Text = "Remove User";
            this.btnIGRemoveUser.UseVisualStyleBackColor = true;
            this.btnIGRemoveUser.Click += new System.EventHandler(this.btnIGRemoveUser_Click);
            // 
            // btnIGAddUser
            // 
            this.btnIGAddUser.Location = new System.Drawing.Point(701, 415);
            this.btnIGAddUser.Name = "btnIGAddUser";
            this.btnIGAddUser.Size = new System.Drawing.Size(158, 23);
            this.btnIGAddUser.TabIndex = 21;
            this.btnIGAddUser.Text = "Add User";
            this.btnIGAddUser.UseVisualStyleBackColor = true;
            this.btnIGAddUser.Click += new System.EventHandler(this.btnIGAddUser_Click);
            // 
            // lsvIGFollowed
            // 
            this.lsvIGFollowed.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvIGFollowed.HideSelection = false;
            this.lsvIGFollowed.Location = new System.Drawing.Point(407, 6);
            this.lsvIGFollowed.Name = "lsvIGFollowed";
            this.lsvIGFollowed.Size = new System.Drawing.Size(618, 403);
            this.lsvIGFollowed.TabIndex = 20;
            this.lsvIGFollowed.UseCompatibleStateImageBehavior = false;
            this.lsvIGFollowed.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Username";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Last Scraped";
            this.columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "# Scraped";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Last Validated";
            this.columnHeader4.Width = 140;
            // 
            // btnIGValidate
            // 
            this.btnIGValidate.Location = new System.Drawing.Point(865, 475);
            this.btnIGValidate.Name = "btnIGValidate";
            this.btnIGValidate.Size = new System.Drawing.Size(158, 23);
            this.btnIGValidate.TabIndex = 19;
            this.btnIGValidate.Text = "Validate Only";
            this.btnIGValidate.UseVisualStyleBackColor = true;
            this.btnIGValidate.Click += new System.EventHandler(this.btnIGValidate_Click);
            // 
            // ptnIGParseOnly
            // 
            this.ptnIGParseOnly.Location = new System.Drawing.Point(865, 446);
            this.ptnIGParseOnly.Name = "ptnIGParseOnly";
            this.ptnIGParseOnly.Size = new System.Drawing.Size(158, 23);
            this.ptnIGParseOnly.TabIndex = 18;
            this.ptnIGParseOnly.Text = "Parse Only";
            this.ptnIGParseOnly.UseVisualStyleBackColor = true;
            this.ptnIGParseOnly.Click += new System.EventHandler(this.ptnIGParseOnly_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Max Items to Scrape";
            // 
            // nudIGMaxToScrape
            // 
            this.nudIGMaxToScrape.Location = new System.Drawing.Point(205, 67);
            this.nudIGMaxToScrape.Name = "nudIGMaxToScrape";
            this.nudIGMaxToScrape.Size = new System.Drawing.Size(196, 23);
            this.nudIGMaxToScrape.TabIndex = 14;
            this.nudIGMaxToScrape.ValueChanged += new System.EventHandler(this.nudIGMaxToScrape_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkIGMediaMetadata);
            this.groupBox1.Controls.Add(this.chkIGProfileMetadata);
            this.groupBox1.Location = new System.Drawing.Point(3, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(196, 100);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Include Metadata";
            // 
            // chkIGMediaMetadata
            // 
            this.chkIGMediaMetadata.AutoSize = true;
            this.chkIGMediaMetadata.Location = new System.Drawing.Point(6, 47);
            this.chkIGMediaMetadata.Name = "chkIGMediaMetadata";
            this.chkIGMediaMetadata.Size = new System.Drawing.Size(59, 19);
            this.chkIGMediaMetadata.TabIndex = 14;
            this.chkIGMediaMetadata.Text = "Media";
            this.chkIGMediaMetadata.UseVisualStyleBackColor = true;
            // 
            // chkIGProfileMetadata
            // 
            this.chkIGProfileMetadata.AutoSize = true;
            this.chkIGProfileMetadata.Location = new System.Drawing.Point(6, 22);
            this.chkIGProfileMetadata.Name = "chkIGProfileMetadata";
            this.chkIGProfileMetadata.Size = new System.Drawing.Size(60, 19);
            this.chkIGProfileMetadata.TabIndex = 15;
            this.chkIGProfileMetadata.Text = "Profile";
            this.chkIGProfileMetadata.UseVisualStyleBackColor = true;
            // 
            // rtbLogger
            // 
            this.rtbLogger.BackColor = System.Drawing.SystemColors.ControlDark;
            this.rtbLogger.ForeColor = System.Drawing.SystemColors.Control;
            this.rtbLogger.Location = new System.Drawing.Point(4, 624);
            this.rtbLogger.Name = "rtbLogger";
            this.rtbLogger.Size = new System.Drawing.Size(1362, 210);
            this.rtbLogger.TabIndex = 10;
            this.rtbLogger.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1372, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // DownloaderUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1372, 835);
            this.Controls.Add(this.rtbLogger);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnAddToQueue);
            this.Controls.Add(this.chkAllowOverwrite);
            this.Controls.Add(this.lsvQueue);
            this.Controls.Add(this.btnProcessQueue);
            this.Controls.Add(this.chkVerbose);
            this.Controls.Add(this.btnDLDirBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDLDir);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Name = "DownloaderUI";
            this.Text = "DataHoarder Downloader";
            this.Load += new System.EventHandler(this.DownloaderUI_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpageInstagram.ResumeLayout(false);
            this.tpageInstagram.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIGMaxToScrape)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDLDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDLDirBrowse;
        private System.Windows.Forms.CheckBox chkVerbose;
        private System.Windows.Forms.Button btnProcessQueue;
        private System.Windows.Forms.ListView lsvQueue;
        private System.Windows.Forms.CheckBox chkAllowOverwrite;
        private System.Windows.Forms.Button btnAddToQueue;
        private System.Windows.Forms.Button btnIGScrape;
        private System.Windows.Forms.TextBox txtIGPass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIGUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIGScrapeAcct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpageYoutube;
        private System.Windows.Forms.TabPage tpageInstagram;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkIGMediaMetadata;
        private System.Windows.Forms.CheckBox chkIGProfileMetadata;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudIGMaxToScrape;
        private System.Windows.Forms.Button ptnIGParseOnly;
        private System.Windows.Forms.Button btnIGValidate;
        private System.Windows.Forms.RichTextBox rtbLogger;
        private System.Windows.Forms.ListView lsvIGFollowed;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnIGRemoveUser;
        private System.Windows.Forms.Button btnIGAddUser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}

