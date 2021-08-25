
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDLSource = new System.Windows.Forms.ComboBox();
            this.btnAddToQueue = new System.Windows.Forms.Button();
            this.txtDLURL = new System.Windows.Forms.TextBox();
            this.btnIGScrape = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIGScrapeAcct = new System.Windows.Forms.TextBox();
            this.txtIGUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIGPass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
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
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbDLSource);
            this.panel1.Controls.Add(this.btnAddToQueue);
            this.panel1.Controls.Add(this.txtDLURL);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1039, 554);
            this.panel1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(633, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Download Source";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Download URL";
            // 
            // cmbDLSource
            // 
            this.cmbDLSource.FormattingEnabled = true;
            this.cmbDLSource.Location = new System.Drawing.Point(633, 18);
            this.cmbDLSource.Name = "cmbDLSource";
            this.cmbDLSource.Size = new System.Drawing.Size(406, 23);
            this.cmbDLSource.TabIndex = 2;
            // 
            // btnAddToQueue
            // 
            this.btnAddToQueue.Location = new System.Drawing.Point(936, 531);
            this.btnAddToQueue.Name = "btnAddToQueue";
            this.btnAddToQueue.Size = new System.Drawing.Size(103, 23);
            this.btnAddToQueue.TabIndex = 1;
            this.btnAddToQueue.Text = "Add to Queue";
            this.btnAddToQueue.UseVisualStyleBackColor = true;
            // 
            // txtDLURL
            // 
            this.txtDLURL.Location = new System.Drawing.Point(0, 18);
            this.txtDLURL.Name = "txtDLURL";
            this.txtDLURL.Size = new System.Drawing.Size(627, 23);
            this.txtDLURL.TabIndex = 0;
            // 
            // btnIGScrape
            // 
            this.btnIGScrape.Location = new System.Drawing.Point(612, 36);
            this.btnIGScrape.Name = "btnIGScrape";
            this.btnIGScrape.Size = new System.Drawing.Size(119, 23);
            this.btnIGScrape.TabIndex = 10;
            this.btnIGScrape.Text = "Begin Scrape";
            this.btnIGScrape.UseVisualStyleBackColor = true;
            this.btnIGScrape.Click += new System.EventHandler(this.btnIGScrape_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnIGScrape);
            this.groupBox1.Controls.Add(this.txtIGPass);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtIGUser);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtIGScrapeAcct);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(3, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1033, 86);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instagram";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Account Name";
            // 
            // txtIGScrapeAcct
            // 
            this.txtIGScrapeAcct.Location = new System.Drawing.Point(6, 37);
            this.txtIGScrapeAcct.Name = "txtIGScrapeAcct";
            this.txtIGScrapeAcct.Size = new System.Drawing.Size(196, 23);
            this.txtIGScrapeAcct.TabIndex = 7;
            // 
            // txtIGUser
            // 
            this.txtIGUser.Location = new System.Drawing.Point(208, 37);
            this.txtIGUser.Name = "txtIGUser";
            this.txtIGUser.Size = new System.Drawing.Size(196, 23);
            this.txtIGUser.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Username";
            // 
            // txtIGPass
            // 
            this.txtIGPass.Location = new System.Drawing.Point(410, 37);
            this.txtIGPass.Name = "txtIGPass";
            this.txtIGPass.Size = new System.Drawing.Size(196, 23);
            this.txtIGPass.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(410, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Password";
            // 
            // DownloaderUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 835);
            this.Controls.Add(this.panel1);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDLSource;
        private System.Windows.Forms.Button btnAddToQueue;
        private System.Windows.Forms.TextBox txtDLURL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIGScrape;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIGPass;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIGUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIGScrapeAcct;
        private System.Windows.Forms.Label label4;
    }
}

