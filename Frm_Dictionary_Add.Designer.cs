namespace 数据采集档案管理系统___课题版
{
    partial class Frm_Dictionary_Add
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
            this.txt_Sort = new System.Windows.Forms.NumericUpDown();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_Intro = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_Pname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Sort)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Sort
            // 
            this.txt_Sort.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Sort.Location = new System.Drawing.Point(133, 175);
            this.txt_Sort.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Sort.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.txt_Sort.Name = "txt_Sort";
            this.txt_Sort.Size = new System.Drawing.Size(198, 26);
            this.txt_Sort.TabIndex = 34;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(236, 346);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(79, 31);
            this.btn_Save.TabIndex = 32;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_Intro
            // 
            this.txt_Intro.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Intro.Location = new System.Drawing.Point(133, 229);
            this.txt_Intro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Intro.Multiline = true;
            this.txt_Intro.Name = "txt_Intro";
            this.txt_Intro.Size = new System.Drawing.Size(351, 87);
            this.txt_Intro.TabIndex = 31;
            // 
            // txt_name
            // 
            this.txt_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_name.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_name.Location = new System.Drawing.Point(133, 123);
            this.txt_name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(350, 26);
            this.txt_name.TabIndex = 30;
            // 
            // txt_Pname
            // 
            this.txt_Pname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Pname.Enabled = false;
            this.txt_Pname.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Pname.Location = new System.Drawing.Point(133, 23);
            this.txt_Pname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Pname.Name = "txt_Pname";
            this.txt_Pname.ReadOnly = true;
            this.txt_Pname.Size = new System.Drawing.Size(350, 26);
            this.txt_Pname.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(61, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 19);
            this.label5.TabIndex = 28;
            this.label5.Text = "描述：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(61, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 19);
            this.label4.TabIndex = 27;
            this.label4.Text = "排序：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(61, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 19);
            this.label2.TabIndex = 26;
            this.label2.Text = "名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(19, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 25;
            this.label1.Text = "父节点名称：";
            // 
            // txt_code
            // 
            this.txt_code.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_code.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_code.Location = new System.Drawing.Point(133, 72);
            this.txt_code.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(350, 26);
            this.txt_code.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(61, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 19);
            this.label3.TabIndex = 35;
            this.label3.Text = "编号：";
            // 
            // Frm_Dictionary_Add
            // 
            this.AcceptButton = this.btn_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 391);
            this.Controls.Add(this.txt_code);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Sort);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_Intro);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.txt_Pname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Dictionary_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑字典值";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Dictionary_Add_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.txt_Sort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown txt_Sort;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txt_Intro;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_Pname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Label label3;
    }
}