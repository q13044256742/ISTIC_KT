namespace 数据采集档案管理系统___课题版
{
    partial class Frm_Print
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
            this.cbo_BKB = new System.Windows.Forms.CheckBox();
            this.cbo_FM = new System.Windows.Forms.CheckBox();
            this.cbo_JNWJ = new System.Windows.Forms.CheckBox();
            this.cbo_PrintSize = new System.Windows.Forms.ComboBox();
            this.cbo_CheckAll = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // cbo_BKB
            // 
            this.cbo_BKB.AutoSize = true;
            this.cbo_BKB.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_BKB.Location = new System.Drawing.Point(46, 23);
            this.cbo_BKB.Name = "cbo_BKB";
            this.cbo_BKB.Size = new System.Drawing.Size(15, 14);
            this.cbo_BKB.TabIndex = 0;
            this.cbo_BKB.UseVisualStyleBackColor = true;
            // 
            // cbo_FM
            // 
            this.cbo_FM.AutoSize = true;
            this.cbo_FM.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_FM.Location = new System.Drawing.Point(46, 66);
            this.cbo_FM.Name = "cbo_FM";
            this.cbo_FM.Size = new System.Drawing.Size(15, 14);
            this.cbo_FM.TabIndex = 1;
            this.cbo_FM.UseVisualStyleBackColor = true;
            // 
            // cbo_JNWJ
            // 
            this.cbo_JNWJ.AutoSize = true;
            this.cbo_JNWJ.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_JNWJ.Location = new System.Drawing.Point(46, 110);
            this.cbo_JNWJ.Name = "cbo_JNWJ";
            this.cbo_JNWJ.Size = new System.Drawing.Size(15, 14);
            this.cbo_JNWJ.TabIndex = 2;
            this.cbo_JNWJ.UseVisualStyleBackColor = true;
            // 
            // cbo_PrintSize
            // 
            this.cbo_PrintSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_PrintSize.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbo_PrintSize.FormattingEnabled = true;
            this.cbo_PrintSize.Location = new System.Drawing.Point(128, 63);
            this.cbo_PrintSize.Name = "cbo_PrintSize";
            this.cbo_PrintSize.Size = new System.Drawing.Size(50, 21);
            this.cbo_PrintSize.TabIndex = 3;
            // 
            // cbo_CheckAll
            // 
            this.cbo_CheckAll.AutoSize = true;
            this.cbo_CheckAll.Location = new System.Drawing.Point(46, 161);
            this.cbo_CheckAll.Name = "cbo_CheckAll";
            this.cbo_CheckAll.Size = new System.Drawing.Size(48, 16);
            this.cbo_CheckAll.TabIndex = 4;
            this.cbo_CheckAll.Text = "全选";
            this.cbo_CheckAll.UseVisualStyleBackColor = true;
            this.cbo_CheckAll.CheckedChanged += new System.EventHandler(this.cbo_CheckAll_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 156);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 27);
            this.button1.TabIndex = 5;
            this.button1.Text = "打印(&P)";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.Location = new System.Drawing.Point(89, 23);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(77, 14);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "卷内备考表";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel2.Location = new System.Drawing.Point(89, 66);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(35, 14);
            this.linkLabel2.TabIndex = 7;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "封面";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel3.Location = new System.Drawing.Point(89, 110);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(91, 14);
            this.linkLabel3.TabIndex = 8;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "卷内文件目录";
            // 
            // Frm_Print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 223);
            this.Controls.Add(this.linkLabel3);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbo_CheckAll);
            this.Controls.Add(this.cbo_PrintSize);
            this.Controls.Add(this.cbo_JNWJ);
            this.Controls.Add(this.cbo_FM);
            this.Controls.Add(this.cbo_BKB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Print";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "打印类型";
            this.Load += new System.EventHandler(this.Frm_Print_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbo_BKB;
        private System.Windows.Forms.CheckBox cbo_FM;
        private System.Windows.Forms.CheckBox cbo_JNWJ;
        private System.Windows.Forms.ComboBox cbo_PrintSize;
        private System.Windows.Forms.CheckBox cbo_CheckAll;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
    }
}