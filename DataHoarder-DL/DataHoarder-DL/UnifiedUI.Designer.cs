namespace DataHoarder_DL
{
    partial class UnifiedUI
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
            this.mainList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMonitoredScrapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runFullValidationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.validateSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearQueue = new System.Windows.Forms.Button();
            this.btnQueueItems = new System.Windows.Forms.Button();
            this.btnAutoQueue = new System.Windows.Forms.Button();
            this.btnPauseScraper = new System.Windows.Forms.Button();
            this.btnStartScraper = new System.Windows.Forms.Button();
            this.btnStopScraper = new System.Windows.Forms.Button();
            this.btnKillScraper = new System.Windows.Forms.Button();
            this.rtbLogger = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFriendlyName = new System.Windows.Forms.TextBox();
            this.nudMaxDays = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudMaxScrape = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnQuickScrape = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnMultilineAdd = new System.Windows.Forms.Button();
            this.txtURI = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxScrape)).BeginInit();
            this.SuspendLayout();
            // 
            // mainList
            // 
            this.mainList.AllowColumnReorder = true;
            this.mainList.BackColor = System.Drawing.Color.Black;
            this.mainList.CheckBoxes = true;
            this.mainList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader8,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.mainList.ForeColor = System.Drawing.Color.Lime;
            this.mainList.FullRowSelect = true;
            this.mainList.GridLines = true;
            this.mainList.Location = new System.Drawing.Point(292, 27);
            this.mainList.Name = "mainList";
            this.mainList.Size = new System.Drawing.Size(1336, 745);
            this.mainList.TabIndex = 0;
            this.mainList.UseCompatibleStateImageBehavior = false;
            this.mainList.View = System.Windows.Forms.View.Details;
            this.mainList.SelectedIndexChanged += new System.EventHandler(this.mainList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Platform";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Short Name";
            this.columnHeader8.Width = 240;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "URI";
            this.columnHeader2.Width = 400;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Last Validated";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Last Scraped";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "# Files";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Total Size";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.validationToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1640, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.addMonitoredScrapeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // addMonitoredScrapeToolStripMenuItem
            // 
            this.addMonitoredScrapeToolStripMenuItem.Name = "addMonitoredScrapeToolStripMenuItem";
            this.addMonitoredScrapeToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.addMonitoredScrapeToolStripMenuItem.Text = "Add Monitored Scrape";
            // 
            // validationToolStripMenuItem
            // 
            this.validationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runFullValidationToolStripMenuItem,
            this.validateSelectedToolStripMenuItem});
            this.validationToolStripMenuItem.Name = "validationToolStripMenuItem";
            this.validationToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.validationToolStripMenuItem.Text = "Validation";
            // 
            // runFullValidationToolStripMenuItem
            // 
            this.runFullValidationToolStripMenuItem.Name = "runFullValidationToolStripMenuItem";
            this.runFullValidationToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.runFullValidationToolStripMenuItem.Text = "Run Full Validation";
            this.runFullValidationToolStripMenuItem.Click += new System.EventHandler(this.runFullValidationToolStripMenuItem_Click);
            // 
            // validateSelectedToolStripMenuItem
            // 
            this.validateSelectedToolStripMenuItem.Name = "validateSelectedToolStripMenuItem";
            this.validateSelectedToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.validateSelectedToolStripMenuItem.Text = "Validate Selected";
            this.validateSelectedToolStripMenuItem.Click += new System.EventHandler(this.validateSelectedToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearQueue);
            this.groupBox1.Controls.Add(this.btnQueueItems);
            this.groupBox1.Controls.Add(this.btnAutoQueue);
            this.groupBox1.Controls.Add(this.btnPauseScraper);
            this.groupBox1.Controls.Add(this.btnStartScraper);
            this.groupBox1.Controls.Add(this.btnStopScraper);
            this.groupBox1.Controls.Add(this.btnKillScraper);
            this.groupBox1.ForeColor = System.Drawing.Color.Lime;
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 149);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scraper Controls";
            // 
            // btnClearQueue
            // 
            this.btnClearQueue.BackColor = System.Drawing.Color.Black;
            this.btnClearQueue.ForeColor = System.Drawing.Color.Lime;
            this.btnClearQueue.Location = new System.Drawing.Point(140, 23);
            this.btnClearQueue.Name = "btnClearQueue";
            this.btnClearQueue.Size = new System.Drawing.Size(128, 23);
            this.btnClearQueue.TabIndex = 6;
            this.btnClearQueue.Text = "Clear Queue";
            this.btnClearQueue.UseVisualStyleBackColor = false;
            this.btnClearQueue.Click += new System.EventHandler(this.btnClearQueue_Click);
            // 
            // btnQueueItems
            // 
            this.btnQueueItems.BackColor = System.Drawing.Color.Black;
            this.btnQueueItems.ForeColor = System.Drawing.Color.Lime;
            this.btnQueueItems.Location = new System.Drawing.Point(6, 23);
            this.btnQueueItems.Name = "btnQueueItems";
            this.btnQueueItems.Size = new System.Drawing.Size(128, 23);
            this.btnQueueItems.TabIndex = 5;
            this.btnQueueItems.Text = "Queue Selected";
            this.btnQueueItems.UseVisualStyleBackColor = false;
            this.btnQueueItems.Click += new System.EventHandler(this.btnQueueItems_Click);
            // 
            // btnAutoQueue
            // 
            this.btnAutoQueue.BackColor = System.Drawing.Color.Black;
            this.btnAutoQueue.ForeColor = System.Drawing.Color.Lime;
            this.btnAutoQueue.Location = new System.Drawing.Point(6, 52);
            this.btnAutoQueue.Name = "btnAutoQueue";
            this.btnAutoQueue.Size = new System.Drawing.Size(128, 23);
            this.btnAutoQueue.TabIndex = 4;
            this.btnAutoQueue.Text = "Auto Queue";
            this.btnAutoQueue.UseVisualStyleBackColor = false;
            this.btnAutoQueue.Click += new System.EventHandler(this.btnAutoQueue_Click);
            // 
            // btnPauseScraper
            // 
            this.btnPauseScraper.BackColor = System.Drawing.Color.Black;
            this.btnPauseScraper.ForeColor = System.Drawing.Color.Lime;
            this.btnPauseScraper.Location = new System.Drawing.Point(6, 81);
            this.btnPauseScraper.Name = "btnPauseScraper";
            this.btnPauseScraper.Size = new System.Drawing.Size(128, 23);
            this.btnPauseScraper.TabIndex = 3;
            this.btnPauseScraper.Text = "Pause";
            this.btnPauseScraper.UseVisualStyleBackColor = false;
            this.btnPauseScraper.Click += new System.EventHandler(this.btnPauseScraper_Click);
            // 
            // btnStartScraper
            // 
            this.btnStartScraper.BackColor = System.Drawing.Color.Black;
            this.btnStartScraper.ForeColor = System.Drawing.Color.Lime;
            this.btnStartScraper.Location = new System.Drawing.Point(9, 110);
            this.btnStartScraper.Name = "btnStartScraper";
            this.btnStartScraper.Size = new System.Drawing.Size(262, 33);
            this.btnStartScraper.TabIndex = 2;
            this.btnStartScraper.Text = "Begin Scraping";
            this.btnStartScraper.UseVisualStyleBackColor = false;
            this.btnStartScraper.Click += new System.EventHandler(this.btnStartScraper_Click);
            // 
            // btnStopScraper
            // 
            this.btnStopScraper.BackColor = System.Drawing.Color.Black;
            this.btnStopScraper.ForeColor = System.Drawing.Color.Lime;
            this.btnStopScraper.Location = new System.Drawing.Point(140, 52);
            this.btnStopScraper.Name = "btnStopScraper";
            this.btnStopScraper.Size = new System.Drawing.Size(128, 23);
            this.btnStopScraper.TabIndex = 1;
            this.btnStopScraper.Text = "Stop Gracefully";
            this.btnStopScraper.UseVisualStyleBackColor = false;
            this.btnStopScraper.Click += new System.EventHandler(this.btnStopScraper_Click);
            // 
            // btnKillScraper
            // 
            this.btnKillScraper.BackColor = System.Drawing.Color.Black;
            this.btnKillScraper.ForeColor = System.Drawing.Color.Lime;
            this.btnKillScraper.Location = new System.Drawing.Point(140, 81);
            this.btnKillScraper.Name = "btnKillScraper";
            this.btnKillScraper.Size = new System.Drawing.Size(128, 23);
            this.btnKillScraper.TabIndex = 0;
            this.btnKillScraper.Text = "Kill All Scrapers";
            this.btnKillScraper.UseVisualStyleBackColor = false;
            this.btnKillScraper.Click += new System.EventHandler(this.btnKillScraper_Click);
            // 
            // rtbLogger
            // 
            this.rtbLogger.BackColor = System.Drawing.Color.DimGray;
            this.rtbLogger.Location = new System.Drawing.Point(12, 545);
            this.rtbLogger.Name = "rtbLogger";
            this.rtbLogger.Size = new System.Drawing.Size(274, 227);
            this.rtbLogger.TabIndex = 4;
            this.rtbLogger.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtFriendlyName);
            this.groupBox2.Controls.Add(this.nudMaxDays);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.nudMaxScrape);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.btnQuickScrape);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnMultilineAdd);
            this.groupBox2.Controls.Add(this.txtURI);
            this.groupBox2.ForeColor = System.Drawing.Color.Lime;
            this.groupBox2.Location = new System.Drawing.Point(12, 182);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 357);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scrape Item";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Friendly Name";
            // 
            // txtFriendlyName
            // 
            this.txtFriendlyName.BackColor = System.Drawing.Color.Black;
            this.txtFriendlyName.ForeColor = System.Drawing.Color.Lime;
            this.txtFriendlyName.Location = new System.Drawing.Point(6, 81);
            this.txtFriendlyName.Name = "txtFriendlyName";
            this.txtFriendlyName.Size = new System.Drawing.Size(261, 23);
            this.txtFriendlyName.TabIndex = 14;
            // 
            // nudMaxDays
            // 
            this.nudMaxDays.BackColor = System.Drawing.Color.Black;
            this.nudMaxDays.ForeColor = System.Drawing.Color.Lime;
            this.nudMaxDays.Location = new System.Drawing.Point(147, 163);
            this.nudMaxDays.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nudMaxDays.Name = "nudMaxDays";
            this.nudMaxDays.Size = new System.Drawing.Size(120, 23);
            this.nudMaxDays.TabIndex = 13;
            this.nudMaxDays.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(147, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Days Between Scrapes";
            // 
            // nudMaxScrape
            // 
            this.nudMaxScrape.BackColor = System.Drawing.Color.Black;
            this.nudMaxScrape.ForeColor = System.Drawing.Color.Lime;
            this.nudMaxScrape.Location = new System.Drawing.Point(5, 163);
            this.nudMaxScrape.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudMaxScrape.Name = "nudMaxScrape";
            this.nudMaxScrape.Size = new System.Drawing.Size(120, 23);
            this.nudMaxScrape.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Scrape Maximum";
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.Black;
            this.btnRemove.ForeColor = System.Drawing.Color.Lime;
            this.btnRemove.Location = new System.Drawing.Point(5, 119);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(84, 23);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnQuickScrape
            // 
            this.btnQuickScrape.BackColor = System.Drawing.Color.Black;
            this.btnQuickScrape.ForeColor = System.Drawing.Color.Lime;
            this.btnQuickScrape.Location = new System.Drawing.Point(181, 119);
            this.btnQuickScrape.Name = "btnQuickScrape";
            this.btnQuickScrape.Size = new System.Drawing.Size(86, 23);
            this.btnQuickScrape.TabIndex = 7;
            this.btnQuickScrape.Text = "Scrape Once";
            this.btnQuickScrape.UseVisualStyleBackColor = false;
            this.btnQuickScrape.Click += new System.EventHandler(this.btnQuickScrape_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "URI";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.ForeColor = System.Drawing.Color.Lime;
            this.btnSave.Location = new System.Drawing.Point(95, 119);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Add/Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnMultilineAdd
            // 
            this.btnMultilineAdd.BackColor = System.Drawing.Color.Black;
            this.btnMultilineAdd.ForeColor = System.Drawing.Color.Lime;
            this.btnMultilineAdd.Location = new System.Drawing.Point(235, 37);
            this.btnMultilineAdd.Name = "btnMultilineAdd";
            this.btnMultilineAdd.Size = new System.Drawing.Size(33, 23);
            this.btnMultilineAdd.TabIndex = 4;
            this.btnMultilineAdd.Text = "...";
            this.btnMultilineAdd.UseVisualStyleBackColor = false;
            this.btnMultilineAdd.Click += new System.EventHandler(this.btnMultilineAdd_Click);
            // 
            // txtURI
            // 
            this.txtURI.BackColor = System.Drawing.Color.Black;
            this.txtURI.ForeColor = System.Drawing.Color.Lime;
            this.txtURI.Location = new System.Drawing.Point(6, 37);
            this.txtURI.Name = "txtURI";
            this.txtURI.Size = new System.Drawing.Size(223, 23);
            this.txtURI.TabIndex = 0;
            // 
            // UnifiedUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1640, 784);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.rtbLogger);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.mainList);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.LightGray;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UnifiedUI";
            this.Text = "UnifiedUI";
            this.Load += new System.EventHandler(this.UnifiedUI_Load);
            this.Click += new System.EventHandler(this.UnifiedUI_Click);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxScrape)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView mainList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStartScraper;
        private System.Windows.Forms.Button btnStopScraper;
        private System.Windows.Forms.Button btnKillScraper;
        private System.Windows.Forms.Button btnPauseScraper;
        private System.Windows.Forms.RichTextBox rtbLogger;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnMultilineAdd;
        private System.Windows.Forms.TextBox txtURI;
        private System.Windows.Forms.ToolStripMenuItem addMonitoredScrapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem validationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runFullValidationToolStripMenuItem;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnQuickScrape;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.NumericUpDown nudMaxScrape;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudMaxDays;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAutoQueue;
        private System.Windows.Forms.Button btnQueueItems;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button btnClearQueue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFriendlyName;
        private System.Windows.Forms.ToolStripMenuItem validateSelectedToolStripMenuItem;
    }
}