﻿namespace DataHoarder_DL
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_top = new System.Windows.Forms.Panel();
            this.button_memorytest = new System.Windows.Forms.Button();
            this.label_strfilter = new System.Windows.Forms.Label();
            this.textBox_strfilter = new System.Windows.Forms.TextBox();
            this.button_load = new System.Windows.Forms.Button();
            this.textBox_sort = new System.Windows.Forms.TextBox();
            this.textBox_filter = new System.Windows.Forms.TextBox();
            this.label_sort = new System.Windows.Forms.Label();
            this.label_filter = new System.Windows.Forms.Label();
            this.panel_search = new System.Windows.Forms.Panel();
            this.advancedDataGridViewSearchToolBar_main = new Zuby.ADGV.AdvancedDataGridViewSearchToolBar();
            this.button_unloadfilters = new System.Windows.Forms.Button();
            this.label_sortsaved = new System.Windows.Forms.Label();
            this.label_filtersaved = new System.Windows.Forms.Label();
            this.comboBox_sortsaved = new System.Windows.Forms.ComboBox();
            this.button_setsavedfilter = new System.Windows.Forms.Button();
            this.button_savefilters = new System.Windows.Forms.Button();
            this.comboBox_filtersaved = new System.Windows.Forms.ComboBox();
            this.label_total = new System.Windows.Forms.Label();
            this.textBox_total = new System.Windows.Forms.TextBox();
            this.panel_grid = new System.Windows.Forms.Panel();
            this.advancedDataGridView_main = new Zuby.ADGV.AdvancedDataGridView();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.bindingSource_main = new System.Windows.Forms.BindingSource(this.components);
            this.statusStrip_main = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_memory = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel_top.SuspendLayout();
            this.panel_search.SuspendLayout();
            this.panel_grid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).BeginInit();
            this.panel_bottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).BeginInit();
            this.statusStrip_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.button_memorytest);
            this.panel_top.Controls.Add(this.label_strfilter);
            this.panel_top.Controls.Add(this.textBox_strfilter);
            this.panel_top.Controls.Add(this.button_load);
            this.panel_top.Controls.Add(this.textBox_sort);
            this.panel_top.Controls.Add(this.textBox_filter);
            this.panel_top.Controls.Add(this.label_sort);
            this.panel_top.Controls.Add(this.label_filter);
            this.panel_top.Controls.Add(this.panel_search);
            this.panel_top.Controls.Add(this.button_unloadfilters);
            this.panel_top.Controls.Add(this.label_sortsaved);
            this.panel_top.Controls.Add(this.label_filtersaved);
            this.panel_top.Controls.Add(this.comboBox_sortsaved);
            this.panel_top.Controls.Add(this.button_setsavedfilter);
            this.panel_top.Controls.Add(this.button_savefilters);
            this.panel_top.Controls.Add(this.comboBox_filtersaved);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(1211, 222);
            this.panel_top.TabIndex = 0;
            // 
            // button_memorytest
            // 
            this.button_memorytest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_memorytest.Location = new System.Drawing.Point(460, 12);
            this.button_memorytest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_memorytest.Name = "button_memorytest";
            this.button_memorytest.Size = new System.Drawing.Size(117, 27);
            this.button_memorytest.TabIndex = 20;
            this.button_memorytest.Text = "Memory Test";
            this.button_memorytest.UseVisualStyleBackColor = true;
            // 
            // label_strfilter
            // 
            this.label_strfilter.AutoSize = true;
            this.label_strfilter.Location = new System.Drawing.Point(14, 163);
            this.label_strfilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_strfilter.Name = "label_strfilter";
            this.label_strfilter.Size = new System.Drawing.Size(123, 15);
            this.label_strfilter.TabIndex = 19;
            this.label_strfilter.Text = "Filter column \"string\":";
            // 
            // textBox_strfilter
            // 
            this.textBox_strfilter.Location = new System.Drawing.Point(146, 159);
            this.textBox_strfilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_strfilter.Name = "textBox_strfilter";
            this.textBox_strfilter.Size = new System.Drawing.Size(116, 23);
            this.textBox_strfilter.TabIndex = 18;
            this.textBox_strfilter.TextChanged += new System.EventHandler(this.textBox_strfilter_TextChanged);
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(18, 12);
            this.button_load.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(140, 27);
            this.button_load.TabIndex = 17;
            this.button_load.Text = "Load Random Data";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // textBox_sort
            // 
            this.textBox_sort.Location = new System.Drawing.Point(234, 60);
            this.textBox_sort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_sort.Multiline = true;
            this.textBox_sort.Name = "textBox_sort";
            this.textBox_sort.ReadOnly = true;
            this.textBox_sort.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_sort.Size = new System.Drawing.Size(209, 92);
            this.textBox_sort.TabIndex = 14;
            // 
            // textBox_filter
            // 
            this.textBox_filter.Location = new System.Drawing.Point(18, 60);
            this.textBox_filter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_filter.Multiline = true;
            this.textBox_filter.Name = "textBox_filter";
            this.textBox_filter.ReadOnly = true;
            this.textBox_filter.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_filter.Size = new System.Drawing.Size(209, 92);
            this.textBox_filter.TabIndex = 13;
            // 
            // label_sort
            // 
            this.label_sort.AutoSize = true;
            this.label_sort.Location = new System.Drawing.Point(231, 42);
            this.label_sort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_sort.Name = "label_sort";
            this.label_sort.Size = new System.Drawing.Size(64, 15);
            this.label_sort.TabIndex = 12;
            this.label_sort.Text = "Sort string:";
            // 
            // label_filter
            // 
            this.label_filter.AutoSize = true;
            this.label_filter.Location = new System.Drawing.Point(14, 42);
            this.label_filter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_filter.Name = "label_filter";
            this.label_filter.Size = new System.Drawing.Size(69, 15);
            this.label_filter.TabIndex = 11;
            this.label_filter.Text = "Filter string:";
            // 
            // panel_search
            // 
            this.panel_search.Controls.Add(this.advancedDataGridViewSearchToolBar_main);
            this.panel_search.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_search.Location = new System.Drawing.Point(0, 190);
            this.panel_search.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel_search.Name = "panel_search";
            this.panel_search.Size = new System.Drawing.Size(1211, 32);
            this.panel_search.TabIndex = 10;
            // 
            // advancedDataGridViewSearchToolBar_main
            // 
            this.advancedDataGridViewSearchToolBar_main.AllowMerge = false;
            this.advancedDataGridViewSearchToolBar_main.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.advancedDataGridViewSearchToolBar_main.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridViewSearchToolBar_main.MaximumSize = new System.Drawing.Size(0, 31);
            this.advancedDataGridViewSearchToolBar_main.MinimumSize = new System.Drawing.Size(0, 31);
            this.advancedDataGridViewSearchToolBar_main.Name = "advancedDataGridViewSearchToolBar_main";
            this.advancedDataGridViewSearchToolBar_main.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.advancedDataGridViewSearchToolBar_main.Size = new System.Drawing.Size(1211, 31);
            this.advancedDataGridViewSearchToolBar_main.TabIndex = 0;
            this.advancedDataGridViewSearchToolBar_main.Text = "advancedDataGridViewSearchToolBar_main";
            this.advancedDataGridViewSearchToolBar_main.Search += new Zuby.ADGV.AdvancedDataGridViewSearchToolBarSearchEventHandler(this.advancedDataGridViewSearchToolBar_main_Search);
            // 
            // button_unloadfilters
            // 
            this.button_unloadfilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_unloadfilters.Location = new System.Drawing.Point(792, 43);
            this.button_unloadfilters.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_unloadfilters.Name = "button_unloadfilters";
            this.button_unloadfilters.Size = new System.Drawing.Size(175, 27);
            this.button_unloadfilters.TabIndex = 9;
            this.button_unloadfilters.Text = "Clean Filter And Sort";
            this.button_unloadfilters.UseVisualStyleBackColor = true;
            this.button_unloadfilters.Click += new System.EventHandler(this.button_unloadfilters_Click);
            // 
            // label_sortsaved
            // 
            this.label_sortsaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_sortsaved.AutoSize = true;
            this.label_sortsaved.Location = new System.Drawing.Point(981, 48);
            this.label_sortsaved.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_sortsaved.Name = "label_sortsaved";
            this.label_sortsaved.Size = new System.Drawing.Size(64, 15);
            this.label_sortsaved.TabIndex = 8;
            this.label_sortsaved.Text = "Sort saved:";
            // 
            // label_filtersaved
            // 
            this.label_filtersaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_filtersaved.AutoSize = true;
            this.label_filtersaved.Location = new System.Drawing.Point(977, 17);
            this.label_filtersaved.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_filtersaved.Name = "label_filtersaved";
            this.label_filtersaved.Size = new System.Drawing.Size(69, 15);
            this.label_filtersaved.TabIndex = 7;
            this.label_filtersaved.Text = "Filter saved:";
            // 
            // comboBox_sortsaved
            // 
            this.comboBox_sortsaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_sortsaved.FormattingEnabled = true;
            this.comboBox_sortsaved.Location = new System.Drawing.Point(1056, 45);
            this.comboBox_sortsaved.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox_sortsaved.Name = "comboBox_sortsaved";
            this.comboBox_sortsaved.Size = new System.Drawing.Size(140, 23);
            this.comboBox_sortsaved.TabIndex = 6;
            // 
            // button_setsavedfilter
            // 
            this.button_setsavedfilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_setsavedfilter.Location = new System.Drawing.Point(1109, 76);
            this.button_setsavedfilter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_setsavedfilter.Name = "button_setsavedfilter";
            this.button_setsavedfilter.Size = new System.Drawing.Size(88, 27);
            this.button_setsavedfilter.TabIndex = 5;
            this.button_setsavedfilter.Text = "Apply";
            this.button_setsavedfilter.UseVisualStyleBackColor = true;
            this.button_setsavedfilter.Click += new System.EventHandler(this.button_setsavedfilter_Click);
            // 
            // button_savefilters
            // 
            this.button_savefilters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_savefilters.Location = new System.Drawing.Point(792, 12);
            this.button_savefilters.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button_savefilters.Name = "button_savefilters";
            this.button_savefilters.Size = new System.Drawing.Size(175, 27);
            this.button_savefilters.TabIndex = 3;
            this.button_savefilters.Text = "Save Current Filter And Sort";
            this.button_savefilters.UseVisualStyleBackColor = true;
            this.button_savefilters.Click += new System.EventHandler(this.button_savefilters_Click);
            // 
            // comboBox_filtersaved
            // 
            this.comboBox_filtersaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_filtersaved.FormattingEnabled = true;
            this.comboBox_filtersaved.Location = new System.Drawing.Point(1056, 14);
            this.comboBox_filtersaved.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboBox_filtersaved.Name = "comboBox_filtersaved";
            this.comboBox_filtersaved.Size = new System.Drawing.Size(140, 23);
            this.comboBox_filtersaved.TabIndex = 2;
            // 
            // label_total
            // 
            this.label_total.AutoSize = true;
            this.label_total.Location = new System.Drawing.Point(14, 14);
            this.label_total.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_total.Name = "label_total";
            this.label_total.Size = new System.Drawing.Size(63, 15);
            this.label_total.TabIndex = 16;
            this.label_total.Text = "Total rows:";
            // 
            // textBox_total
            // 
            this.textBox_total.Location = new System.Drawing.Point(90, 10);
            this.textBox_total.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_total.Name = "textBox_total";
            this.textBox_total.ReadOnly = true;
            this.textBox_total.Size = new System.Drawing.Size(81, 23);
            this.textBox_total.TabIndex = 15;
            // 
            // panel_grid
            // 
            this.panel_grid.Controls.Add(this.advancedDataGridView_main);
            this.panel_grid.Controls.Add(this.panel_bottom);
            this.panel_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_grid.Location = new System.Drawing.Point(0, 222);
            this.panel_grid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel_grid.Name = "panel_grid";
            this.panel_grid.Size = new System.Drawing.Size(1211, 431);
            this.panel_grid.TabIndex = 1;
            // 
            // advancedDataGridView_main
            // 
            this.advancedDataGridView_main.AllowUserToAddRows = false;
            this.advancedDataGridView_main.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.advancedDataGridView_main.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.advancedDataGridView_main.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.advancedDataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advancedDataGridView_main.FilterAndSortEnabled = true;
            this.advancedDataGridView_main.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView_main.Location = new System.Drawing.Point(0, 0);
            this.advancedDataGridView_main.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.advancedDataGridView_main.Name = "advancedDataGridView_main";
            this.advancedDataGridView_main.ReadOnly = true;
            this.advancedDataGridView_main.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView_main.RowHeadersVisible = false;
            this.advancedDataGridView_main.Size = new System.Drawing.Size(1211, 392);
            this.advancedDataGridView_main.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            this.advancedDataGridView_main.TabIndex = 0;
            this.advancedDataGridView_main.SortStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.SortEventArgs>(this.advancedDataGridView_main_SortStringChanged);
            this.advancedDataGridView_main.FilterStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.FilterEventArgs>(this.advancedDataGridView_main_FilterStringChanged);
            // 
            // panel_bottom
            // 
            this.panel_bottom.Controls.Add(this.textBox_total);
            this.panel_bottom.Controls.Add(this.label_total);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(0, 392);
            this.panel_bottom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(1211, 39);
            this.panel_bottom.TabIndex = 2;
            // 
            // bindingSource_main
            // 
            this.bindingSource_main.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bindingSource_main_ListChanged);
            // 
            // statusStrip_main
            // 
            this.statusStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_memory});
            this.statusStrip_main.Location = new System.Drawing.Point(0, 653);
            this.statusStrip_main.Name = "statusStrip_main";
            this.statusStrip_main.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip_main.Size = new System.Drawing.Size(1211, 22);
            this.statusStrip_main.TabIndex = 2;
            this.statusStrip_main.Text = "statusStrip1";
            // 
            // toolStripStatusLabel_memory
            // 
            this.toolStripStatusLabel_memory.Name = "toolStripStatusLabel_memory";
            this.toolStripStatusLabel_memory.Size = new System.Drawing.Size(116, 17);
            this.toolStripStatusLabel_memory.Text = "Memory Usage: /Mb";
            // 
            // UnifiedUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1211, 675);
            this.Controls.Add(this.panel_grid);
            this.Controls.Add(this.statusStrip_main);
            this.Controls.Add(this.panel_top);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(931, 571);
            this.Name = "UnifiedUI";
            this.Text = "AdvancedDataGridView Sample";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel_top.ResumeLayout(false);
            this.panel_top.PerformLayout();
            this.panel_search.ResumeLayout(false);
            this.panel_search.PerformLayout();
            this.panel_grid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_main)).EndInit();
            this.panel_bottom.ResumeLayout(false);
            this.panel_bottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_main)).EndInit();
            this.statusStrip_main.ResumeLayout(false);
            this.statusStrip_main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel_grid;
        private System.Windows.Forms.BindingSource bindingSource_main;
        private System.Windows.Forms.Button button_savefilters;
        private System.Windows.Forms.ComboBox comboBox_filtersaved;
        private System.Windows.Forms.Button button_setsavedfilter;
        private System.Windows.Forms.Label label_sortsaved;
        private System.Windows.Forms.Label label_filtersaved;
        private System.Windows.Forms.ComboBox comboBox_sortsaved;
        private System.Windows.Forms.Button button_unloadfilters;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_main;
        private System.Windows.Forms.Panel panel_search;
        private Zuby.ADGV.AdvancedDataGridViewSearchToolBar advancedDataGridViewSearchToolBar_main;
        private System.Windows.Forms.Label label_total;
        private System.Windows.Forms.TextBox textBox_total;
        private System.Windows.Forms.TextBox textBox_sort;
        private System.Windows.Forms.TextBox textBox_filter;
        private System.Windows.Forms.Label label_sort;
        private System.Windows.Forms.Label label_filter;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Label label_strfilter;
        private System.Windows.Forms.TextBox textBox_strfilter;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.StatusStrip statusStrip_main;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_memory;
        private System.Windows.Forms.Button button_memorytest;
    }
}

