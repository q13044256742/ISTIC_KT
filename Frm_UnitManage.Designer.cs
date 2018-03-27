namespace 数据采集档案管理系统___课题版
{
    partial class Frm_UnitManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tab_Menu = new System.Windows.Forms.TabControl();
            this.tp_UnitList = new System.Windows.Forms.TabPage();
            this.dgv_DataList = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_UnitList_SearchType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tp_UnitEdit = new System.Windows.Forms.TabPage();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.txt_Intro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Code = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tab_Menu.SuspendLayout();
            this.tp_UnitList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tp_UnitEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_Menu
            // 
            this.tab_Menu.Controls.Add(this.tp_UnitList);
            this.tab_Menu.Controls.Add(this.tp_UnitEdit);
            this.tab_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab_Menu.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tab_Menu.Location = new System.Drawing.Point(0, 0);
            this.tab_Menu.Name = "tab_Menu";
            this.tab_Menu.SelectedIndex = 0;
            this.tab_Menu.Size = new System.Drawing.Size(834, 461);
            this.tab_Menu.TabIndex = 2;
            this.tab_Menu.SelectedIndexChanged += new System.EventHandler(this.tab_Menu_TabIndexChanged);
            // 
            // tp_UnitList
            // 
            this.tp_UnitList.Controls.Add(this.dgv_DataList);
            this.tp_UnitList.Controls.Add(this.groupBox1);
            this.tp_UnitList.Location = new System.Drawing.Point(4, 29);
            this.tp_UnitList.Name = "tp_UnitList";
            this.tp_UnitList.Padding = new System.Windows.Forms.Padding(3);
            this.tp_UnitList.Size = new System.Drawing.Size(826, 428);
            this.tp_UnitList.TabIndex = 0;
            this.tp_UnitList.Text = "专项列表";
            this.tp_UnitList.UseVisualStyleBackColor = true;
            // 
            // dgv_DataList
            // 
            this.dgv_DataList.AllowUserToAddRows = false;
            this.dgv_DataList.AllowUserToDeleteRows = false;
            this.dgv_DataList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_DataList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_DataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DataList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.code,
            this.intro,
            this.sort});
            this.dgv_DataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DataList.Location = new System.Drawing.Point(3, 64);
            this.dgv_DataList.Name = "dgv_DataList";
            this.dgv_DataList.ReadOnly = true;
            this.dgv_DataList.RowTemplate.Height = 23;
            this.dgv_DataList.Size = new System.Drawing.Size(820, 361);
            this.dgv_DataList.TabIndex = 1;
            this.dgv_DataList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // id
            // 
            this.id.FillWeight = 50F;
            this.id.HeaderText = "序号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // name
            // 
            this.name.FillWeight = 200F;
            this.name.HeaderText = "专项名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // code
            // 
            this.code.FillWeight = 150F;
            this.code.HeaderText = "编码";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // intro
            // 
            this.intro.FillWeight = 200F;
            this.intro.HeaderText = "描述";
            this.intro.Name = "intro";
            this.intro.ReadOnly = true;
            // 
            // sort
            // 
            this.sort.FillWeight = 80F;
            this.sort.HeaderText = "排序";
            this.sort.Name = "sort";
            this.sort.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbo_UnitList_SearchType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(820, 61);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "快速查询";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(402, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 31);
            this.button1.TabIndex = 9;
            this.button1.Text = "查询(&F)";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(25, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "按";
            // 
            // cbo_UnitList_SearchType
            // 
            this.cbo_UnitList_SearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_UnitList_SearchType.FormattingEnabled = true;
            this.cbo_UnitList_SearchType.Items.AddRange(new object[] {
            "专项名称",
            "编码",
            "描述",
            "排序"});
            this.cbo_UnitList_SearchType.Location = new System.Drawing.Point(56, 22);
            this.cbo_UnitList_SearchType.Name = "cbo_UnitList_SearchType";
            this.cbo_UnitList_SearchType.Size = new System.Drawing.Size(97, 28);
            this.cbo_UnitList_SearchType.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(159, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "检索";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(219, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(163, 26);
            this.textBox1.TabIndex = 8;
            // 
            // tp_UnitEdit
            // 
            this.tp_UnitEdit.AutoScroll = true;
            this.tp_UnitEdit.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tp_UnitEdit.Controls.Add(this.btn_Reset);
            this.tp_UnitEdit.Controls.Add(this.btn_Save);
            this.tp_UnitEdit.Controls.Add(this.txt_Intro);
            this.tp_UnitEdit.Controls.Add(this.label9);
            this.tp_UnitEdit.Controls.Add(this.txt_Code);
            this.tp_UnitEdit.Controls.Add(this.label4);
            this.tp_UnitEdit.Controls.Add(this.txt_Name);
            this.tp_UnitEdit.Controls.Add(this.label3);
            this.tp_UnitEdit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tp_UnitEdit.Location = new System.Drawing.Point(4, 29);
            this.tp_UnitEdit.Name = "tp_UnitEdit";
            this.tp_UnitEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tp_UnitEdit.Size = new System.Drawing.Size(826, 428);
            this.tp_UnitEdit.TabIndex = 1;
            this.tp_UnitEdit.Text = "专项添加";
            // 
            // btn_Reset
            // 
            this.btn_Reset.Location = new System.Drawing.Point(304, 351);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(94, 33);
            this.btn_Reset.TabIndex = 19;
            this.btn_Reset.Text = "重置(&R)";
            this.btn_Reset.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(428, 351);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(94, 33);
            this.btn_Save.TabIndex = 18;
            this.btn_Save.Text = "保存(&S)";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // txt_Intro
            // 
            this.txt_Intro.Location = new System.Drawing.Point(212, 122);
            this.txt_Intro.Multiline = true;
            this.txt_Intro.Name = "txt_Intro";
            this.txt_Intro.Size = new System.Drawing.Size(379, 174);
            this.txt_Intro.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(147, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 19);
            this.label9.TabIndex = 16;
            this.label9.Text = "简介";
            // 
            // txt_Code
            // 
            this.txt_Code.Location = new System.Drawing.Point(212, 69);
            this.txt_Code.Name = "txt_Code";
            this.txt_Code.Size = new System.Drawing.Size(379, 26);
            this.txt_Code.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(117, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 19);
            this.label4.TabIndex = 2;
            this.label4.Text = "专项编码";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(212, 23);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(379, 26);
            this.txt_Name.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(117, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "专项名称";
            // 
            // Frm_UnitManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.tab_Menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Frm_UnitManage";
            this.Text = "单位信息管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_UnitManage_Load);
            this.tab_Menu.ResumeLayout(false);
            this.tp_UnitList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tp_UnitEdit.ResumeLayout(false);
            this.tp_UnitEdit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_Menu;
        private System.Windows.Forms.TabPage tp_UnitList;
        private System.Windows.Forms.TabPage tp_UnitEdit;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox txt_Intro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Code;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_DataList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_UnitList_SearchType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn intro;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort;
    }
}