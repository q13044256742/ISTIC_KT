namespace 数据采集档案管理系统___课题版
{
    partial class Frm_Export
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
            this.btn_Export = new System.Windows.Forms.Button();
            this.txt_ExportPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_ExportPath = new System.Windows.Forms.LinkLabel();
            this.pic_Wait = new System.Windows.Forms.PictureBox();
            this.gro_YiJiao = new System.Windows.Forms.GroupBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.lsv_DataList = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gro_GuiDang = new System.Windows.Forms.GroupBox();
            this.lbl_GuiDangPro = new System.Windows.Forms.Label();
            this.btn_GuiDang = new System.Windows.Forms.Button();
            this.pro_GuiDang = new System.Windows.Forms.ProgressBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Wait)).BeginInit();
            this.gro_YiJiao.SuspendLayout();
            this.gro_GuiDang.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Export
            // 
            this.btn_Export.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.btn_Export.Location = new System.Drawing.Point(311, 389);
            this.btn_Export.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(71, 30);
            this.btn_Export.TabIndex = 5;
            this.btn_Export.Text = "移交(&Y)";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.Btn_Export_Click);
            // 
            // txt_ExportPath
            // 
            this.txt_ExportPath.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txt_ExportPath.Location = new System.Drawing.Point(12, 340);
            this.txt_ExportPath.Name = "txt_ExportPath";
            this.txt_ExportPath.Size = new System.Drawing.Size(706, 27);
            this.txt_ExportPath.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 316);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "档案移交路径：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(8, 36);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "选择待导出项目/课题：";
            // 
            // lbl_ExportPath
            // 
            this.lbl_ExportPath.AutoSize = true;
            this.lbl_ExportPath.Location = new System.Drawing.Point(724, 341);
            this.lbl_ExportPath.Name = "lbl_ExportPath";
            this.lbl_ExportPath.Size = new System.Drawing.Size(22, 24);
            this.lbl_ExportPath.TabIndex = 11;
            this.lbl_ExportPath.TabStop = true;
            this.lbl_ExportPath.Text = "...";
            this.lbl_ExportPath.Click += new System.EventHandler(this.lbl_ExportPath_Click);
            // 
            // pic_Wait
            // 
            this.pic_Wait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_Wait.Image = global::数据采集档案管理系统___课题版.Properties.Resources.wait;
            this.pic_Wait.Location = new System.Drawing.Point(370, 200);
            this.pic_Wait.Name = "pic_Wait";
            this.pic_Wait.Size = new System.Drawing.Size(34, 34);
            this.pic_Wait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pic_Wait.TabIndex = 13;
            this.pic_Wait.TabStop = false;
            this.pic_Wait.Visible = false;
            // 
            // gro_YiJiao
            // 
            this.gro_YiJiao.Controls.Add(this.checkBox1);
            this.gro_YiJiao.Controls.Add(this.btn_Close);
            this.gro_YiJiao.Controls.Add(this.pic_Wait);
            this.gro_YiJiao.Controls.Add(this.lsv_DataList);
            this.gro_YiJiao.Controls.Add(this.label4);
            this.gro_YiJiao.Controls.Add(this.btn_Export);
            this.gro_YiJiao.Controls.Add(this.txt_ExportPath);
            this.gro_YiJiao.Controls.Add(this.lbl_ExportPath);
            this.gro_YiJiao.Controls.Add(this.label1);
            this.gro_YiJiao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gro_YiJiao.Enabled = false;
            this.gro_YiJiao.Location = new System.Drawing.Point(0, 93);
            this.gro_YiJiao.Name = "gro_YiJiao";
            this.gro_YiJiao.Size = new System.Drawing.Size(775, 435);
            this.gro_YiJiao.TabIndex = 14;
            this.gro_YiJiao.TabStop = false;
            this.gro_YiJiao.Text = "档案移交";
            // 
            // btn_Close
            // 
            this.btn_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Close.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.btn_Close.Location = new System.Drawing.Point(392, 389);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(71, 30);
            this.btn_Close.TabIndex = 14;
            this.btn_Close.Text = "关闭(&C)";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // lsv_DataList
            // 
            this.lsv_DataList.CheckBoxes = true;
            this.lsv_DataList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4});
            this.lsv_DataList.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.lsv_DataList.FullRowSelect = true;
            this.lsv_DataList.GridLines = true;
            this.lsv_DataList.Location = new System.Drawing.Point(12, 62);
            this.lsv_DataList.Name = "lsv_DataList";
            this.lsv_DataList.Size = new System.Drawing.Size(747, 237);
            this.lsv_DataList.TabIndex = 0;
            this.lsv_DataList.UseCompatibleStateImageBehavior = false;
            this.lsv_DataList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "编号";
            this.columnHeader3.Width = 191;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "上次移交时间";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 160;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "是否更新";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 100;
            // 
            // gro_GuiDang
            // 
            this.gro_GuiDang.Controls.Add(this.lbl_GuiDangPro);
            this.gro_GuiDang.Controls.Add(this.btn_GuiDang);
            this.gro_GuiDang.Controls.Add(this.pro_GuiDang);
            this.gro_GuiDang.Dock = System.Windows.Forms.DockStyle.Top;
            this.gro_GuiDang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gro_GuiDang.Location = new System.Drawing.Point(0, 0);
            this.gro_GuiDang.Name = "gro_GuiDang";
            this.gro_GuiDang.Size = new System.Drawing.Size(775, 93);
            this.gro_GuiDang.TabIndex = 15;
            this.gro_GuiDang.TabStop = false;
            this.gro_GuiDang.Text = "数据归档";
            // 
            // lbl_GuiDangPro
            // 
            this.lbl_GuiDangPro.AutoSize = true;
            this.lbl_GuiDangPro.BackColor = System.Drawing.Color.Transparent;
            this.lbl_GuiDangPro.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_GuiDangPro.Location = new System.Drawing.Point(8, 28);
            this.lbl_GuiDangPro.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_GuiDangPro.Name = "lbl_GuiDangPro";
            this.lbl_GuiDangPro.Size = new System.Drawing.Size(161, 19);
            this.lbl_GuiDangPro.TabIndex = 10;
            this.lbl_GuiDangPro.Text = "当前归档进度（0 %）：";
            // 
            // btn_GuiDang
            // 
            this.btn_GuiDang.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.btn_GuiDang.Location = new System.Drawing.Point(675, 53);
            this.btn_GuiDang.Name = "btn_GuiDang";
            this.btn_GuiDang.Size = new System.Drawing.Size(78, 31);
            this.btn_GuiDang.TabIndex = 1;
            this.btn_GuiDang.Text = "归档(&G)";
            this.btn_GuiDang.UseVisualStyleBackColor = true;
            this.btn_GuiDang.Click += new System.EventHandler(this.Btn_GuiDang_Click);
            // 
            // pro_GuiDang
            // 
            this.pro_GuiDang.Location = new System.Drawing.Point(12, 53);
            this.pro_GuiDang.Name = "pro_GuiDang";
            this.pro_GuiDang.Size = new System.Drawing.Size(657, 30);
            this.pro_GuiDang.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.checkBox1.Location = new System.Drawing.Point(701, 32);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(58, 24);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "全选";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Frm_Export
            // 
            this.AcceptButton = this.btn_Export;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_Close;
            this.ClientSize = new System.Drawing.Size(775, 528);
            this.Controls.Add(this.gro_YiJiao);
            this.Controls.Add(this.gro_GuiDang);
            this.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Export";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "归档移交";
            ((System.ComponentModel.ISupportInitialize)(this.pic_Wait)).EndInit();
            this.gro_YiJiao.ResumeLayout(false);
            this.gro_YiJiao.PerformLayout();
            this.gro_GuiDang.ResumeLayout(false);
            this.gro_GuiDang.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.TextBox txt_ExportPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel lbl_ExportPath;
        private System.Windows.Forms.PictureBox pic_Wait;
        private System.Windows.Forms.GroupBox gro_YiJiao;
        private System.Windows.Forms.GroupBox gro_GuiDang;
        private System.Windows.Forms.ListView lsv_DataList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btn_GuiDang;
        private System.Windows.Forms.ProgressBar pro_GuiDang;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label lbl_GuiDangPro;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}