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
            this.label2 = new System.Windows.Forms.Label();
            this.pro_Show = new System.Windows.Forms.ProgressBar();
            this.btn_Export = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(17, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "当前进度：";
            // 
            // pro_Show
            // 
            this.pro_Show.Location = new System.Drawing.Point(21, 53);
            this.pro_Show.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.pro_Show.Name = "pro_Show";
            this.pro_Show.Size = new System.Drawing.Size(439, 24);
            this.pro_Show.TabIndex = 4;
            // 
            // btn_Export
            // 
            this.btn_Export.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btn_Export.Location = new System.Drawing.Point(195, 115);
            this.btn_Export.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(95, 33);
            this.btn_Export.TabIndex = 5;
            this.btn_Export.Text = "开始导出";
            this.btn_Export.UseVisualStyleBackColor = true;
            this.btn_Export.Click += new System.EventHandler(this.btn_Export_Click);
            // 
            // Frm_Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 166);
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
            this.Text = "数据移交";
            this.Load += new System.EventHandler(this.Frm_Export_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar pro_Show;
        private System.Windows.Forms.Button btn_Export;
    }
}