namespace 数据采集档案管理系统___课题版
{
    partial class Frm_ExportList
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
            if(disposing && (components != null))
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
            this.chk_DocumentList = new System.Windows.Forms.CheckBox();
            this.chk_TotalTable = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Path = new System.Windows.Forms.TextBox();
            this.lbl_SelectPath = new System.Windows.Forms.LinkLabel();
            this.btn_Sure = new System.Windows.Forms.Button();
            this.pic_Wait = new System.Windows.Forms.PictureBox();
            this.chk_LostFileList = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Wait)).BeginInit();
            this.SuspendLayout();
            // 
            // chk_DocumentList
            // 
            this.chk_DocumentList.AutoSize = true;
            this.chk_DocumentList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chk_DocumentList.Location = new System.Drawing.Point(48, 55);
            this.chk_DocumentList.Name = "chk_DocumentList";
            this.chk_DocumentList.Size = new System.Drawing.Size(84, 24);
            this.chk_DocumentList.TabIndex = 0;
            this.chk_DocumentList.Text = "档案清单";
            this.chk_DocumentList.UseVisualStyleBackColor = true;
            // 
            // chk_TotalTable
            // 
            this.chk_TotalTable.AutoSize = true;
            this.chk_TotalTable.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chk_TotalTable.Location = new System.Drawing.Point(202, 55);
            this.chk_TotalTable.Name = "chk_TotalTable";
            this.chk_TotalTable.Size = new System.Drawing.Size(70, 24);
            this.chk_TotalTable.TabIndex = 1;
            this.chk_TotalTable.Text = "汇总表";
            this.chk_TotalTable.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "导出路径：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "导出类型：";
            // 
            // txt_Path
            // 
            this.txt_Path.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Path.Location = new System.Drawing.Point(48, 139);
            this.txt_Path.Name = "txt_Path";
            this.txt_Path.Size = new System.Drawing.Size(357, 26);
            this.txt_Path.TabIndex = 4;
            // 
            // lbl_SelectPath
            // 
            this.lbl_SelectPath.AutoSize = true;
            this.lbl_SelectPath.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_SelectPath.Location = new System.Drawing.Point(411, 144);
            this.lbl_SelectPath.Name = "lbl_SelectPath";
            this.lbl_SelectPath.Size = new System.Drawing.Size(21, 19);
            this.lbl_SelectPath.TabIndex = 5;
            this.lbl_SelectPath.TabStop = true;
            this.lbl_SelectPath.Text = "...";
            this.lbl_SelectPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_SelectPath_LinkClicked);
            // 
            // btn_Sure
            // 
            this.btn_Sure.Location = new System.Drawing.Point(197, 195);
            this.btn_Sure.Name = "btn_Sure";
            this.btn_Sure.Size = new System.Drawing.Size(75, 29);
            this.btn_Sure.TabIndex = 6;
            this.btn_Sure.Text = "确定";
            this.btn_Sure.UseVisualStyleBackColor = true;
            this.btn_Sure.Click += new System.EventHandler(this.btn_Sure_Click);
            // 
            // pic_Wait
            // 
            this.pic_Wait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_Wait.Image = global::数据采集档案管理系统___课题版.Properties.Resources.wait;
            this.pic_Wait.Location = new System.Drawing.Point(218, 93);
            this.pic_Wait.Name = "pic_Wait";
            this.pic_Wait.Size = new System.Drawing.Size(34, 34);
            this.pic_Wait.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pic_Wait.TabIndex = 7;
            this.pic_Wait.TabStop = false;
            this.pic_Wait.Visible = false;
            // 
            // chk_LostFileList
            // 
            this.chk_LostFileList.AutoSize = true;
            this.chk_LostFileList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chk_LostFileList.Location = new System.Drawing.Point(332, 55);
            this.chk_LostFileList.Name = "chk_LostFileList";
            this.chk_LostFileList.Size = new System.Drawing.Size(112, 24);
            this.chk_LostFileList.TabIndex = 8;
            this.chk_LostFileList.Text = "缺失文件清单";
            this.chk_LostFileList.UseVisualStyleBackColor = true;
            // 
            // Frm_ExportList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 245);
            this.Controls.Add(this.chk_LostFileList);
            this.Controls.Add(this.pic_Wait);
            this.Controls.Add(this.btn_Sure);
            this.Controls.Add(this.lbl_SelectPath);
            this.Controls.Add(this.txt_Path);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chk_TotalTable);
            this.Controls.Add(this.chk_DocumentList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ExportList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "档案导出";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ExportList_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Wait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chk_DocumentList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Path;
        private System.Windows.Forms.LinkLabel lbl_SelectPath;
        private System.Windows.Forms.Button btn_Sure;
        private System.Windows.Forms.CheckBox chk_TotalTable;
        private System.Windows.Forms.PictureBox pic_Wait;
        private System.Windows.Forms.CheckBox chk_LostFileList;
    }
}