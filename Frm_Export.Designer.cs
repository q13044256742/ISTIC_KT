﻿namespace 数据采集档案管理系统___课题版
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
            this.label2 = new System.Windows.Forms.Label();
            this.pro_Show = new System.Windows.Forms.ProgressBar();
            this.btn_Export = new System.Windows.Forms.Button();
            this.txt_ExportPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_TopicId = new System.Windows.Forms.ComboBox();
            this.lbl_ExportPath = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(23, 188);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "当前进度：";
            // 
            // pro_Show
            // 
            this.pro_Show.Location = new System.Drawing.Point(23, 219);
            this.pro_Show.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pro_Show.Name = "pro_Show";
            this.pro_Show.Size = new System.Drawing.Size(439, 24);
            this.pro_Show.TabIndex = 4;
            // 
            // btn_Export
            // 
            this.btn_Export.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btn_Export.Location = new System.Drawing.Point(204, 272);
            this.btn_Export.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(76, 31);
            this.btn_Export.TabIndex = 5;
            this.btn_Export.Text = "开始";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // txt_ExportPath
            // 
            this.txt_ExportPath.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.txt_ExportPath.Location = new System.Drawing.Point(23, 131);
            this.txt_ExportPath.Name = "txt_ExportPath";
            this.txt_ExportPath.Size = new System.Drawing.Size(408, 27);
            this.txt_ExportPath.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(23, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "导出路径：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(23, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 19);
            this.label4.TabIndex = 9;
            this.label4.Text = "选择待导出项目/课题：";
            // 
            // cbo_TopicId
            // 
            this.cbo_TopicId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_TopicId.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.cbo_TopicId.FormattingEnabled = true;
            this.cbo_TopicId.Location = new System.Drawing.Point(23, 47);
            this.cbo_TopicId.Name = "cbo_TopicId";
            this.cbo_TopicId.Size = new System.Drawing.Size(439, 28);
            this.cbo_TopicId.TabIndex = 10;
            // 
            // lbl_ExportPath
            // 
            this.lbl_ExportPath.AutoSize = true;
            this.lbl_ExportPath.Location = new System.Drawing.Point(440, 134);
            this.lbl_ExportPath.Name = "lbl_ExportPath";
            this.lbl_ExportPath.Size = new System.Drawing.Size(22, 24);
            this.lbl_ExportPath.TabIndex = 11;
            this.lbl_ExportPath.TabStop = true;
            this.lbl_ExportPath.Text = "...";
            this.lbl_ExportPath.Click += new System.EventHandler(this.lbl_ExportPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(96, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "(此路径为空时则只归档)";
            // 
            // Frm_Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 321);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_ExportPath);
            this.Controls.Add(this.cbo_TopicId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ExportPath);
            this.Controls.Add(this.btn_Export);
            this.Controls.Add(this.pro_Show);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Export";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "归档移交";
            this.Load += new System.EventHandler(this.Frm_Export_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pro_Show;
        private System.Windows.Forms.Button btn_Export;
        private System.Windows.Forms.TextBox txt_ExportPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbo_TopicId;
        private System.Windows.Forms.LinkLabel lbl_ExportPath;
        private System.Windows.Forms.Label label3;
    }
}