namespace 数据采集档案管理系统___课题版
{
    partial class Frm_UserManage
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tab_UseList = new System.Windows.Forms.TabControl();
            this.tp_UserList = new System.Windows.Forms.TabPage();
            this.dgv_UserList = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.realname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_Search_Type = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Search_KeyWord = new System.Windows.Forms.TextBox();
            this.tab_UserAdd = new System.Windows.Forms.TabPage();
            this.cbo_Unit = new System.Windows.Forms.ComboBox();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Phone = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_RealName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Department = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_PassWordAagin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_PassWord = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorTip = new System.Windows.Forms.ErrorProvider(this.components);
            this.tab_UseList.SuspendLayout();
            this.tp_UserList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tab_UserAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorTip)).BeginInit();
            this.SuspendLayout();
            // 
            // tab_UseList
            // 
            this.tab_UseList.Controls.Add(this.tp_UserList);
            this.tab_UseList.Controls.Add(this.tab_UserAdd);
            this.tab_UseList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_UseList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tab_UseList.Location = new System.Drawing.Point(0, 0);
            this.tab_UseList.Name = "tab_UseList";
            this.tab_UseList.SelectedIndex = 0;
            this.tab_UseList.Size = new System.Drawing.Size(834, 521);
            this.tab_UseList.TabIndex = 1;
            // 
            // tp_UserList
            // 
            this.tp_UserList.Controls.Add(this.dgv_UserList);
            this.tp_UserList.Controls.Add(this.groupBox1);
            this.tp_UserList.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tp_UserList.Location = new System.Drawing.Point(4, 29);
            this.tp_UserList.Name = "tp_UserList";
            this.tp_UserList.Padding = new System.Windows.Forms.Padding(3);
            this.tp_UserList.Size = new System.Drawing.Size(826, 488);
            this.tp_UserList.TabIndex = 0;
            this.tp_UserList.Text = "用户列表";
            this.tp_UserList.UseVisualStyleBackColor = true;
            // 
            // dgv_UserList
            // 
            this.dgv_UserList.AllowUserToAddRows = false;
            this.dgv_UserList.AllowUserToDeleteRows = false;
            this.dgv_UserList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_UserList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_UserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.realname,
            this.username,
            this.phone,
            this.unit});
            this.dgv_UserList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_UserList.Location = new System.Drawing.Point(3, 64);
            this.dgv_UserList.Name = "dgv_UserList";
            this.dgv_UserList.ReadOnly = true;
            this.dgv_UserList.RowTemplate.Height = 23;
            this.dgv_UserList.Size = new System.Drawing.Size(820, 421);
            this.dgv_UserList.TabIndex = 0;
            // 
            // id
            // 
            this.id.FillWeight = 50F;
            this.id.HeaderText = "序号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // realname
            // 
            this.realname.HeaderText = "真实姓名";
            this.realname.Name = "realname";
            this.realname.ReadOnly = true;
            // 
            // username
            // 
            this.username.HeaderText = "登录名";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            // 
            // phone
            // 
            this.phone.HeaderText = "联系方式";
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            // 
            // unit
            // 
            this.unit.FillWeight = 200F;
            this.unit.HeaderText = "所属单位";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Refresh);
            this.groupBox1.Controls.Add(this.btn_Search);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbo_Search_Type);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_Search_KeyWord);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(820, 61);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.AutoSize = true;
            this.btn_Refresh.Location = new System.Drawing.Point(495, 20);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(87, 31);
            this.btn_Refresh.TabIndex = 10;
            this.btn_Refresh.Text = "刷新(&R)";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.AutoSize = true;
            this.btn_Search.Location = new System.Drawing.Point(402, 20);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(87, 31);
            this.btn_Search.TabIndex = 9;
            this.btn_Search.Text = "查询(&F)";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(25, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "按";
            // 
            // cbo_Search_Type
            // 
            this.cbo_Search_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Search_Type.FormattingEnabled = true;
            this.cbo_Search_Type.Items.AddRange(new object[] {
            "真实姓名",
            "登录名",
            "联系方式",
            "所属单位"});
            this.cbo_Search_Type.Location = new System.Drawing.Point(56, 21);
            this.cbo_Search_Type.Name = "cbo_Search_Type";
            this.cbo_Search_Type.Size = new System.Drawing.Size(97, 28);
            this.cbo_Search_Type.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(159, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "检索";
            // 
            // txt_Search_KeyWord
            // 
            this.txt_Search_KeyWord.Location = new System.Drawing.Point(219, 22);
            this.txt_Search_KeyWord.Name = "txt_Search_KeyWord";
            this.txt_Search_KeyWord.Size = new System.Drawing.Size(163, 26);
            this.txt_Search_KeyWord.TabIndex = 8;
            // 
            // tab_UserAdd
            // 
            this.tab_UserAdd.AutoScroll = true;
            this.tab_UserAdd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tab_UserAdd.Controls.Add(this.cbo_Unit);
            this.tab_UserAdd.Controls.Add(this.btn_Reset);
            this.tab_UserAdd.Controls.Add(this.btn_Save);
            this.tab_UserAdd.Controls.Add(this.txt_Remark);
            this.tab_UserAdd.Controls.Add(this.label9);
            this.tab_UserAdd.Controls.Add(this.txt_Phone);
            this.tab_UserAdd.Controls.Add(this.label10);
            this.tab_UserAdd.Controls.Add(this.txt_Email);
            this.tab_UserAdd.Controls.Add(this.label11);
            this.tab_UserAdd.Controls.Add(this.txt_RealName);
            this.tab_UserAdd.Controls.Add(this.label8);
            this.tab_UserAdd.Controls.Add(this.txt_Department);
            this.tab_UserAdd.Controls.Add(this.label7);
            this.tab_UserAdd.Controls.Add(this.label6);
            this.tab_UserAdd.Controls.Add(this.txt_PassWordAagin);
            this.tab_UserAdd.Controls.Add(this.label5);
            this.tab_UserAdd.Controls.Add(this.txt_PassWord);
            this.tab_UserAdd.Controls.Add(this.label4);
            this.tab_UserAdd.Controls.Add(this.txt_UserName);
            this.tab_UserAdd.Controls.Add(this.label3);
            this.tab_UserAdd.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tab_UserAdd.Location = new System.Drawing.Point(4, 29);
            this.tab_UserAdd.Name = "tab_UserAdd";
            this.tab_UserAdd.Padding = new System.Windows.Forms.Padding(3);
            this.tab_UserAdd.Size = new System.Drawing.Size(826, 488);
            this.tab_UserAdd.TabIndex = 1;
            this.tab_UserAdd.Text = "用户添加";
            // 
            // cbo_Unit
            // 
            this.cbo_Unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_Unit.FormattingEnabled = true;
            this.cbo_Unit.Location = new System.Drawing.Point(247, 140);
            this.cbo_Unit.Name = "cbo_Unit";
            this.cbo_Unit.Size = new System.Drawing.Size(379, 28);
            this.cbo_Unit.TabIndex = 20;
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(291, 442);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(94, 33);
            this.btn_Reset.TabIndex = 19;
            this.btn_Reset.Text = "重置(&R)";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(415, 442);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(94, 33);
            this.btn_Save.TabIndex = 18;
            this.btn_Save.Text = "保存(&S)";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_Remark
            // 
            this.txt_Remark.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Remark.Location = new System.Drawing.Point(247, 336);
            this.txt_Remark.Multiline = true;
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.Size = new System.Drawing.Size(379, 84);
            this.txt_Remark.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(146, 339);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 19);
            this.label9.TabIndex = 16;
            this.label9.Text = "备注";
            // 
            // txt_Phone
            // 
            this.txt_Phone.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Phone.Location = new System.Drawing.Point(247, 297);
            this.txt_Phone.Name = "txt_Phone";
            this.txt_Phone.Size = new System.Drawing.Size(200, 26);
            this.txt_Phone.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(118, 300);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 19);
            this.label10.TabIndex = 14;
            this.label10.Text = "联系电话";
            // 
            // txt_Email
            // 
            this.txt_Email.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Email.Location = new System.Drawing.Point(247, 258);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(334, 26);
            this.txt_Email.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(146, 261);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 19);
            this.label11.TabIndex = 12;
            this.label11.Text = "邮箱";
            // 
            // txt_RealName
            // 
            this.txt_RealName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_RealName.Location = new System.Drawing.Point(247, 219);
            this.txt_RealName.Name = "txt_RealName";
            this.txt_RealName.Size = new System.Drawing.Size(269, 26);
            this.txt_RealName.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(118, 222);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 19);
            this.label8.TabIndex = 10;
            this.label8.Text = "真实姓名";
            // 
            // txt_Department
            // 
            this.txt_Department.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_Department.Location = new System.Drawing.Point(247, 180);
            this.txt_Department.Name = "txt_Department";
            this.txt_Department.Size = new System.Drawing.Size(379, 26);
            this.txt_Department.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(118, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 19);
            this.label7.TabIndex = 8;
            this.label7.Text = "归属部门";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(118, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 19);
            this.label6.TabIndex = 6;
            this.label6.Text = "所属单位";
            // 
            // txt_PassWordAagin
            // 
            this.txt_PassWordAagin.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_PassWordAagin.Location = new System.Drawing.Point(247, 102);
            this.txt_PassWordAagin.Name = "txt_PassWordAagin";
            this.txt_PassWordAagin.PasswordChar = '*';
            this.txt_PassWordAagin.Size = new System.Drawing.Size(269, 26);
            this.txt_PassWordAagin.TabIndex = 5;
            this.txt_PassWordAagin.Leave += new System.EventHandler(this.txt_PassWordAagin_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(118, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "确认密码";
            // 
            // txt_PassWord
            // 
            this.txt_PassWord.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_PassWord.Location = new System.Drawing.Point(247, 63);
            this.txt_PassWord.Name = "txt_PassWord";
            this.txt_PassWord.PasswordChar = '*';
            this.txt_PassWord.Size = new System.Drawing.Size(269, 26);
            this.txt_PassWord.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(146, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "密码";
            // 
            // txt_UserName
            // 
            this.txt_UserName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_UserName.Location = new System.Drawing.Point(247, 24);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(379, 26);
            this.txt_UserName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(132, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "登录名";
            // 
            // errorTip
            // 
            this.errorTip.ContainerControl = this;
            // 
            // Frm_UserManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 521);
            this.Controls.Add(this.tab_UseList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Frm_UserManage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_UserManager_Load);
            this.tab_UseList.ResumeLayout(false);
            this.tp_UserList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_UserList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tab_UserAdd.ResumeLayout(false);
            this.tab_UserAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorTip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_UseList;
        private System.Windows.Forms.TabPage tp_UserList;
        private System.Windows.Forms.DataGridView dgv_UserList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_Search_Type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Search_KeyWord;
        private System.Windows.Forms.TabPage tab_UserAdd;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txt_Remark;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Phone;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_RealName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Department;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_PassWordAagin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_PassWord;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn realname;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.ComboBox cbo_Unit;
    }
}