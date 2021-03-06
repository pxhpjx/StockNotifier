﻿namespace StockNotifier
{
    partial class StockNotifier
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockNotifier));
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dgvStocks = new System.Windows.Forms.DataGridView();
            this.niNewData = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.隐藏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbShowBig = new System.Windows.Forms.RadioButton();
            this.rbQuiet = new System.Windows.Forms.RadioButton();
            this.txtInterval = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStocks)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(12, 9);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(102, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "术火/梨凡赠爱";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dgvStocks
            // 
            this.dgvStocks.AllowUserToAddRows = false;
            this.dgvStocks.AllowUserToDeleteRows = false;
            this.dgvStocks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStocks.Location = new System.Drawing.Point(12, 41);
            this.dgvStocks.Name = "dgvStocks";
            this.dgvStocks.ReadOnly = true;
            this.dgvStocks.RowTemplate.Height = 23;
            this.dgvStocks.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvStocks.Size = new System.Drawing.Size(640, 150);
            this.dgvStocks.TabIndex = 1;
            this.dgvStocks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStocks_CellClick);
            // 
            // niNewData
            // 
            this.niNewData.Icon = ((System.Drawing.Icon)(resources.GetObject("niNewData.Icon")));
            this.niNewData.Text = "PP\'s StockNotifier";
            this.niNewData.Visible = true;
            this.niNewData.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.niNewData_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示ToolStripMenuItem,
            this.隐藏ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(129, 92);
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.显示ToolStripMenuItem.Text = "显示";
            this.显示ToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // 隐藏ToolStripMenuItem
            // 
            this.隐藏ToolStripMenuItem.Name = "隐藏ToolStripMenuItem";
            this.隐藏ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.隐藏ToolStripMenuItem.Text = "隐藏";
            this.隐藏ToolStripMenuItem.Click += new System.EventHandler(this.HideToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(128, 22);
            this.toolStripMenuItem2.Text = "————";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.QuitToolStripMenuItem_Click);
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Location = new System.Drawing.Point(320, 12);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(71, 16);
            this.rbNormal.TabIndex = 2;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "普通模式";
            this.rbNormal.UseVisualStyleBackColor = true;
            // 
            // rbShowBig
            // 
            this.rbShowBig.AutoSize = true;
            this.rbShowBig.Checked = true;
            this.rbShowBig.Location = new System.Drawing.Point(397, 12);
            this.rbShowBig.Name = "rbShowBig";
            this.rbShowBig.Size = new System.Drawing.Size(71, 16);
            this.rbShowBig.TabIndex = 3;
            this.rbShowBig.TabStop = true;
            this.rbShowBig.Text = "显示大额";
            this.rbShowBig.UseVisualStyleBackColor = true;
            // 
            // rbQuiet
            // 
            this.rbQuiet.AutoSize = true;
            this.rbQuiet.Location = new System.Drawing.Point(474, 12);
            this.rbQuiet.Name = "rbQuiet";
            this.rbQuiet.Size = new System.Drawing.Size(71, 16);
            this.rbQuiet.TabIndex = 4;
            this.rbQuiet.TabStop = true;
            this.rbQuiet.Text = "安静模式";
            this.rbQuiet.UseVisualStyleBackColor = true;
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(152, 11);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(52, 21);
            this.txtInterval.TabIndex = 5;
            this.txtInterval.Text = "180";
            this.txtInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // StockNotifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 206);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.rbQuiet);
            this.Controls.Add(this.rbShowBig);
            this.Controls.Add(this.rbNormal);
            this.Controls.Add(this.dgvStocks);
            this.Controls.Add(this.btnUpdate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StockNotifier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PP\'s StockNotifier";
            ((System.ComponentModel.ISupportInitialize)(this.dgvStocks)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dgvStocks;
        private System.Windows.Forms.NotifyIcon niNewData;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 隐藏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbShowBig;
        private System.Windows.Forms.RadioButton rbQuiet;
        private System.Windows.Forms.TextBox txtInterval;
    }
}

