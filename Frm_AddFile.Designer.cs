﻿namespace 数据采集档案管理系统___课题版
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
            this.components = new System.ComponentModel.Container();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.lbl_OpenFile = new System.Windows.Forms.LinkLabel();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_link = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_unit = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtp_date = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.num_page = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_categor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_stage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.pal_type = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdo_type_ps = new System.Windows.Forms.RadioButton();
            this.rdo_type_cw = new System.Windows.Forms.RadioButton();
            this.rdo_type_js = new System.Windows.Forms.RadioButton();
            this.txt_fileCode = new System.Windows.Forms.TextBox();
            this.pal_carrier = new System.Windows.Forms.Panel();
            this.chk_carrier_DZ = new System.Windows.Forms.CheckBox();
            this.chk_carrier_ZZ = new System.Windows.Forms.CheckBox();
            this.txt_fileName = new System.Windows.Forms.ComboBox();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.num_count = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.pal_Wait = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.num_page)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pal_type.SuspendLayout();
            this.pal_carrier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_count)).BeginInit();
            this.pal_Wait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(240, 589);
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
            this.lbl_OpenFile.Enabled = false;
            this.lbl_OpenFile.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_OpenFile.Location = new System.Drawing.Point(641, 404);
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
            this.btn_Quit.Location = new System.Drawing.Point(396, 589);
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
            this.btn_Save.Location = new System.Drawing.Point(318, 589);
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
            this.txt_link.Enabled = false;
            this.txt_link.Location = new System.Drawing.Point(126, 396);
            this.txt_link.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_link.Name = "txt_link";
            this.txt_link.Size = new System.Drawing.Size(508, 26);
            this.txt_link.TabIndex = 51;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(4, 396);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 22);
            this.label14.TabIndex = 60;
            this.label14.Text = "电子文件挂接";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(68, 288);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 22);
            this.label11.TabIndex = 57;
            this.label11.Text = "载体";
            // 
            // txt_unit
            // 
            this.txt_unit.Location = new System.Drawing.Point(126, 342);
            this.txt_unit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_unit.Name = "txt_unit";
            this.txt_unit.Size = new System.Drawing.Size(543, 26);
            this.txt_unit.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(36, 344);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 22);
            this.label10.TabIndex = 56;
            this.label10.Text = "存放单位";
            // 
            // dtp_date
            // 
            this.dtp_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_date.Location = new System.Drawing.Point(126, 171);
            this.dtp_date.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.Size = new System.Drawing.Size(152, 26);
            this.dtp_date.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(36, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 22);
            this.label9.TabIndex = 54;
            this.label9.Text = "形成日期";
            // 
            // num_page
            // 
            this.num_page.Location = new System.Drawing.Point(465, 171);
            this.num_page.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.num_page.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.num_page.Name = "num_page";
            this.num_page.Size = new System.Drawing.Size(127, 26);
            this.num_page.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(404, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 22);
            this.label7.TabIndex = 49;
            this.label7.Text = "页数";
            // 
            // txt_user
            // 
            this.txt_user.Location = new System.Drawing.Point(465, 69);
            this.txt_user.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(204, 26);
            this.txt_user.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(36, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 22);
            this.label5.TabIndex = 42;
            this.label5.Text = "文件类型";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(356, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 22);
            this.label4.TabIndex = 41;
            this.label4.Text = "文件责任者";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(36, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 22);
            this.label3.TabIndex = 37;
            this.label3.Text = "文件名称";
            // 
            // cbo_categor
            // 
            this.cbo_categor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_categor.FormattingEnabled = true;
            this.cbo_categor.Location = new System.Drawing.Point(465, 17);
            this.cbo_categor.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbo_categor.Name = "cbo_categor";
            this.cbo_categor.Size = new System.Drawing.Size(204, 28);
            this.cbo_categor.TabIndex = 33;
            this.cbo_categor.SelectionChangeCommitted += new System.EventHandler(this.Cbo_categor_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(372, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 22);
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
            this.cbo_stage.Size = new System.Drawing.Size(204, 28);
            this.cbo_stage.TabIndex = 32;
            this.cbo_stage.SelectionChangeCommitted += new System.EventHandler(this.Cbo_stage_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(64, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 22);
            this.label1.TabIndex = 31;
            this.label1.Text = "阶段";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(36, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 22);
            this.label12.TabIndex = 65;
            this.label12.Text = "文件编号";
            // 
            // pal_type
            // 
            this.pal_type.Controls.Add(this.radioButton1);
            this.pal_type.Controls.Add(this.rdo_type_ps);
            this.pal_type.Controls.Add(this.rdo_type_cw);
            this.pal_type.Controls.Add(this.rdo_type_js);
            this.pal_type.Location = new System.Drawing.Point(126, 220);
            this.pal_type.Name = "pal_type";
            this.pal_type.Size = new System.Drawing.Size(263, 39);
            this.pal_type.TabIndex = 68;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(67, 7);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(55, 24);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "ef8d18ad-18a7-433d-8875-aac496f844e9";
            this.radioButton1.Text = "财务";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rdo_type_ps
            // 
            this.rdo_type_ps.AutoSize = true;
            this.rdo_type_ps.Location = new System.Drawing.Point(189, 7);
            this.rdo_type_ps.Name = "rdo_type_ps";
            this.rdo_type_ps.Size = new System.Drawing.Size(55, 24);
            this.rdo_type_ps.TabIndex = 2;
            this.rdo_type_ps.TabStop = true;
            this.rdo_type_ps.Tag = "1731a1cf-781d-438b-bbde-ac48d4d07914";
            this.rdo_type_ps.Text = "文书";
            this.rdo_type_ps.UseVisualStyleBackColor = true;
            // 
            // rdo_type_cw
            // 
            this.rdo_type_cw.AutoSize = true;
            this.rdo_type_cw.Location = new System.Drawing.Point(128, 7);
            this.rdo_type_cw.Name = "rdo_type_cw";
            this.rdo_type_cw.Size = new System.Drawing.Size(55, 24);
            this.rdo_type_cw.TabIndex = 1;
            this.rdo_type_cw.TabStop = true;
            this.rdo_type_cw.Tag = "6996e983-384d-4cc3-a801-33cc08a2d9ee";
            this.rdo_type_cw.Text = "管理";
            this.rdo_type_cw.UseVisualStyleBackColor = true;
            // 
            // rdo_type_js
            // 
            this.rdo_type_js.AutoSize = true;
            this.rdo_type_js.Location = new System.Drawing.Point(6, 7);
            this.rdo_type_js.Name = "rdo_type_js";
            this.rdo_type_js.Size = new System.Drawing.Size(55, 24);
            this.rdo_type_js.TabIndex = 0;
            this.rdo_type_js.TabStop = true;
            this.rdo_type_js.Tag = "ef8d18ad-18a7-433d-8875-aac496f844e7";
            this.rdo_type_js.Text = "技术";
            this.rdo_type_js.UseVisualStyleBackColor = true;
            // 
            // txt_fileCode
            // 
            this.txt_fileCode.Location = new System.Drawing.Point(126, 69);
            this.txt_fileCode.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_fileCode.Name = "txt_fileCode";
            this.txt_fileCode.ReadOnly = true;
            this.txt_fileCode.Size = new System.Drawing.Size(204, 26);
            this.txt_fileCode.TabIndex = 64;
            // 
            // pal_carrier
            // 
            this.pal_carrier.Controls.Add(this.chk_carrier_DZ);
            this.pal_carrier.Controls.Add(this.chk_carrier_ZZ);
            this.pal_carrier.Location = new System.Drawing.Point(126, 280);
            this.pal_carrier.Name = "pal_carrier";
            this.pal_carrier.Size = new System.Drawing.Size(135, 39);
            this.pal_carrier.TabIndex = 70;
            this.pal_carrier.Tag = "e7bce5d4-38b7-4d74-8aa2-c580b880aabb";
            // 
            // chk_carrier_DZ
            // 
            this.chk_carrier_DZ.AutoSize = true;
            this.chk_carrier_DZ.Location = new System.Drawing.Point(67, 7);
            this.chk_carrier_DZ.Name = "chk_carrier_DZ";
            this.chk_carrier_DZ.Size = new System.Drawing.Size(56, 24);
            this.chk_carrier_DZ.TabIndex = 1;
            this.chk_carrier_DZ.Tag = "6ffdf849-31fa-4401-a640-c371cd994daf";
            this.chk_carrier_DZ.Text = "电子";
            this.chk_carrier_DZ.UseVisualStyleBackColor = true;
            this.chk_carrier_DZ.CheckedChanged += new System.EventHandler(this.chk_carrier_DZ_CheckedChanged);
            // 
            // chk_carrier_ZZ
            // 
            this.chk_carrier_ZZ.AutoSize = true;
            this.chk_carrier_ZZ.Location = new System.Drawing.Point(6, 7);
            this.chk_carrier_ZZ.Name = "chk_carrier_ZZ";
            this.chk_carrier_ZZ.Size = new System.Drawing.Size(56, 24);
            this.chk_carrier_ZZ.TabIndex = 0;
            this.chk_carrier_ZZ.Tag = "e7bce5d4-38b7-4d74-8aa2-c580b880aaba";
            this.chk_carrier_ZZ.Text = "纸质";
            this.chk_carrier_ZZ.UseVisualStyleBackColor = true;
            this.chk_carrier_ZZ.CheckedChanged += new System.EventHandler(this.chk_carrier_ZZ_CheckedChanged);
            // 
            // txt_fileName
            // 
            this.txt_fileName.FormattingEnabled = true;
            this.txt_fileName.Location = new System.Drawing.Point(126, 120);
            this.txt_fileName.Name = "txt_fileName";
            this.txt_fileName.Size = new System.Drawing.Size(543, 28);
            this.txt_fileName.TabIndex = 71;
            this.txt_fileName.SelectionChangeCommitted += new System.EventHandler(this.txt_fileName_SelectionChangeCommitted);
            // 
            // txt_Remark
            // 
            this.txt_Remark.Location = new System.Drawing.Point(126, 457);
            this.txt_Remark.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_Remark.Multiline = true;
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Remark.Size = new System.Drawing.Size(543, 107);
            this.txt_Remark.TabIndex = 72;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(68, 457);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 22);
            this.label8.TabIndex = 73;
            this.label8.Text = "说明";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(358, 23);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 20);
            this.label15.TabIndex = 74;
            this.label15.Text = "*";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(23, 72);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 20);
            this.label16.TabIndex = 75;
            this.label16.Text = "*";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.Red;
            this.label17.Location = new System.Drawing.Point(23, 125);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 20);
            this.label17.TabIndex = 76;
            this.label17.Text = "*";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(23, 229);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(15, 20);
            this.label18.TabIndex = 77;
            this.label18.Text = "*";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(53, 289);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(15, 20);
            this.label20.TabIndex = 79;
            this.label20.Text = "*";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(23, 345);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(15, 20);
            this.label22.TabIndex = 81;
            this.label22.Text = "*";
            // 
            // num_count
            // 
            this.num_count.Enabled = false;
            this.num_count.Location = new System.Drawing.Point(465, 286);
            this.num_count.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.num_count.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.num_count.Name = "num_count";
            this.num_count.Size = new System.Drawing.Size(92, 26);
            this.num_count.TabIndex = 82;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label23.Location = new System.Drawing.Point(328, 288);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(118, 22);
            this.label23.TabIndex = 83;
            this.label23.Text = "份数(用于移交)";
            // 
            // pal_Wait
            // 
            this.pal_Wait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pal_Wait.Controls.Add(this.label26);
            this.pal_Wait.Controls.Add(this.pictureBox1);
            this.pal_Wait.Location = new System.Drawing.Point(278, 475);
            this.pal_Wait.Name = "pal_Wait";
            this.pal_Wait.Size = new System.Drawing.Size(214, 75);
            this.pal_Wait.TabIndex = 87;
            this.pal_Wait.Visible = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(6, 49);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(203, 19);
            this.label26.TabIndex = 1;
            this.label26.Text = "正在下载并解析文件，请稍后...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::数据采集档案管理系统___课题版.Properties.Resources.wait;
            this.pictureBox1.Location = new System.Drawing.Point(91, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Frm_AddFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 646);
            this.Controls.Add(this.pal_Wait);
            this.Controls.Add(this.num_count);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_Remark);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_fileName);
            this.Controls.Add(this.pal_carrier);
            this.Controls.Add(this.pal_type);
            this.Controls.Add(this.txt_fileCode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.lbl_OpenFile);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_link);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_unit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtp_date);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.num_page);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_AddFile_FormClosing);
            this.Load += new System.EventHandler(this.Frm_AddFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.num_page)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pal_type.ResumeLayout(false);
            this.pal_type.PerformLayout();
            this.pal_carrier.ResumeLayout(false);
            this.pal_carrier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_count)).EndInit();
            this.pal_Wait.ResumeLayout(false);
            this.pal_Wait.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txt_unit;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.DateTimePicker dtp_date;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown num_page;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_categor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_stage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pal_type;
        private System.Windows.Forms.RadioButton rdo_type_ps;
        private System.Windows.Forms.RadioButton rdo_type_cw;
        private System.Windows.Forms.RadioButton rdo_type_js;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox txt_fileCode;
        private System.Windows.Forms.Panel pal_carrier;
        private System.Windows.Forms.CheckBox chk_carrier_DZ;
        private System.Windows.Forms.CheckBox chk_carrier_ZZ;
        private System.Windows.Forms.ComboBox txt_fileName;
        public System.Windows.Forms.TextBox txt_Remark;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown num_count;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Panel pal_Wait;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}