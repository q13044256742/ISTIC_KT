namespace 数据采集档案管理系统___课题版
{
    partial class Frm_AddFile
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
            this.btn_Reset = new System.Windows.Forms.Button();
            this.lbl_OpenFile = new System.Windows.Forms.LinkLabel();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_link = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbo_form = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbo_format = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbo_carrier = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_unit = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtp_date = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.num_amount = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.num_page = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cbo_secret = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.cbo_type = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_fileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_categor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_stage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pal_ShowData = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.num_amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_page)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(204, 535);
            this.btn_Reset.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(71, 33);
            this.btn_Reset.TabIndex = 62;
            this.btn_Reset.Text = "重置";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // lbl_OpenFile
            // 
            this.lbl_OpenFile.AutoSize = true;
            this.lbl_OpenFile.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_OpenFile.Location = new System.Drawing.Point(586, 489);
            this.lbl_OpenFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_OpenFile.Name = "lbl_OpenFile";
            this.lbl_OpenFile.Size = new System.Drawing.Size(28, 14);
            this.lbl_OpenFile.TabIndex = 61;
            this.lbl_OpenFile.TabStop = true;
            this.lbl_OpenFile.Text = "...";
            this.lbl_OpenFile.Click += new System.EventHandler(this.Btn_OpenFile_Click);
            // 
            // btn_Quit
            // 
            this.btn_Quit.Location = new System.Drawing.Point(360, 535);
            this.btn_Quit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(71, 33);
            this.btn_Quit.TabIndex = 55;
            this.btn_Quit.Text = "退出";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(282, 535);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(71, 33);
            this.btn_Save.TabIndex = 53;
            this.btn_Save.Text = "保存";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.Btn_Save_Add_Click);
            // 
            // txt_link
            // 
            this.txt_link.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_link.Location = new System.Drawing.Point(126, 484);
            this.txt_link.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_link.Name = "txt_link";
            this.txt_link.Size = new System.Drawing.Size(451, 23);
            this.txt_link.TabIndex = 51;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(21, 486);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(93, 19);
            this.label14.TabIndex = 60;
            this.label14.Text = "文件地址链接";
            // 
            // cbo_form
            // 
            this.cbo_form.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_form.FormattingEnabled = true;
            this.cbo_form.Location = new System.Drawing.Point(126, 423);
            this.cbo_form.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbo_form.Name = "cbo_form";
            this.cbo_form.Size = new System.Drawing.Size(186, 28);
            this.cbo_form.TabIndex = 50;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(49, 428);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 19);
            this.label13.TabIndex = 59;
            this.label13.Text = "文件形态";
            // 
            // cbo_format
            // 
            this.cbo_format.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_format.FormattingEnabled = true;
            this.cbo_format.Location = new System.Drawing.Point(428, 365);
            this.cbo_format.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbo_format.Name = "cbo_format";
            this.cbo_format.Size = new System.Drawing.Size(186, 28);
            this.cbo_format.TabIndex = 48;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(357, 371);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 17);
            this.label12.TabIndex = 58;
            this.label12.Text = "文件格式";
            // 
            // cbo_carrier
            // 
            this.cbo_carrier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_carrier.FormattingEnabled = true;
            this.cbo_carrier.Location = new System.Drawing.Point(126, 365);
            this.cbo_carrier.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbo_carrier.Name = "cbo_carrier";
            this.cbo_carrier.Size = new System.Drawing.Size(186, 28);
            this.cbo_carrier.TabIndex = 47;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(77, 370);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 19);
            this.label11.TabIndex = 57;
            this.label11.Text = "载体";
            // 
            // txt_unit
            // 
            this.txt_unit.Location = new System.Drawing.Point(126, 308);
            this.txt_unit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_unit.Name = "txt_unit";
            this.txt_unit.Size = new System.Drawing.Size(488, 26);
            this.txt_unit.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(49, 312);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 19);
            this.label10.TabIndex = 56;
            this.label10.Text = "存放单位";
            // 
            // dtp_date
            // 
            this.dtp_date.Location = new System.Drawing.Point(428, 250);
            this.dtp_date.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.Size = new System.Drawing.Size(186, 26);
            this.dtp_date.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(348, 254);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 19);
            this.label9.TabIndex = 54;
            this.label9.Text = "形成日期";
            // 
            // num_amount
            // 
            this.num_amount.Location = new System.Drawing.Point(126, 250);
            this.num_amount.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.num_amount.Name = "num_amount";
            this.num_amount.Size = new System.Drawing.Size(152, 26);
            this.num_amount.TabIndex = 43;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(77, 254);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 19);
            this.label8.TabIndex = 52;
            this.label8.Text = "份数";
            // 
            // num_page
            // 
            this.num_page.Location = new System.Drawing.Point(428, 192);
            this.num_page.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.num_page.Name = "num_page";
            this.num_page.Size = new System.Drawing.Size(149, 26);
            this.num_page.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(376, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 19);
            this.label7.TabIndex = 49;
            this.label7.Text = "页数";
            // 
            // cbo_secret
            // 
            this.cbo_secret.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_secret.FormattingEnabled = true;
            this.cbo_secret.Location = new System.Drawing.Point(126, 191);
            this.cbo_secret.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbo_secret.Name = "cbo_secret";
            this.cbo_secret.Size = new System.Drawing.Size(186, 28);
            this.cbo_secret.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(77, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 19);
            this.label6.TabIndex = 46;
            this.label6.Text = "密级";
            // 
            // txt_user
            // 
            this.txt_user.Location = new System.Drawing.Point(126, 134);
            this.txt_user.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(186, 26);
            this.txt_user.TabIndex = 36;
            // 
            // cbo_type
            // 
            this.cbo_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_type.FormattingEnabled = true;
            this.cbo_type.Location = new System.Drawing.Point(428, 133);
            this.cbo_type.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbo_type.Name = "cbo_type";
            this.cbo_type.Size = new System.Drawing.Size(186, 28);
            this.cbo_type.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(348, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 19);
            this.label5.TabIndex = 42;
            this.label5.Text = "文件类型";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(35, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 19);
            this.label4.TabIndex = 41;
            this.label4.Text = "文件责任者";
            // 
            // txt_fileName
            // 
            this.txt_fileName.Location = new System.Drawing.Point(126, 76);
            this.txt_fileName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_fileName.Name = "txt_fileName";
            this.txt_fileName.Size = new System.Drawing.Size(488, 26);
            this.txt_fileName.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(49, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 19);
            this.label3.TabIndex = 37;
            this.label3.Text = "文件名称";
            // 
            // cbo_categor
            // 
            this.cbo_categor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_categor.FormattingEnabled = true;
            this.cbo_categor.Location = new System.Drawing.Point(428, 17);
            this.cbo_categor.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbo_categor.Name = "cbo_categor";
            this.cbo_categor.Size = new System.Drawing.Size(186, 28);
            this.cbo_categor.TabIndex = 33;
            this.cbo_categor.SelectedIndexChanged += new System.EventHandler(this.Cbo_categor_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(348, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 19);
            this.label2.TabIndex = 34;
            this.label2.Text = "文件类别";
            // 
            // cbo_stage
            // 
            this.cbo_stage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_stage.FormattingEnabled = true;
            this.cbo_stage.Location = new System.Drawing.Point(126, 17);
            this.cbo_stage.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbo_stage.Name = "cbo_stage";
            this.cbo_stage.Size = new System.Drawing.Size(186, 28);
            this.cbo_stage.TabIndex = 32;
            this.cbo_stage.SelectionChangeCommitted += new System.EventHandler(this.Cbo_stage_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(77, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 19);
            this.label1.TabIndex = 31;
            this.label1.Text = "阶段";
            // 
            // pal_ShowData
            // 
            this.pal_ShowData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pal_ShowData.Location = new System.Drawing.Point(638, 1);
            this.pal_ShowData.Name = "pal_ShowData";
            this.pal_ShowData.Size = new System.Drawing.Size(0, 590);
            this.pal_ShowData.TabIndex = 63;
            // 
            // Frm_AddFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 592);
            this.Controls.Add(this.pal_ShowData);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.lbl_OpenFile);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_link);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cbo_form);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbo_format);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cbo_carrier);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_unit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtp_date);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.num_amount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.num_page);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbo_secret);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.cbo_type);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_fileName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbo_categor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbo_stage);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AddFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增文件";
            this.Load += new System.EventHandler(this.Frm_AddFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_page)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.LinkLabel lbl_OpenFile;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txt_link;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbo_form;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbo_format;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbo_carrier;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_unit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtp_date;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown num_amount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown num_page;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbo_secret;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.ComboBox cbo_type;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_fileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_categor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_stage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pal_ShowData;
    }
}