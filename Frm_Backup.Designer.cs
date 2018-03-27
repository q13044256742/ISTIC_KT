namespace 数据采集档案管理系统___课题版
{
    partial class Frm_Backup
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
            this.fbd_Data = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_Start = new System.Windows.Forms.Button();
            this.txt_FilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_SetPath = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(25, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "备份进度";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(25, 131);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(456, 25);
            this.progressBar1.TabIndex = 10;
            // 
            // btn_Start
            // 
            this.btn_Start.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btn_Start.Location = new System.Drawing.Point(211, 193);
            this.btn_Start.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(89, 33);
            this.btn_Start.TabIndex = 9;
            this.btn_Start.Text = "开始备份";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // txt_FilePath
            // 
            this.txt_FilePath.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txt_FilePath.Location = new System.Drawing.Point(25, 53);
            this.txt_FilePath.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.txt_FilePath.Name = "txt_FilePath";
            this.txt_FilePath.Size = new System.Drawing.Size(442, 25);
            this.txt_FilePath.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "数据存放路径";
            // 
            // lbl_SetPath
            // 
            this.lbl_SetPath.AutoSize = true;
            this.lbl_SetPath.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_SetPath.Location = new System.Drawing.Point(467, 58);
            this.lbl_SetPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_SetPath.Name = "lbl_SetPath";
            this.lbl_SetPath.Size = new System.Drawing.Size(21, 19);
            this.lbl_SetPath.TabIndex = 12;
            this.lbl_SetPath.TabStop = true;
            this.lbl_SetPath.Text = "...";
            this.lbl_SetPath.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_SetPath_LinkClicked);
            // 
            // Frm_Backup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 244);
            this.Controls.Add(this.lbl_SetPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.txt_FilePath);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Backup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据备份";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog fbd_Data;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.TextBox txt_FilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lbl_SetPath;
    }
}