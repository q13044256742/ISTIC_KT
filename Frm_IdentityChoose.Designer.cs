namespace 数据采集档案管理系统___课题版
{
    partial class Frm_IdentityChoose
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
            this.cbo_ChooseIdentity = new System.Windows.Forms.ComboBox();
            this.btn_Sure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(25, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "* 首次登录请先选择您的身份：";
            // 
            // cbo_ChooseIdentity
            // 
            this.cbo_ChooseIdentity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_ChooseIdentity.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_ChooseIdentity.FormattingEnabled = true;
            this.cbo_ChooseIdentity.Location = new System.Drawing.Point(32, 54);
            this.cbo_ChooseIdentity.Name = "cbo_ChooseIdentity";
            this.cbo_ChooseIdentity.Size = new System.Drawing.Size(257, 28);
            this.cbo_ChooseIdentity.TabIndex = 1;
            // 
            // btn_Sure
            // 
            this.btn_Sure.Location = new System.Drawing.Point(123, 113);
            this.btn_Sure.Name = "btn_Sure";
            this.btn_Sure.Size = new System.Drawing.Size(75, 29);
            this.btn_Sure.TabIndex = 2;
            this.btn_Sure.Text = "确定";
            this.btn_Sure.UseVisualStyleBackColor = true;
            this.btn_Sure.Click += new System.EventHandler(this.btn_Sure_Click);
            // 
            // Frm_IdentityChoose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 162);
            this.Controls.Add(this.btn_Sure);
            this.Controls.Add(this.cbo_ChooseIdentity);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_IdentityChoose";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "身份选择";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_IdentityChoose_FormClosing);
            this.Load += new System.EventHandler(this.Frm_IdentityChoose_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_ChooseIdentity;
        private System.Windows.Forms.Button btn_Sure;
    }
}