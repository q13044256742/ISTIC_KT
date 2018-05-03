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
            this.components = new System.ComponentModel.Container();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.lbl_OpenFile = new System.Windows.Forms.LinkLabel();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_link = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_unit = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtp_date = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.num_page = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_fileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbo_categor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_stage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.pal_secret = new System.Windows.Forms.Panel();
            this.rdo_secret_jum = new System.Windows.Forms.RadioButton();
            this.rdo_secret_jm = new System.Windows.Forms.RadioButton();
            this.rdo_secret_mm = new System.Windows.Forms.RadioButton();
            this.rdo_secret_gn = new System.Windows.Forms.RadioButton();
            this.rdo_secret_gk = new System.Windows.Forms.RadioButton();
            this.txt_fileCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pal_carrier = new System.Windows.Forms.Panel();
            this.rdo_carrier_zd = new System.Windows.Forms.RadioButton();
            this.rdo_carrier_dz = new System.Windows.Forms.RadioButton();
            this.rdo_carrier_zz = new System.Windows.Forms.RadioButton();
            this.pal_form = new System.Windows.Forms.Panel();
            this.rdo_form_fyj = new System.Windows.Forms.RadioButton();
            this.rdo_form_yj = new System.Windows.Forms.RadioButton();
            this.pal_type = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdo_type_ps = new System.Windows.Forms.RadioButton();
            this.rdo_type_cw = new System.Windows.Forms.RadioButton();
            this.rdo_type_js = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.num_page)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.pal_secret.SuspendLayout();
            this.pal_carrier.SuspendLayout();
            this.pal_form.SuspendLayout();
            this.pal_type.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(240, 591);
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
            this.lbl_OpenFile.Location = new System.Drawing.Point(641, 545);
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
            this.btn_Quit.Location = new System.Drawing.Point(396, 591);
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
            this.btn_Save.Location = new System.Drawing.Point(318, 591);
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
            this.txt_link.Location = new System.Drawing.Point(126, 537);
            this.txt_link.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_link.Name = "txt_link";
            this.txt_link.Size = new System.Drawing.Size(508, 26);
            this.txt_link.TabIndex = 51;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(4, 537);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 22);
            this.label14.TabIndex = 60;
            this.label14.Text = "文件地址链接";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(372, 409);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 22);
            this.label13.TabIndex = 59;
            this.label13.Text = "文件形态";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(68, 409);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 22);
            this.label11.TabIndex = 57;
            this.label11.Text = "载体";
            // 
            // txt_unit
            // 
            this.txt_unit.Location = new System.Drawing.Point(126, 477);
            this.txt_unit.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_unit.Name = "txt_unit";
            this.txt_unit.Size = new System.Drawing.Size(543, 26);
            this.txt_unit.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(36, 479);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 22);
            this.label10.TabIndex = 56;
            this.label10.Text = "存放单位";
            // 
            // dtp_date
            // 
            this.dtp_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_date.Location = new System.Drawing.Point(126, 200);
            this.dtp_date.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.Size = new System.Drawing.Size(186, 26);
            this.dtp_date.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(36, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 22);
            this.label9.TabIndex = 54;
            this.label9.Text = "形成日期";
            // 
            // num_page
            // 
            this.num_page.Location = new System.Drawing.Point(465, 200);
            this.num_page.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.num_page.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.num_page.Name = "num_page";
            this.num_page.Size = new System.Drawing.Size(204, 26);
            this.num_page.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(404, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 22);
            this.label7.TabIndex = 49;
            this.label7.Text = "页数";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(68, 340);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 22);
            this.label6.TabIndex = 46;
            this.label6.Text = "密级";
            // 
            // txt_user
            // 
            this.txt_user.Location = new System.Drawing.Point(465, 80);
            this.txt_user.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(204, 26);
            this.txt_user.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(36, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 22);
            this.label5.TabIndex = 42;
            this.label5.Text = "文件类型";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(356, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 22);
            this.label4.TabIndex = 41;
            this.label4.Text = "文件责任者";
            // 
            // txt_fileName
            // 
            this.txt_fileName.Location = new System.Drawing.Point(126, 138);
            this.txt_fileName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_fileName.Name = "txt_fileName";
            this.txt_fileName.Size = new System.Drawing.Size(543, 26);
            this.txt_fileName.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(36, 142);
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
            // pal_secret
            // 
            this.pal_secret.Controls.Add(this.rdo_secret_jum);
            this.pal_secret.Controls.Add(this.rdo_secret_jm);
            this.pal_secret.Controls.Add(this.rdo_secret_mm);
            this.pal_secret.Controls.Add(this.rdo_secret_gn);
            this.pal_secret.Controls.Add(this.rdo_secret_gk);
            this.pal_secret.Location = new System.Drawing.Point(126, 332);
            this.pal_secret.Name = "pal_secret";
            this.pal_secret.Size = new System.Drawing.Size(311, 39);
            this.pal_secret.TabIndex = 63;
            // 
            // rdo_secret_jum
            // 
            this.rdo_secret_jum.AutoSize = true;
            this.rdo_secret_jum.Location = new System.Drawing.Point(250, 7);
            this.rdo_secret_jum.Name = "rdo_secret_jum";
            this.rdo_secret_jum.Size = new System.Drawing.Size(55, 24);
            this.rdo_secret_jum.TabIndex = 4;
            this.rdo_secret_jum.TabStop = true;
            this.rdo_secret_jum.Tag = "6a7bca7f-996b-49b7-8c7e-aabd2c437c66";
            this.rdo_secret_jum.Text = "绝密";
            this.rdo_secret_jum.UseVisualStyleBackColor = true;
            // 
            // rdo_secret_jm
            // 
            this.rdo_secret_jm.AutoSize = true;
            this.rdo_secret_jm.Location = new System.Drawing.Point(189, 7);
            this.rdo_secret_jm.Name = "rdo_secret_jm";
            this.rdo_secret_jm.Size = new System.Drawing.Size(55, 24);
            this.rdo_secret_jm.TabIndex = 3;
            this.rdo_secret_jm.TabStop = true;
            this.rdo_secret_jm.Tag = "2f7767e7-751c-4055-a5f3-d1bcbd508aee";
            this.rdo_secret_jm.Text = "机密";
            this.rdo_secret_jm.UseVisualStyleBackColor = true;
            // 
            // rdo_secret_mm
            // 
            this.rdo_secret_mm.AutoSize = true;
            this.rdo_secret_mm.Location = new System.Drawing.Point(128, 7);
            this.rdo_secret_mm.Name = "rdo_secret_mm";
            this.rdo_secret_mm.Size = new System.Drawing.Size(55, 24);
            this.rdo_secret_mm.TabIndex = 2;
            this.rdo_secret_mm.TabStop = true;
            this.rdo_secret_mm.Tag = "e2a57ffd-7041-4d2b-98b2-6494e648c74f";
            this.rdo_secret_mm.Text = "秘密";
            this.rdo_secret_mm.UseVisualStyleBackColor = true;
            // 
            // rdo_secret_gn
            // 
            this.rdo_secret_gn.AutoSize = true;
            this.rdo_secret_gn.Location = new System.Drawing.Point(67, 7);
            this.rdo_secret_gn.Name = "rdo_secret_gn";
            this.rdo_secret_gn.Size = new System.Drawing.Size(55, 24);
            this.rdo_secret_gn.TabIndex = 1;
            this.rdo_secret_gn.TabStop = true;
            this.rdo_secret_gn.Tag = "0987e1aa-65e5-4b14-b220-e030e2594327";
            this.rdo_secret_gn.Text = "国内";
            this.rdo_secret_gn.UseVisualStyleBackColor = true;
            // 
            // rdo_secret_gk
            // 
            this.rdo_secret_gk.AutoSize = true;
            this.rdo_secret_gk.Location = new System.Drawing.Point(6, 7);
            this.rdo_secret_gk.Name = "rdo_secret_gk";
            this.rdo_secret_gk.Size = new System.Drawing.Size(55, 24);
            this.rdo_secret_gk.TabIndex = 0;
            this.rdo_secret_gk.TabStop = true;
            this.rdo_secret_gk.Tag = "09270691-d1f3-48e8-9632-7c08e5b1c286";
            this.rdo_secret_gk.Text = "公开";
            this.rdo_secret_gk.UseVisualStyleBackColor = true;
            // 
            // txt_fileCode
            // 
            this.txt_fileCode.Location = new System.Drawing.Point(126, 80);
            this.txt_fileCode.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_fileCode.Name = "txt_fileCode";
            this.txt_fileCode.ReadOnly = true;
            this.txt_fileCode.Size = new System.Drawing.Size(204, 26);
            this.txt_fileCode.TabIndex = 64;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 11.5F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(36, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 22);
            this.label12.TabIndex = 65;
            this.label12.Text = "文件编号";
            // 
            // pal_carrier
            // 
            this.pal_carrier.Controls.Add(this.rdo_carrier_zd);
            this.pal_carrier.Controls.Add(this.rdo_carrier_dz);
            this.pal_carrier.Controls.Add(this.rdo_carrier_zz);
            this.pal_carrier.Location = new System.Drawing.Point(126, 401);
            this.pal_carrier.Name = "pal_carrier";
            this.pal_carrier.Size = new System.Drawing.Size(240, 39);
            this.pal_carrier.TabIndex = 66;
            // 
            // rdo_carrier_zd
            // 
            this.rdo_carrier_zd.AutoSize = true;
            this.rdo_carrier_zd.Location = new System.Drawing.Point(131, 7);
            this.rdo_carrier_zd.Name = "rdo_carrier_zd";
            this.rdo_carrier_zd.Size = new System.Drawing.Size(101, 24);
            this.rdo_carrier_zd.TabIndex = 2;
            this.rdo_carrier_zd.TabStop = true;
            this.rdo_carrier_zd.Tag = "e7bce5d4-38b7-4d74-8aa2-c580b880aabb";
            this.rdo_carrier_zd.Text = "纸质 + 电子";
            this.rdo_carrier_zd.UseVisualStyleBackColor = true;
            // 
            // rdo_carrier_dz
            // 
            this.rdo_carrier_dz.AutoSize = true;
            this.rdo_carrier_dz.Location = new System.Drawing.Point(70, 7);
            this.rdo_carrier_dz.Name = "rdo_carrier_dz";
            this.rdo_carrier_dz.Size = new System.Drawing.Size(55, 24);
            this.rdo_carrier_dz.TabIndex = 1;
            this.rdo_carrier_dz.TabStop = true;
            this.rdo_carrier_dz.Tag = "6ffdf849-31fa-4401-a640-c371cd994daf";
            this.rdo_carrier_dz.Text = "电子";
            this.rdo_carrier_dz.UseVisualStyleBackColor = true;
            // 
            // rdo_carrier_zz
            // 
            this.rdo_carrier_zz.AutoSize = true;
            this.rdo_carrier_zz.Location = new System.Drawing.Point(9, 7);
            this.rdo_carrier_zz.Name = "rdo_carrier_zz";
            this.rdo_carrier_zz.Size = new System.Drawing.Size(55, 24);
            this.rdo_carrier_zz.TabIndex = 0;
            this.rdo_carrier_zz.TabStop = true;
            this.rdo_carrier_zz.Tag = "e7bce5d4-38b7-4d74-8aa2-c580b880aaba";
            this.rdo_carrier_zz.Text = "纸质";
            this.rdo_carrier_zz.UseVisualStyleBackColor = true;
            // 
            // pal_form
            // 
            this.pal_form.Controls.Add(this.rdo_form_fyj);
            this.pal_form.Controls.Add(this.rdo_form_yj);
            this.pal_form.Location = new System.Drawing.Point(465, 401);
            this.pal_form.Name = "pal_form";
            this.pal_form.Size = new System.Drawing.Size(153, 39);
            this.pal_form.TabIndex = 67;
            // 
            // rdo_form_fyj
            // 
            this.rdo_form_fyj.AutoSize = true;
            this.rdo_form_fyj.Location = new System.Drawing.Point(67, 7);
            this.rdo_form_fyj.Name = "rdo_form_fyj";
            this.rdo_form_fyj.Size = new System.Drawing.Size(69, 24);
            this.rdo_form_fyj.TabIndex = 1;
            this.rdo_form_fyj.TabStop = true;
            this.rdo_form_fyj.Tag = "3c2a5f32-1c9f-4662-8aa3-12161ca508f3";
            this.rdo_form_fyj.Text = "复印件";
            this.rdo_form_fyj.UseVisualStyleBackColor = true;
            // 
            // rdo_form_yj
            // 
            this.rdo_form_yj.AutoSize = true;
            this.rdo_form_yj.Location = new System.Drawing.Point(6, 7);
            this.rdo_form_yj.Name = "rdo_form_yj";
            this.rdo_form_yj.Size = new System.Drawing.Size(55, 24);
            this.rdo_form_yj.TabIndex = 0;
            this.rdo_form_yj.TabStop = true;
            this.rdo_form_yj.Tag = "303f8da8-6992-4110-a55a-381f8d01b4c8";
            this.rdo_form_yj.Text = "原件";
            this.rdo_form_yj.UseVisualStyleBackColor = true;
            // 
            // pal_type
            // 
            this.pal_type.Controls.Add(this.radioButton1);
            this.pal_type.Controls.Add(this.rdo_type_ps);
            this.pal_type.Controls.Add(this.rdo_type_cw);
            this.pal_type.Controls.Add(this.rdo_type_js);
            this.pal_type.Location = new System.Drawing.Point(126, 261);
            this.pal_type.Name = "pal_type";
            this.pal_type.Size = new System.Drawing.Size(305, 39);
            this.pal_type.TabIndex = 68;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(70, 7);
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
            this.rdo_type_ps.Location = new System.Drawing.Point(229, 7);
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
            this.rdo_type_cw.Location = new System.Drawing.Point(134, 7);
            this.rdo_type_cw.Name = "rdo_type_cw";
            this.rdo_type_cw.Size = new System.Drawing.Size(83, 24);
            this.rdo_type_cw.TabIndex = 1;
            this.rdo_type_cw.TabStop = true;
            this.rdo_type_cw.Tag = "6996e983-384d-4cc3-a801-33cc08a2d9ee";
            this.rdo_type_cw.Text = "评审管理";
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
            // Frm_AddFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 638);
            this.Controls.Add(this.pal_type);
            this.Controls.Add(this.pal_form);
            this.Controls.Add(this.pal_carrier);
            this.Controls.Add(this.txt_fileCode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.pal_secret);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.lbl_OpenFile);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.txt_link);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_unit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.dtp_date);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.num_page);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_user);
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
            ((System.ComponentModel.ISupportInitialize)(this.num_page)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.pal_secret.ResumeLayout(false);
            this.pal_secret.PerformLayout();
            this.pal_carrier.ResumeLayout(false);
            this.pal_carrier.PerformLayout();
            this.pal_form.ResumeLayout(false);
            this.pal_form.PerformLayout();
            this.pal_type.ResumeLayout(false);
            this.pal_type.PerformLayout();
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
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_unit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtp_date;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown num_page;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_fileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbo_categor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_stage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel pal_secret;
        private System.Windows.Forms.RadioButton rdo_secret_jum;
        private System.Windows.Forms.RadioButton rdo_secret_jm;
        private System.Windows.Forms.RadioButton rdo_secret_mm;
        private System.Windows.Forms.RadioButton rdo_secret_gn;
        private System.Windows.Forms.RadioButton rdo_secret_gk;
        private System.Windows.Forms.Panel pal_type;
        private System.Windows.Forms.RadioButton rdo_type_ps;
        private System.Windows.Forms.RadioButton rdo_type_cw;
        private System.Windows.Forms.RadioButton rdo_type_js;
        private System.Windows.Forms.Panel pal_form;
        private System.Windows.Forms.RadioButton rdo_form_fyj;
        private System.Windows.Forms.RadioButton rdo_form_yj;
        private System.Windows.Forms.Panel pal_carrier;
        private System.Windows.Forms.RadioButton rdo_carrier_zd;
        private System.Windows.Forms.RadioButton rdo_carrier_dz;
        private System.Windows.Forms.RadioButton rdo_carrier_zz;
        private System.Windows.Forms.TextBox txt_fileCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}