namespace 数据采集档案管理系统___课题版
{
    partial class Frm_Import
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_FilePath = new System.Windows.Forms.TextBox();
            this.btn_Import = new System.Windows.Forms.Button();
            this.pro_Show = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.fbd_Data = new System.Windows.Forms.FolderBrowserDialog();
            this.btn_SouPath = new System.Windows.Forms.LinkLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tip = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_TarPath = new System.Windows.Forms.LinkLabel();
            this.txt_TarPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_BatchName = new System.Windows.Forms.ComboBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(20, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "来源路径:";
            // 
            // txt_FilePath
            // 
            this.txt_FilePath.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txt_FilePath.Location = new System.Drawing.Point(20, 113);
            this.txt_FilePath.Margin = new System.Windows.Forms.Padding(5);
            this.txt_FilePath.Name = "txt_FilePath";
            this.txt_FilePath.Size = new System.Drawing.Size(505, 25);
            this.txt_FilePath.TabIndex = 1;
            // 
            // btn_Import
            // 
            this.btn_Import.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Import.Location = new System.Drawing.Point(236, 312);
            this.btn_Import.Margin = new System.Windows.Forms.Padding(5);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(96, 32);
            this.btn_Import.TabIndex = 3;
            this.btn_Import.Text = "开始导入";
            this.btn_Import.UseVisualStyleBackColor = true;
            this.btn_Import.Click += new System.EventHandler(this.btn_Import_Click_1);
            // 
            // pro_Show
            // 
            this.pro_Show.Location = new System.Drawing.Point(20, 262);
            this.pro_Show.Margin = new System.Windows.Forms.Padding(5);
            this.pro_Show.Name = "pro_Show";
            this.pro_Show.Size = new System.Drawing.Size(505, 26);
            this.pro_Show.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(20, 233);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "读取进度:";
            // 
            // btn_SouPath
            // 
            this.btn_SouPath.AutoSize = true;
            this.btn_SouPath.Location = new System.Drawing.Point(533, 113);
            this.btn_SouPath.Name = "btn_SouPath";
            this.btn_SouPath.Size = new System.Drawing.Size(22, 21);
            this.btn_SouPath.TabIndex = 6;
            this.btn_SouPath.TabStop = true;
            this.btn_SouPath.Text = "...";
            this.btn_SouPath.Click += new System.EventHandler(this.Btn_Import_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tip});
            this.statusStrip1.Location = new System.Drawing.Point(0, 355);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(569, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tip
            // 
            this.tip.Name = "tip";
            this.tip.Size = new System.Drawing.Size(0, 17);
            // 
            // btn_TarPath
            // 
            this.btn_TarPath.AutoSize = true;
            this.btn_TarPath.Location = new System.Drawing.Point(533, 189);
            this.btn_TarPath.Name = "btn_TarPath";
            this.btn_TarPath.Size = new System.Drawing.Size(22, 21);
            this.btn_TarPath.TabIndex = 10;
            this.btn_TarPath.TabStop = true;
            this.btn_TarPath.Text = "...";
            this.btn_TarPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btn_TarPath_LinkClicked);
            // 
            // txt_TarPath
            // 
            this.txt_TarPath.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txt_TarPath.Location = new System.Drawing.Point(20, 189);
            this.txt_TarPath.Margin = new System.Windows.Forms.Padding(5);
            this.txt_TarPath.Name = "txt_TarPath";
            this.txt_TarPath.Size = new System.Drawing.Size(505, 25);
            this.txt_TarPath.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(20, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "备份路径:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(97, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(152, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "（此路径设置后不可更改）";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(20, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "批次名称:";
            // 
            // txt_BatchName
            // 
            this.txt_BatchName.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txt_BatchName.Location = new System.Drawing.Point(20, 45);
            this.txt_BatchName.Name = "txt_BatchName";
            this.txt_BatchName.Size = new System.Drawing.Size(505, 27);
            this.txt_BatchName.TabIndex = 14;
            // 
            // Frm_Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 377);
            this.Controls.Add(this.txt_BatchName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_TarPath);
            this.Controls.Add(this.txt_TarPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_SouPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pro_Show);
            this.Controls.Add(this.btn_Import);
            this.Controls.Add(this.txt_FilePath);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Import";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据导入";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Import_FormClosing);
            this.Load += new System.EventHandler(this.Frm_Import_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_FilePath;
        private System.Windows.Forms.Button btn_Import;
        private System.Windows.Forms.ProgressBar pro_Show;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog fbd_Data;
        private System.Windows.Forms.LinkLabel btn_SouPath;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tip;
        private System.Windows.Forms.LinkLabel btn_TarPath;
        private System.Windows.Forms.TextBox txt_TarPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox txt_BatchName;
    }
}