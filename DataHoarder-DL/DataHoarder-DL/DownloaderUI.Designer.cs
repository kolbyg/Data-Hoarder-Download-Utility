
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
            this.btnProcessQueue = new System.Windows.Forms.Button();
            this.lsvQueue = new System.Windows.Forms.ListView();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
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
            this.label9 = new System.Windows.Forms.Label();
            this.chkYTAudioOnly = new System.Windows.Forms.CheckBox();
            this.btnYTScrapeChannel = new System.Windows.Forms.Button();
            this.btnYTScrapePlaylist = new System.Windows.Forms.Button();
            this.btnYTScrapeVideo = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtYTURL = new System.Windows.Forms.TextBox();
            this.tpageInstagram = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btnIGRemoveUser = new System.Windows.Forms.Button();
            this.btnIGAddUser = new System.Windows.Forms.Button();
            this.lsvIGFollowed = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.btnIGValidate = new System.Windows.Forms.Button();
            this.ptnIGParseOnly = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.nudIGMaxToScrape = new System.Windows.Forms.NumericUpDown();
            this.tpageTiktok = new System.Windows.Forms.TabPage();
            this.btnTTParseOnly = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nudTTMaxToScrape = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTTScrapeAcct = new System.Windows.Forms.TextBox();
            this.btnTTRemoveUser = new System.Windows.Forms.Button();
            this.btnTTAddUser = new System.Windows.Forms.Button();
            this.lsvTTFollowed = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.btnTTScrape = new System.Windows.Forms.Button();
            this.rtbLogger = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnTTValidateOnly = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpageYoutube.SuspendLayout();
            this.tpageInstagram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIGMaxToScrape)).BeginInit();
            this.tpageTiktok.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTTMaxToScrape)).BeginInit();
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
            // btnProcessQueue
            // 
            this.btnProcessQueue.Location = new System.Drawing.Point(1057, 572);
            this.btnProcessQueue.Name = "btnProcessQueue";
            this.btnProcessQueue.Size = new System.Drawing.Size(309, 44);
            this.btnProcessQueue.TabIndex = 6;
            this.btnProcessQueue.Text = "Process Queue";
            this.btnProcessQueue.UseVisualStyleBackColor = true;
            this.btnProcessQueue.Click += new System.EventHandler(this.btnProcessQueue_Click);
            // 
            // lsvQueue
            // 
            this.lsvQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader9,
            this.columnHeader10});
            this.lsvQueue.HideSelection = false;
            this.lsvQueue.Location = new System.Drawing.Point(1057, 27);
            this.lsvQueue.Name = "lsvQueue";
            this.lsvQueue.Size = new System.Drawing.Size(309, 539);
            this.lsvQueue.TabIndex = 7;
            this.lsvQueue.UseCompatibleStateImageBehavior = false;
            this.lsvQueue.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Order";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Type";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "URI";
            this.columnHeader10.Width = 240;
            // 
            // chkAllowOverwrite
            // 
            this.chkAllowOverwrite.AutoSize = true;
            this.chkAllowOverwrite.Enabled = false;
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
            this.btnAddToQueue.Enabled = false;
            this.btnAddToQueue.Location = new System.Drawing.Point(948, 572);
            this.btnAddToQueue.Name = "btnAddToQueue";
            this.btnAddToQueue.Size = new System.Drawing.Size(103, 23);
            this.btnAddToQueue.TabIndex = 1;
            this.btnAddToQueue.Text = "Add to Queue";
            this.btnAddToQueue.UseVisualStyleBackColor = true;
            this.btnAddToQueue.Click += new System.EventHandler(this.btnAddToQueue_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpageYoutube);
            this.tabControl1.Controls.Add(this.tpageInstagram);
            this.tabControl1.Controls.Add(this.tpageTiktok);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1039, 539);
            this.tabControl1.TabIndex = 9;
            // 
            // tpageYoutube
            // 
            this.tpageYoutube.Controls.Add(this.label9);
            this.tpageYoutube.Controls.Add(this.chkYTAudioOnly);
            this.tpageYoutube.Controls.Add(this.btnYTScrapeChannel);
            this.tpageYoutube.Controls.Add(this.btnYTScrapePlaylist);
            this.tpageYoutube.Controls.Add(this.btnYTScrapeVideo);
            this.tpageYoutube.Controls.Add(this.label8);
            this.tpageYoutube.Controls.Add(this.txtYTURL);
            this.tpageYoutube.Location = new System.Drawing.Point(4, 24);
            this.tpageYoutube.Name = "tpageYoutube";
            this.tpageYoutube.Padding = new System.Windows.Forms.Padding(3);
            this.tpageYoutube.Size = new System.Drawing.Size(1031, 511);
            this.tpageYoutube.TabIndex = 1;
            this.tpageYoutube.Text = "Youtube";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(224, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "Scrape As:";
            // 
            // chkYTAudioOnly
            // 
            this.chkYTAudioOnly.AutoSize = true;
            this.chkYTAudioOnly.Location = new System.Drawing.Point(6, 54);
            this.chkYTAudioOnly.Name = "chkYTAudioOnly";
            this.chkYTAudioOnly.Size = new System.Drawing.Size(124, 19);
            this.chkYTAudioOnly.TabIndex = 14;
            this.chkYTAudioOnly.Text = "Scrape Audio Only";
            this.chkYTAudioOnly.UseVisualStyleBackColor = true;
            // 
            // btnYTScrapeChannel
            // 
            this.btnYTScrapeChannel.Location = new System.Drawing.Point(224, 79);
            this.btnYTScrapeChannel.Name = "btnYTScrapeChannel";
            this.btnYTScrapeChannel.Size = new System.Drawing.Size(158, 23);
            this.btnYTScrapeChannel.TabIndex = 13;
            this.btnYTScrapeChannel.Text = "Channel";
            this.btnYTScrapeChannel.UseVisualStyleBackColor = true;
            this.btnYTScrapeChannel.Click += new System.EventHandler(this.btnYTScrapeChannel_Click);
            // 
            // btnYTScrapePlaylist
            // 
            this.btnYTScrapePlaylist.Location = new System.Drawing.Point(224, 50);
            this.btnYTScrapePlaylist.Name = "btnYTScrapePlaylist";
            this.btnYTScrapePlaylist.Size = new System.Drawing.Size(158, 23);
            this.btnYTScrapePlaylist.TabIndex = 12;
            this.btnYTScrapePlaylist.Text = "Playlist";
            this.btnYTScrapePlaylist.UseVisualStyleBackColor = true;
            this.btnYTScrapePlaylist.Click += new System.EventHandler(this.btnYTScrapePlaylist_Click);
            // 
            // btnYTScrapeVideo
            // 
            this.btnYTScrapeVideo.Location = new System.Drawing.Point(224, 21);
            this.btnYTScrapeVideo.Name = "btnYTScrapeVideo";
            this.btnYTScrapeVideo.Size = new System.Drawing.Size(158, 23);
            this.btnYTScrapeVideo.TabIndex = 11;
            this.btnYTScrapeVideo.Text = "Video";
            this.btnYTScrapeVideo.UseVisualStyleBackColor = true;
            this.btnYTScrapeVideo.Click += new System.EventHandler(this.btnYTScrapeVideo_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "URL";
            // 
            // txtYTURL
            // 
            this.txtYTURL.Location = new System.Drawing.Point(6, 21);
            this.txtYTURL.Name = "txtYTURL";
            this.txtYTURL.Size = new System.Drawing.Size(196, 23);
            this.txtYTURL.TabIndex = 9;
            // 
            // tpageInstagram
            // 
            this.tpageInstagram.Controls.Add(this.button1);
            this.tpageInstagram.Controls.Add(this.btnIGRemoveUser);
            this.tpageInstagram.Controls.Add(this.btnIGAddUser);
            this.tpageInstagram.Controls.Add(this.lsvIGFollowed);
            this.tpageInstagram.Controls.Add(this.btnIGValidate);
            this.tpageInstagram.Controls.Add(this.ptnIGParseOnly);
            this.tpageInstagram.Controls.Add(this.label2);
            this.tpageInstagram.Controls.Add(this.nudIGMaxToScrape);
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
            this.columnHeader12,
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
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Last Scraped";
            this.columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "# Scraped";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "# Files";
            this.columnHeader12.Width = 70;
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
            // tpageTiktok
            // 
            this.tpageTiktok.BackColor = System.Drawing.SystemColors.Control;
            this.tpageTiktok.Controls.Add(this.btnTTValidateOnly);
            this.tpageTiktok.Controls.Add(this.btnTTParseOnly);
            this.tpageTiktok.Controls.Add(this.label3);
            this.tpageTiktok.Controls.Add(this.nudTTMaxToScrape);
            this.tpageTiktok.Controls.Add(this.label7);
            this.tpageTiktok.Controls.Add(this.txtTTScrapeAcct);
            this.tpageTiktok.Controls.Add(this.btnTTRemoveUser);
            this.tpageTiktok.Controls.Add(this.btnTTAddUser);
            this.tpageTiktok.Controls.Add(this.lsvTTFollowed);
            this.tpageTiktok.Controls.Add(this.btnTTScrape);
            this.tpageTiktok.Location = new System.Drawing.Point(4, 24);
            this.tpageTiktok.Name = "tpageTiktok";
            this.tpageTiktok.Size = new System.Drawing.Size(1031, 511);
            this.tpageTiktok.TabIndex = 2;
            this.tpageTiktok.Text = "TikTok";
            // 
            // btnTTParseOnly
            // 
            this.btnTTParseOnly.Location = new System.Drawing.Point(410, 441);
            this.btnTTParseOnly.Name = "btnTTParseOnly";
            this.btnTTParseOnly.Size = new System.Drawing.Size(158, 23);
            this.btnTTParseOnly.TabIndex = 33;
            this.btnTTParseOnly.Text = "Parse Only";
            this.btnTTParseOnly.UseVisualStyleBackColor = true;
            this.btnTTParseOnly.Click += new System.EventHandler(this.btnTTParseOnly_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 15);
            this.label3.TabIndex = 32;
            this.label3.Text = "Max Items to Scrape";
            // 
            // nudTTMaxToScrape
            // 
            this.nudTTMaxToScrape.Location = new System.Drawing.Point(208, 25);
            this.nudTTMaxToScrape.Name = "nudTTMaxToScrape";
            this.nudTTMaxToScrape.Size = new System.Drawing.Size(196, 23);
            this.nudTTMaxToScrape.TabIndex = 31;
            this.nudTTMaxToScrape.ValueChanged += new System.EventHandler(this.nudTTMaxToScrape_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(208, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 15);
            this.label7.TabIndex = 29;
            this.label7.Text = "Account Name";
            // 
            // txtTTScrapeAcct
            // 
            this.txtTTScrapeAcct.Location = new System.Drawing.Point(208, 69);
            this.txtTTScrapeAcct.Name = "txtTTScrapeAcct";
            this.txtTTScrapeAcct.Size = new System.Drawing.Size(196, 23);
            this.txtTTScrapeAcct.TabIndex = 30;
            this.txtTTScrapeAcct.TextChanged += new System.EventHandler(this.txtTTScrapeAccount_TextChanged);
            // 
            // btnTTRemoveUser
            // 
            this.btnTTRemoveUser.Location = new System.Drawing.Point(870, 441);
            this.btnTTRemoveUser.Name = "btnTTRemoveUser";
            this.btnTTRemoveUser.Size = new System.Drawing.Size(158, 23);
            this.btnTTRemoveUser.TabIndex = 28;
            this.btnTTRemoveUser.Text = "Remove User";
            this.btnTTRemoveUser.UseVisualStyleBackColor = true;
            this.btnTTRemoveUser.Click += new System.EventHandler(this.btnTTRemoveUser_Click);
            // 
            // btnTTAddUser
            // 
            this.btnTTAddUser.Location = new System.Drawing.Point(870, 412);
            this.btnTTAddUser.Name = "btnTTAddUser";
            this.btnTTAddUser.Size = new System.Drawing.Size(158, 23);
            this.btnTTAddUser.TabIndex = 27;
            this.btnTTAddUser.Text = "Add User";
            this.btnTTAddUser.UseVisualStyleBackColor = true;
            this.btnTTAddUser.Click += new System.EventHandler(this.btnTTAddUser_Click);
            // 
            // lsvTTFollowed
            // 
            this.lsvTTFollowed.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lsvTTFollowed.HideSelection = false;
            this.lsvTTFollowed.Location = new System.Drawing.Point(410, 3);
            this.lsvTTFollowed.Name = "lsvTTFollowed";
            this.lsvTTFollowed.Size = new System.Drawing.Size(618, 403);
            this.lsvTTFollowed.TabIndex = 26;
            this.lsvTTFollowed.UseCompatibleStateImageBehavior = false;
            this.lsvTTFollowed.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Username";
            this.columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Last Scraped";
            this.columnHeader6.Width = 140;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "# Scraped";
            this.columnHeader7.Width = 80;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Last Validated";
            this.columnHeader8.Width = 140;
            // 
            // btnTTScrape
            // 
            this.btnTTScrape.Location = new System.Drawing.Point(410, 412);
            this.btnTTScrape.Name = "btnTTScrape";
            this.btnTTScrape.Size = new System.Drawing.Size(158, 23);
            this.btnTTScrape.TabIndex = 24;
            this.btnTTScrape.Text = "Scrape Selected";
            this.btnTTScrape.UseVisualStyleBackColor = true;
            this.btnTTScrape.Click += new System.EventHandler(this.btnTTScrape_Click);
            // 
            // rtbLogger
            // 
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
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Info",
            "Debug",
            "Trace"});
            this.comboBox1.Location = new System.Drawing.Point(561, 591);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(561, 573);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 15);
            this.label10.TabIndex = 13;
            this.label10.Text = "Logging Level";
            // 
            // btnTTValidateOnly
            // 
            this.btnTTValidateOnly.Location = new System.Drawing.Point(410, 470);
            this.btnTTValidateOnly.Name = "btnTTValidateOnly";
            this.btnTTValidateOnly.Size = new System.Drawing.Size(158, 23);
            this.btnTTValidateOnly.TabIndex = 34;
            this.btnTTValidateOnly.Text = "Validate Only";
            this.btnTTValidateOnly.UseVisualStyleBackColor = true;
            this.btnTTValidateOnly.Click += new System.EventHandler(this.btnTTValidateOnly_Click);
            // 
            // DownloaderUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 835);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.rtbLogger);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnAddToQueue);
            this.Controls.Add(this.chkAllowOverwrite);
            this.Controls.Add(this.lsvQueue);
            this.Controls.Add(this.btnProcessQueue);
            this.Controls.Add(this.btnDLDirBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDLDir);
            this.Controls.Add(this.menuStrip1);
            this.Name = "DownloaderUI";
            this.Text = "DataHoarder Downloader";
            this.Load += new System.EventHandler(this.DownloaderUI_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpageYoutube.ResumeLayout(false);
            this.tpageYoutube.PerformLayout();
            this.tpageInstagram.ResumeLayout(false);
            this.tpageInstagram.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIGMaxToScrape)).EndInit();
            this.tpageTiktok.ResumeLayout(false);
            this.tpageTiktok.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTTMaxToScrape)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDLDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDLDirBrowse;
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
        private System.Windows.Forms.TabPage tpageTiktok;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudTTMaxToScrape;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTTScrapeAcct;
        private System.Windows.Forms.Button btnTTRemoveUser;
        private System.Windows.Forms.Button btnTTAddUser;
        private System.Windows.Forms.ListView lsvTTFollowed;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button btnTTScrape;
        private System.Windows.Forms.Button btnTTParseOnly;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkYTAudioOnly;
        private System.Windows.Forms.Button btnYTScrapeChannel;
        private System.Windows.Forms.Button btnYTScrapePlaylist;
        private System.Windows.Forms.Button btnYTScrapeVideo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtYTURL;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.Button btnTTValidateOnly;
    }
}

