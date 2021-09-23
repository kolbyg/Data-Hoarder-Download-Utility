
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
            this.lsvLog = new System.Windows.Forms.ListView();
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudIGMaxToScrape = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkIGMediaMetadata = new System.Windows.Forms.CheckBox();
            this.chkIGProfileMetadata = new System.Windows.Forms.CheckBox();
            this.ptnIGParseOnly = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpageInstagram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIGMaxToScrape)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            // lsvLog
            // 
            this.lsvLog.HideSelection = false;
            this.lsvLog.Location = new System.Drawing.Point(4, 624);
            this.lsvLog.Name = "lsvLog";
            this.lsvLog.Size = new System.Drawing.Size(1362, 208);
            this.lsvLog.TabIndex = 4;
            this.lsvLog.UseCompatibleStateImageBehavior = false;
            this.lsvLog.View = System.Windows.Forms.View.Details;
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
            this.lsvQueue.HideSelection = false;
            this.lsvQueue.Location = new System.Drawing.Point(1057, 12);
            this.lsvQueue.Name = "lsvQueue";
            this.lsvQueue.Size = new System.Drawing.Size(309, 554);
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
            this.btnIGScrape.Location = new System.Drawing.Point(872, 20);
            this.btnIGScrape.Name = "btnIGScrape";
            this.btnIGScrape.Size = new System.Drawing.Size(119, 23);
            this.btnIGScrape.TabIndex = 10;
            this.btnIGScrape.Text = "Begin Scrape";
            this.btnIGScrape.UseVisualStyleBackColor = true;
            this.btnIGScrape.Click += new System.EventHandler(this.btnIGScrape_Click);
            // 
            // txtIGPass
            // 
            this.txtIGPass.Location = new System.Drawing.Point(407, 21);
            this.txtIGPass.Name = "txtIGPass";
            this.txtIGPass.Size = new System.Drawing.Size(196, 23);
            this.txtIGPass.TabIndex = 10;
            this.txtIGPass.TextChanged += new System.EventHandler(this.txtIGPass_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(407, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Password";
            // 
            // txtIGUser
            // 
            this.txtIGUser.Location = new System.Drawing.Point(205, 21);
            this.txtIGUser.Name = "txtIGUser";
            this.txtIGUser.Size = new System.Drawing.Size(196, 23);
            this.txtIGUser.TabIndex = 8;
            this.txtIGUser.TextChanged += new System.EventHandler(this.txtIGUser_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Username";
            // 
            // txtIGScrapeAcct
            // 
            this.txtIGScrapeAcct.Location = new System.Drawing.Point(3, 21);
            this.txtIGScrapeAcct.Name = "txtIGScrapeAcct";
            this.txtIGScrapeAcct.Size = new System.Drawing.Size(196, 23);
            this.txtIGScrapeAcct.TabIndex = 7;
            this.txtIGScrapeAcct.TextChanged += new System.EventHandler(this.txtIGScrapeAcct_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 3);
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
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1039, 554);
            this.tabControl1.TabIndex = 9;
            // 
            // tpageYoutube
            // 
            this.tpageYoutube.Location = new System.Drawing.Point(4, 24);
            this.tpageYoutube.Name = "tpageYoutube";
            this.tpageYoutube.Padding = new System.Windows.Forms.Padding(3);
            this.tpageYoutube.Size = new System.Drawing.Size(1031, 526);
            this.tpageYoutube.TabIndex = 1;
            this.tpageYoutube.Text = "Youtube";
            this.tpageYoutube.UseVisualStyleBackColor = true;
            // 
            // tpageInstagram
            // 
            this.tpageInstagram.Controls.Add(this.ptnIGParseOnly);
            this.tpageInstagram.Controls.Add(this.textBox1);
            this.tpageInstagram.Controls.Add(this.label3);
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
            this.tpageInstagram.Size = new System.Drawing.Size(1031, 526);
            this.tpageInstagram.TabIndex = 0;
            this.tpageInstagram.Text = "Instagram";
            this.tpageInstagram.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(407, 67);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(196, 23);
            this.textBox1.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(407, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Something";
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
            // ptnIGParseOnly
            // 
            this.ptnIGParseOnly.Location = new System.Drawing.Point(872, 49);
            this.ptnIGParseOnly.Name = "ptnIGParseOnly";
            this.ptnIGParseOnly.Size = new System.Drawing.Size(119, 23);
            this.ptnIGParseOnly.TabIndex = 18;
            this.ptnIGParseOnly.Text = "Parse Only";
            this.ptnIGParseOnly.UseVisualStyleBackColor = true;
            this.ptnIGParseOnly.Click += new System.EventHandler(this.ptnIGParseOnly_Click);
            // 
            // DownloaderUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 835);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnAddToQueue);
            this.Controls.Add(this.chkAllowOverwrite);
            this.Controls.Add(this.lsvQueue);
            this.Controls.Add(this.btnProcessQueue);
            this.Controls.Add(this.chkVerbose);
            this.Controls.Add(this.lsvLog);
            this.Controls.Add(this.btnDLDirBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDLDir);
            this.Name = "DownloaderUI";
            this.Text = "DataHoarder Downloader";
            this.Load += new System.EventHandler(this.DownloaderUI_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpageInstagram.ResumeLayout(false);
            this.tpageInstagram.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIGMaxToScrape)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDLDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDLDirBrowse;
        private System.Windows.Forms.ListView lsvLog;
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ptnIGParseOnly;
    }
}

