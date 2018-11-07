namespace 数据采集档案管理系统___课题版
{
    partial class Frm_PrintBox
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.view = new System.Windows.Forms.DataGridView();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.btn_StartPrint = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.打印预览PToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.字体设置SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.案卷名称ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.课题名称ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.脊背设置BToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.print = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bkb = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fm = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fmbj = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.font = new System.Windows.Forms.DataGridViewButtonColumn();
            this.jnml = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.view)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // view
            // 
            this.view.AllowUserToAddRows = false;
            this.view.AllowUserToDeleteRows = false;
            this.view.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.view.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.view.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.view.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.view.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.print,
            this.id,
            this.amount,
            this.bkb,
            this.fm,
            this.fmbj,
            this.font,
            this.jnml});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.view.DefaultCellStyle = dataGridViewCellStyle4;
            this.view.Dock = System.Windows.Forms.DockStyle.Top;
            this.view.Location = new System.Drawing.Point(0, 0);
            this.view.Name = "view";
            this.view.RowHeadersVisible = false;
            this.view.RowTemplate.Height = 23;
            this.view.Size = new System.Drawing.Size(899, 422);
            this.view.TabIndex = 2;
            this.view.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.View_CellContentClick);
            this.view.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.view_CellMouseDown);
            // 
            // btn_StartPrint
            // 
            this.btn_StartPrint.Location = new System.Drawing.Point(783, 438);
            this.btn_StartPrint.Name = "btn_StartPrint";
            this.btn_StartPrint.Size = new System.Drawing.Size(83, 30);
            this.btn_StartPrint.TabIndex = 1;
            this.btn_StartPrint.Text = "开始打印";
            this.btn_StartPrint.Click += new System.EventHandler(this.Btn_StartPrint_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打印预览PToolStripMenuItem,
            this.字体设置SToolStripMenuItem,
            this.脊背设置BToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(141, 70);
            // 
            // 打印预览PToolStripMenuItem
            // 
            this.打印预览PToolStripMenuItem.Name = "打印预览PToolStripMenuItem";
            this.打印预览PToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.打印预览PToolStripMenuItem.Text = "打印预览(&P)";
            this.打印预览PToolStripMenuItem.Click += new System.EventHandler(this.打印预览PToolStripMenuItem_Click);
            // 
            // 字体设置SToolStripMenuItem
            // 
            this.字体设置SToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.案卷名称ToolStripMenuItem,
            this.课题名称ToolStripMenuItem});
            this.字体设置SToolStripMenuItem.Name = "字体设置SToolStripMenuItem";
            this.字体设置SToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.字体设置SToolStripMenuItem.Text = "字体设置(&S)";
            // 
            // 案卷名称ToolStripMenuItem
            // 
            this.案卷名称ToolStripMenuItem.Name = "案卷名称ToolStripMenuItem";
            this.案卷名称ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.案卷名称ToolStripMenuItem.Text = "案卷名称";
            this.案卷名称ToolStripMenuItem.Click += new System.EventHandler(this.案卷名称ToolStripMenuItem_Click);
            // 
            // 课题名称ToolStripMenuItem
            // 
            this.课题名称ToolStripMenuItem.Name = "课题名称ToolStripMenuItem";
            this.课题名称ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.课题名称ToolStripMenuItem.Text = "课题名称";
            this.课题名称ToolStripMenuItem.Click += new System.EventHandler(this.课题名称ToolStripMenuItem_Click);
            // 
            // 脊背设置BToolStripMenuItem
            // 
            this.脊背设置BToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBox1});
            this.脊背设置BToolStripMenuItem.Name = "脊背设置BToolStripMenuItem";
            this.脊背设置BToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.脊背设置BToolStripMenuItem.Text = "脊背设置(&B)";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "样式一（横版）",
            "样式二（竖版）"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            this.toolStripComboBox1.DropDownClosed += new System.EventHandler(this.toolStripComboBox1_DropDownClosed);
            // 
            // print
            // 
            this.print.FillWeight = 10F;
            this.print.HeaderText = "打印";
            this.print.Name = "print";
            this.print.Visible = false;
            // 
            // id
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id.DefaultCellStyle = dataGridViewCellStyle2;
            this.id.FillWeight = 10F;
            this.id.HeaderText = "盒号";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // amount
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.amount.DefaultCellStyle = dataGridViewCellStyle3;
            this.amount.FillWeight = 13F;
            this.amount.HeaderText = "文件数";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            // 
            // bkb
            // 
            this.bkb.FillWeight = 20F;
            this.bkb.HeaderText = "卷内备考表";
            this.bkb.Name = "bkb";
            this.bkb.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // fm
            // 
            this.fm.FillWeight = 20F;
            this.fm.HeaderText = "封面&脊背";
            this.fm.Name = "fm";
            // 
            // fmbj
            // 
            this.fmbj.FillWeight = 12F;
            this.fmbj.HeaderText = "边距";
            this.fmbj.Items.AddRange(new object[] {
            "20mm",
            "30mm",
            "40mm",
            "50mm",
            "60mm",
            "80mm"});
            this.fmbj.Name = "fmbj";
            // 
            // font
            // 
            this.font.FillWeight = 15F;
            this.font.HeaderText = "字体设置";
            this.font.Name = "font";
            this.font.Text = "设置";
            this.font.UseColumnTextForButtonValue = true;
            this.font.Visible = false;
            // 
            // jnml
            // 
            this.jnml.FillWeight = 20F;
            this.jnml.HeaderText = "卷内文件目录";
            this.jnml.Name = "jnml";
            this.jnml.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Frm_PrintBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(899, 478);
            this.Controls.Add(this.view);
            this.Controls.Add(this.btn_StartPrint);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_PrintBox";
            this.Text = "案卷盒打印";
            this.Load += new System.EventHandler(this.Frm_PrintBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.view)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_StartPrint;
        private System.Windows.Forms.DataGridView view;
        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 打印预览PToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 字体设置SToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 案卷名称ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 课题名称ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 脊背设置BToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn print;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn bkb;
        private System.Windows.Forms.DataGridViewCheckBoxColumn fm;
        private System.Windows.Forms.DataGridViewComboBoxColumn fmbj;
        private System.Windows.Forms.DataGridViewButtonColumn font;
        private System.Windows.Forms.DataGridViewCheckBoxColumn jnml;
    }
}