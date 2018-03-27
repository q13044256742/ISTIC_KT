namespace 数据采集档案管理系统___课题版
{
    partial class Frm_DictionaryManage
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gro_Tool = new System.Windows.Forms.GroupBox();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Modify = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_SearchType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_SearchKey = new System.Windows.Forms.TextBox();
            this.gro_List = new System.Windows.Forms.GroupBox();
            this.dgv_DataList = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gro_Tool.SuspendLayout();
            this.gro_List.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataList)).BeginInit();
            this.SuspendLayout();
            // 
            // gro_Tool
            // 
            this.gro_Tool.Controls.Add(this.btn_Back);
            this.gro_Tool.Controls.Add(this.btn_Delete);
            this.gro_Tool.Controls.Add(this.btn_Modify);
            this.gro_Tool.Controls.Add(this.btn_Add);
            this.gro_Tool.Controls.Add(this.btn_Search);
            this.gro_Tool.Controls.Add(this.label1);
            this.gro_Tool.Controls.Add(this.cbo_SearchType);
            this.gro_Tool.Controls.Add(this.label2);
            this.gro_Tool.Controls.Add(this.txt_SearchKey);
            this.gro_Tool.Dock = System.Windows.Forms.DockStyle.Top;
            this.gro_Tool.Location = new System.Drawing.Point(0, 0);
            this.gro_Tool.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gro_Tool.Name = "gro_Tool";
            this.gro_Tool.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gro_Tool.Size = new System.Drawing.Size(894, 66);
            this.gro_Tool.TabIndex = 21;
            this.gro_Tool.TabStop = false;
            this.gro_Tool.Text = "快速检索";
            // 
            // btn_Back
            // 
            this.btn_Back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Back.AutoSize = true;
            this.btn_Back.Location = new System.Drawing.Point(807, 23);
            this.btn_Back.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(73, 30);
            this.btn_Back.TabIndex = 13;
            this.btn_Back.Text = "返回";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Delete.AutoSize = true;
            this.btn_Delete.Location = new System.Drawing.Point(733, 23);
            this.btn_Delete.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(73, 30);
            this.btn_Delete.TabIndex = 12;
            this.btn_Delete.Text = "删除";
            this.btn_Delete.UseVisualStyleBackColor = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Modify
            // 
            this.btn_Modify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Modify.AutoSize = true;
            this.btn_Modify.Location = new System.Drawing.Point(657, 23);
            this.btn_Modify.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Size = new System.Drawing.Size(73, 30);
            this.btn_Modify.TabIndex = 11;
            this.btn_Modify.Text = "修改";
            this.btn_Modify.UseVisualStyleBackColor = true;
            this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Add.AutoSize = true;
            this.btn_Add.Location = new System.Drawing.Point(583, 23);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(73, 30);
            this.btn_Add.TabIndex = 10;
            this.btn_Add.Text = "新增";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Search
            // 
            this.btn_Search.AutoSize = true;
            this.btn_Search.Location = new System.Drawing.Point(464, 23);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(73, 30);
            this.btn_Search.TabIndex = 9;
            this.btn_Search.Text = "查询";
            this.btn_Search.UseVisualStyleBackColor = true;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(28, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "按";
            // 
            // cbo_SearchType
            // 
            this.cbo_SearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_SearchType.FormattingEnabled = true;
            this.cbo_SearchType.Items.AddRange(new object[] {
            "名称",
            "描述",
            "排序"});
            this.cbo_SearchType.Location = new System.Drawing.Point(54, 24);
            this.cbo_SearchType.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbo_SearchType.Name = "cbo_SearchType";
            this.cbo_SearchType.Size = new System.Drawing.Size(110, 28);
            this.cbo_SearchType.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(174, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "检索";
            // 
            // txt_SearchKey
            // 
            this.txt_SearchKey.Location = new System.Drawing.Point(231, 25);
            this.txt_SearchKey.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txt_SearchKey.Name = "txt_SearchKey";
            this.txt_SearchKey.Size = new System.Drawing.Size(215, 26);
            this.txt_SearchKey.TabIndex = 8;
            // 
            // gro_List
            // 
            this.gro_List.Controls.Add(this.dgv_DataList);
            this.gro_List.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gro_List.Location = new System.Drawing.Point(0, 66);
            this.gro_List.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gro_List.Name = "gro_List";
            this.gro_List.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gro_List.Size = new System.Drawing.Size(894, 428);
            this.gro_List.TabIndex = 22;
            this.gro_List.TabStop = false;
            this.gro_List.Text = "字段列表";
            // 
            // dgv_DataList
            // 
            this.dgv_DataList.AllowUserToAddRows = false;
            this.dgv_DataList.AllowUserToDeleteRows = false;
            this.dgv_DataList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_DataList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_DataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DataList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.code,
            this.intro,
            this.sort});
            this.dgv_DataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_DataList.Location = new System.Drawing.Point(3, 24);
            this.dgv_DataList.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.dgv_DataList.Name = "dgv_DataList";
            this.dgv_DataList.ReadOnly = true;
            this.dgv_DataList.RowTemplate.Height = 23;
            this.dgv_DataList.Size = new System.Drawing.Size(888, 399);
            this.dgv_DataList.TabIndex = 1;
            this.dgv_DataList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_DataList_CellMouseDoubleClick);
            // 
            // id
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id.DefaultCellStyle = dataGridViewCellStyle8;
            this.id.FillWeight = 50F;
            this.id.HeaderText = "序号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // name
            // 
            this.name.HeaderText = "名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // code
            // 
            this.code.HeaderText = "编码";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Visible = false;
            // 
            // intro
            // 
            this.intro.FillWeight = 150F;
            this.intro.HeaderText = "描述";
            this.intro.Name = "intro";
            this.intro.ReadOnly = true;
            // 
            // sort
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.sort.DefaultCellStyle = dataGridViewCellStyle9;
            this.sort.FillWeight = 50F;
            this.sort.HeaderText = "排序";
            this.sort.Name = "sort";
            this.sort.ReadOnly = true;
            // 
            // Frm_DictionaryManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 494);
            this.Controls.Add(this.gro_List);
            this.Controls.Add(this.gro_Tool);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "Frm_DictionaryManage";
            this.Text = "字典管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LoadDataList);
            this.gro_Tool.ResumeLayout(false);
            this.gro_Tool.PerformLayout();
            this.gro_List.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gro_Tool;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Modify;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbo_SearchType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_SearchKey;
        private System.Windows.Forms.GroupBox gro_List;
        private System.Windows.Forms.DataGridView dgv_DataList;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn intro;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort;
    }
}