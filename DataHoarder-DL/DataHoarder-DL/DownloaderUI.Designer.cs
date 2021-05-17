
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
            this.gpbDLSettings = new System.Windows.Forms.GroupBox();
            this.cmbDLSource = new System.Windows.Forms.ComboBox();
            this.btnAddToQueue = new System.Windows.Forms.Button();
            this.txtDLURL = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDLDir
            // 
            this.txtDLDir.Location = new System.Drawing.Point(4, 595);
            this.txtDLDir.Name = "txtDLDir";
            this.txtDLDir.Size = new System.Drawing.Size(394, 23);
            this.txtDLDir.TabIndex = 1;
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
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.gpbDLSettings);
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
            // gpbDLSettings
            // 
            this.gpbDLSettings.Location = new System.Drawing.Point(0, 47);
            this.gpbDLSettings.Name = "gpbDLSettings";
            this.gpbDLSettings.Size = new System.Drawing.Size(1039, 478);
            this.gpbDLSettings.TabIndex = 3;
            this.gpbDLSettings.TabStop = false;
            this.gpbDLSettings.Text = "Download Settings";
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
        private System.Windows.Forms.GroupBox gpbDLSettings;
        private System.Windows.Forms.ComboBox cmbDLSource;
        private System.Windows.Forms.Button btnAddToQueue;
        private System.Windows.Forms.TextBox txtDLURL;
        private System.Windows.Forms.Label label3;
    }
}

