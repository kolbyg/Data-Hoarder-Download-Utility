namespace DataHoarder_DL
{
    partial class SettingsUI
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
            this.chkRedirectScraperOutput = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRootDir = new System.Windows.Forms.TextBox();
            this.chkOverwriting = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.chkSimulScraping = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.nudMaxPerRun = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.nudScrapeDelayHours = new System.Windows.Forms.NumericUpDown();
            this.chkAutoQueue = new System.Windows.Forms.CheckBox();
            this.chkAutoScrape = new System.Windows.Forms.CheckBox();
            this.chkLogToSMTP = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLogFolder = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nudSMTPPort = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSMTPTo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSMTPFrom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSMTPPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSMTPUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWebhookURI = new System.Windows.Forms.TextBox();
            this.chkLogToWebhook = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbLogLevel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSMTPServer = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtIGPass = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtIGUser = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPerRun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScrapeDelayHours)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSMTPPort)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkRedirectScraperOutput
            // 
            this.chkRedirectScraperOutput.AutoSize = true;
            this.chkRedirectScraperOutput.Location = new System.Drawing.Point(6, 22);
            this.chkRedirectScraperOutput.Name = "chkRedirectScraperOutput";
            this.chkRedirectScraperOutput.Size = new System.Drawing.Size(152, 19);
            this.chkRedirectScraperOutput.TabIndex = 0;
            this.chkRedirectScraperOutput.Text = "Redirect Scraper Output";
            this.chkRedirectScraperOutput.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRootDir);
            this.groupBox1.Controls.Add(this.chkOverwriting);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.chkSimulScraping);
            this.groupBox1.Controls.Add(this.chkRedirectScraperOutput);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(302, 141);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scraper Options";
            // 
            // txtRootDir
            // 
            this.txtRootDir.Location = new System.Drawing.Point(6, 112);
            this.txtRootDir.Name = "txtRootDir";
            this.txtRootDir.Size = new System.Drawing.Size(290, 23);
            this.txtRootDir.TabIndex = 18;
            // 
            // chkOverwriting
            // 
            this.chkOverwriting.AutoSize = true;
            this.chkOverwriting.Location = new System.Drawing.Point(6, 72);
            this.chkOverwriting.Name = "chkOverwriting";
            this.chkOverwriting.Size = new System.Drawing.Size(121, 19);
            this.chkOverwriting.TabIndex = 2;
            this.chkOverwriting.Text = "Allow Overwriting";
            this.chkOverwriting.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 94);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(50, 15);
            this.label16.TabIndex = 19;
            this.label16.Text = "Root Dir";
            // 
            // chkSimulScraping
            // 
            this.chkSimulScraping.AutoSize = true;
            this.chkSimulScraping.Location = new System.Drawing.Point(6, 47);
            this.chkSimulScraping.Name = "chkSimulScraping";
            this.chkSimulScraping.Size = new System.Drawing.Size(177, 19);
            this.chkSimulScraping.TabIndex = 1;
            this.chkSimulScraping.Text = "Allow Simultanious Scraping";
            this.chkSimulScraping.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.nudMaxPerRun);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.nudScrapeDelayHours);
            this.groupBox2.Controls.Add(this.chkAutoQueue);
            this.groupBox2.Controls.Add(this.chkAutoScrape);
            this.groupBox2.Location = new System.Drawing.Point(320, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(468, 111);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Automated Scraping";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(236, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 15);
            this.label11.TabIndex = 5;
            this.label11.Text = "Max items per run";
            // 
            // nudMaxPerRun
            // 
            this.nudMaxPerRun.Location = new System.Drawing.Point(345, 50);
            this.nudMaxPerRun.Name = "nudMaxPerRun";
            this.nudMaxPerRun.Size = new System.Drawing.Size(67, 23);
            this.nudMaxPerRun.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hours between scraper runs";
            // 
            // nudScrapeDelayHours
            // 
            this.nudScrapeDelayHours.Location = new System.Drawing.Point(345, 21);
            this.nudScrapeDelayHours.Name = "nudScrapeDelayHours";
            this.nudScrapeDelayHours.Size = new System.Drawing.Size(67, 23);
            this.nudScrapeDelayHours.TabIndex = 2;
            // 
            // chkAutoQueue
            // 
            this.chkAutoQueue.AutoSize = true;
            this.chkAutoQueue.Location = new System.Drawing.Point(6, 47);
            this.chkAutoQueue.Name = "chkAutoQueue";
            this.chkAutoQueue.Size = new System.Drawing.Size(173, 19);
            this.chkAutoQueue.TabIndex = 1;
            this.chkAutoQueue.Text = "Enable Automated Queuing";
            this.chkAutoQueue.UseVisualStyleBackColor = true;
            // 
            // chkAutoScrape
            // 
            this.chkAutoScrape.AutoSize = true;
            this.chkAutoScrape.Location = new System.Drawing.Point(6, 22);
            this.chkAutoScrape.Name = "chkAutoScrape";
            this.chkAutoScrape.Size = new System.Drawing.Size(173, 19);
            this.chkAutoScrape.TabIndex = 0;
            this.chkAutoScrape.Text = "Enable Automated Scraping";
            this.chkAutoScrape.UseVisualStyleBackColor = true;
            // 
            // chkLogToSMTP
            // 
            this.chkLogToSMTP.AutoSize = true;
            this.chkLogToSMTP.Location = new System.Drawing.Point(224, 19);
            this.chkLogToSMTP.Name = "chkLogToSMTP";
            this.chkLogToSMTP.Size = new System.Drawing.Size(131, 19);
            this.chkLogToSMTP.TabIndex = 5;
            this.chkLogToSMTP.Text = "Send Errors as Email";
            this.chkLogToSMTP.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtLogFolder);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.nudSMTPPort);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtSMTPTo);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtSMTPFrom);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtSMTPPass);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtSMTPUser);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtWebhookURI);
            this.groupBox3.Controls.Add(this.chkLogToWebhook);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cmbLogLevel);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtSMTPServer);
            this.groupBox3.Controls.Add(this.chkLogToSMTP);
            this.groupBox3.Location = new System.Drawing.Point(320, 129);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(468, 203);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Error Handling";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 15);
            this.label9.TabIndex = 30;
            this.label9.Text = "Log Folder";
            // 
            // txtLogFolder
            // 
            this.txtLogFolder.Location = new System.Drawing.Point(6, 125);
            this.txtLogFolder.Name = "txtLogFolder";
            this.txtLogFolder.Size = new System.Drawing.Size(172, 23);
            this.txtLogFolder.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(402, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 15);
            this.label8.TabIndex = 28;
            this.label8.Text = "Port";
            // 
            // nudSMTPPort
            // 
            this.nudSMTPPort.Location = new System.Drawing.Point(402, 81);
            this.nudSMTPPort.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.nudSMTPPort.Name = "nudSMTPPort";
            this.nudSMTPPort.Size = new System.Drawing.Size(60, 23);
            this.nudSMTPPort.TabIndex = 27;
            this.nudSMTPPort.Value = new decimal(new int[] {
            587,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(347, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 15);
            this.label7.TabIndex = 26;
            this.label7.Text = "To Email";
            // 
            // txtSMTPTo
            // 
            this.txtSMTPTo.Location = new System.Drawing.Point(347, 169);
            this.txtSMTPTo.Name = "txtSMTPTo";
            this.txtSMTPTo.Size = new System.Drawing.Size(115, 23);
            this.txtSMTPTo.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(224, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "From Email";
            // 
            // txtSMTPFrom
            // 
            this.txtSMTPFrom.Location = new System.Drawing.Point(224, 169);
            this.txtSMTPFrom.Name = "txtSMTPFrom";
            this.txtSMTPFrom.Size = new System.Drawing.Size(115, 23);
            this.txtSMTPFrom.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "SMTP Pass";
            // 
            // txtSMTPPass
            // 
            this.txtSMTPPass.Location = new System.Drawing.Point(347, 125);
            this.txtSMTPPass.Name = "txtSMTPPass";
            this.txtSMTPPass.Size = new System.Drawing.Size(115, 23);
            this.txtSMTPPass.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "SMTP User";
            // 
            // txtSMTPUser
            // 
            this.txtSMTPUser.Location = new System.Drawing.Point(224, 125);
            this.txtSMTPUser.Name = "txtSMTPUser";
            this.txtSMTPUser.Size = new System.Drawing.Size(115, 23);
            this.txtSMTPUser.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Webhook URI";
            // 
            // txtWebhookURI
            // 
            this.txtWebhookURI.Location = new System.Drawing.Point(6, 81);
            this.txtWebhookURI.Name = "txtWebhookURI";
            this.txtWebhookURI.Size = new System.Drawing.Size(212, 23);
            this.txtWebhookURI.TabIndex = 17;
            // 
            // chkLogToWebhook
            // 
            this.chkLogToWebhook.AutoSize = true;
            this.chkLogToWebhook.Location = new System.Drawing.Point(224, 39);
            this.chkLogToWebhook.Name = "chkLogToWebhook";
            this.chkLogToWebhook.Size = new System.Drawing.Size(153, 19);
            this.chkLogToWebhook.TabIndex = 16;
            this.chkLogToWebhook.Text = "Send Errors to Webhook";
            this.chkLogToWebhook.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = "Logging Level";
            // 
            // cmbLogLevel
            // 
            this.cmbLogLevel.FormattingEnabled = true;
            this.cmbLogLevel.Items.AddRange(new object[] {
            "Info",
            "Debug",
            "Trace"});
            this.cmbLogLevel.Location = new System.Drawing.Point(6, 37);
            this.cmbLogLevel.Name = "cmbLogLevel";
            this.cmbLogLevel.Size = new System.Drawing.Size(121, 23);
            this.cmbLogLevel.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "SMTP Server";
            // 
            // txtSMTPServer
            // 
            this.txtSMTPServer.Location = new System.Drawing.Point(224, 81);
            this.txtSMTPServer.Name = "txtSMTPServer";
            this.txtSMTPServer.Size = new System.Drawing.Size(172, 23);
            this.txtSMTPServer.TabIndex = 6;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtIGPass);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txtIGUser);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Location = new System.Drawing.Point(12, 159);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(302, 109);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Instagram Options";
            // 
            // txtIGPass
            // 
            this.txtIGPass.Location = new System.Drawing.Point(6, 81);
            this.txtIGPass.Name = "txtIGPass";
            this.txtIGPass.Size = new System.Drawing.Size(140, 23);
            this.txtIGPass.TabIndex = 14;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 63);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 15);
            this.label13.TabIndex = 15;
            this.label13.Text = "Password";
            // 
            // txtIGUser
            // 
            this.txtIGUser.Location = new System.Drawing.Point(6, 37);
            this.txtIGUser.Name = "txtIGUser";
            this.txtIGUser.Size = new System.Drawing.Size(140, 23);
            this.txtIGUser.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 15);
            this.label14.TabIndex = 13;
            this.label14.Text = "Username";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(689, 415);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(99, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save and Apply";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SettingsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SettingsUI";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPerRun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScrapeDelayHours)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSMTPPort)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkRedirectScraperOutput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkOverwriting;
        private System.Windows.Forms.CheckBox chkSimulScraping;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudScrapeDelayHours;
        private System.Windows.Forms.CheckBox chkAutoQueue;
        private System.Windows.Forms.CheckBox chkAutoScrape;
        private System.Windows.Forms.CheckBox chkLogToSMTP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudSMTPPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSMTPTo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSMTPFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSMTPPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSMTPUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWebhookURI;
        private System.Windows.Forms.CheckBox chkLogToWebhook;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbLogLevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSMTPServer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLogFolder;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudMaxPerRun;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtIGPass;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtIGUser;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRootDir;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnSave;
    }
}