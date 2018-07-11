namespace 数据采集档案管理系统___课题版
{
    partial class Frm_BoxList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pal_All = new System.Windows.Forms.Panel();
            this.pal_Show = new System.Windows.Forms.Panel();
            this.dgv_DataList = new System.Windows.Forms.DataGridView();
            this.lbl_GC = new System.Windows.Forms.Label();
            this.lbl_Code = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_proCode = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Print = new System.Windows.Forms.Button();
            this.btn_PrintSetup = new System.Windows.Forms.Button();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printDocument = new System.Drawing.Printing.PrintDocument();
            this.fb_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fb_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fb_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fb_page = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fb_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fb_remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pal_All.SuspendLayout();
            this.pal_Show.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataList)).BeginInit();
            this.SuspendLayout();
            // 
            // pal_All
            // 
            this.pal_All.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pal_All.AutoScroll = true;
            this.pal_All.BackColor = System.Drawing.Color.White;
            this.pal_All.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pal_All.Controls.Add(this.pal_Show);
            this.pal_All.Font = new System.Drawing.Font("宋体", 12F);
            this.pal_All.Location = new System.Drawing.Point(1, 0);
            this.pal_All.Name = "pal_All";
            this.pal_All.Size = new System.Drawing.Size(793, 560);
            this.pal_All.TabIndex = 0;
            // 
            // pal_Show
            // 
            this.pal_Show.BackColor = System.Drawing.Color.White;
            this.pal_Show.Controls.Add(this.panel6);
            this.pal_Show.Controls.Add(this.panel5);
            this.pal_Show.Controls.Add(this.panel4);
            this.pal_Show.Controls.Add(this.panel3);
            this.pal_Show.Controls.Add(this.lbl_GC);
            this.pal_Show.Controls.Add(this.lbl_Code);
            this.pal_Show.Controls.Add(this.lbl_Name);
            this.pal_Show.Controls.Add(this.lbl_proCode);
            this.pal_Show.Controls.Add(this.dgv_DataList);
            this.pal_Show.Controls.Add(this.label6);
            this.pal_Show.Controls.Add(this.label5);
            this.pal_Show.Controls.Add(this.label4);
            this.pal_Show.Controls.Add(this.label3);
            this.pal_Show.Controls.Add(this.label2);
            this.pal_Show.Location = new System.Drawing.Point(9, 1);
            this.pal_Show.Name = "pal_Show";
            this.pal_Show.Size = new System.Drawing.Size(717, 457);
            this.pal_Show.TabIndex = 1;
            // 
            // dgv_DataList
            // 
            this.dgv_DataList.AllowUserToAddRows = false;
            this.dgv_DataList.AllowUserToDeleteRows = false;
            this.dgv_DataList.AllowUserToResizeColumns = false;
            this.dgv_DataList.AllowUserToResizeRows = false;
            this.dgv_DataList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_DataList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dgv_DataList.BackgroundColor = System.Drawing.Color.White;
            this.dgv_DataList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_DataList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_DataList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_DataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DataList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fb_id,
            this.fb_code,
            this.fb_name,
            this.fb_page,
            this.fb_count,
            this.fb_remark});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_DataList.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_DataList.EnableHeadersVisualStyles = false;
            this.dgv_DataList.GridColor = System.Drawing.Color.Black;
            this.dgv_DataList.Location = new System.Drawing.Point(3, 293);
            this.dgv_DataList.MultiSelect = false;
            this.dgv_DataList.Name = "dgv_DataList";
            this.dgv_DataList.ReadOnly = true;
            this.dgv_DataList.RowHeadersVisible = false;
            this.dgv_DataList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_DataList.RowTemplate.Height = 23;
            this.dgv_DataList.Size = new System.Drawing.Size(711, 127);
            this.dgv_DataList.TabIndex = 13;
            // 
            // lbl_GC
            // 
            this.lbl_GC.AutoSize = true;
            this.lbl_GC.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_GC.ForeColor = System.Drawing.Color.Black;
            this.lbl_GC.Location = new System.Drawing.Point(457, 229);
            this.lbl_GC.Name = "lbl_GC";
            this.lbl_GC.Size = new System.Drawing.Size(38, 21);
            this.lbl_GC.TabIndex = 12;
            this.lbl_GC.Text = "null";
            this.lbl_GC.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbl_Code
            // 
            this.lbl_Code.AutoSize = true;
            this.lbl_Code.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Code.ForeColor = System.Drawing.Color.Black;
            this.lbl_Code.Location = new System.Drawing.Point(116, 229);
            this.lbl_Code.Name = "lbl_Code";
            this.lbl_Code.Size = new System.Drawing.Size(38, 21);
            this.lbl_Code.TabIndex = 11;
            this.lbl_Code.Text = "null";
            this.lbl_Code.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbl_Name
            // 
            this.lbl_Name.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Name.ForeColor = System.Drawing.Color.Black;
            this.lbl_Name.Location = new System.Drawing.Point(116, 157);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(548, 42);
            this.lbl_Name.TabIndex = 10;
            this.lbl_Name.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lbl_proCode
            // 
            this.lbl_proCode.AutoSize = true;
            this.lbl_proCode.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_proCode.ForeColor = System.Drawing.Color.Black;
            this.lbl_proCode.Location = new System.Drawing.Point(116, 128);
            this.lbl_proCode.Name = "lbl_proCode";
            this.lbl_proCode.Size = new System.Drawing.Size(38, 21);
            this.lbl_proCode.TabIndex = 9;
            this.lbl_proCode.Text = "null";
            this.lbl_proCode.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Black;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel6.Location = new System.Drawing.Point(457, 254);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(233, 1);
            this.panel6.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Black;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel5.Location = new System.Drawing.Point(110, 254);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(233, 1);
            this.panel5.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel4.Location = new System.Drawing.Point(110, 203);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(583, 1);
            this.panel4.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel3.ForeColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(110, 153);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(583, 1);
            this.panel3.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(376, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 22);
            this.label6.TabIndex = 4;
            this.label6.Text = "馆藏号：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(12, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 22);
            this.label5.TabIndex = 3;
            this.label5.Text = "案卷编号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "案卷名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 22);
            this.label3.TabIndex = 1;
            this.label3.Text = "项目编号：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("华文中宋", 23F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(255, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 35);
            this.label2.TabIndex = 0;
            this.label2.Text = "卷内文件目录";
            // 
            // btn_Print
            // 
            this.btn_Print.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_Print.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btn_Print.Location = new System.Drawing.Point(400, 566);
            this.btn_Print.Name = "btn_Print";
            this.btn_Print.Size = new System.Drawing.Size(75, 30);
            this.btn_Print.TabIndex = 3;
            this.btn_Print.Text = "打印";
            this.btn_Print.UseVisualStyleBackColor = false;
            this.btn_Print.Click += new System.EventHandler(this.Btn_Print_Click);
            // 
            // btn_PrintSetup
            // 
            this.btn_PrintSetup.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_PrintSetup.Location = new System.Drawing.Point(319, 566);
            this.btn_PrintSetup.Name = "btn_PrintSetup";
            this.btn_PrintSetup.Size = new System.Drawing.Size(75, 30);
            this.btn_PrintSetup.TabIndex = 4;
            this.btn_PrintSetup.Text = "打印设置";
            this.btn_PrintSetup.UseVisualStyleBackColor = true;
            this.btn_PrintSetup.Click += new System.EventHandler(this.btn_PrintSetup_Click);
            // 
            // pageSetupDialog1
            // 
            this.pageSetupDialog1.Document = this.printDocument;
            // 
            // printDocument1
            // 
            this.printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument1_PrintPage);
            // 
            // fb_id
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fb_id.DefaultCellStyle = dataGridViewCellStyle8;
            this.fb_id.FillWeight = 60F;
            this.fb_id.HeaderText = "序号";
            this.fb_id.Name = "fb_id";
            this.fb_id.ReadOnly = true;
            this.fb_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // fb_code
            // 
            this.fb_code.FillWeight = 80F;
            this.fb_code.HeaderText = "文件编号";
            this.fb_code.Name = "fb_code";
            this.fb_code.ReadOnly = true;
            this.fb_code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // fb_name
            // 
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fb_name.DefaultCellStyle = dataGridViewCellStyle9;
            this.fb_name.FillWeight = 230F;
            this.fb_name.HeaderText = "文件名称";
            this.fb_name.Name = "fb_name";
            this.fb_name.ReadOnly = true;
            this.fb_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // fb_page
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fb_page.DefaultCellStyle = dataGridViewCellStyle10;
            this.fb_page.FillWeight = 50F;
            this.fb_page.HeaderText = "页数";
            this.fb_page.Name = "fb_page";
            this.fb_page.ReadOnly = true;
            this.fb_page.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // fb_count
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fb_count.DefaultCellStyle = dataGridViewCellStyle11;
            this.fb_count.FillWeight = 50F;
            this.fb_count.HeaderText = "份数";
            this.fb_count.Name = "fb_count";
            this.fb_count.ReadOnly = true;
            this.fb_count.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // fb_remark
            // 
            this.fb_remark.FillWeight = 50F;
            this.fb_remark.HeaderText = "备注";
            this.fb_remark.Name = "fb_remark";
            this.fb_remark.ReadOnly = true;
            this.fb_remark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Frm_BoxList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 602);
            this.Controls.Add(this.btn_PrintSetup);
            this.Controls.Add(this.btn_Print);
            this.Controls.Add(this.pal_All);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_BoxList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Frm_BoxList_Load);
            this.pal_All.ResumeLayout(false);
            this.pal_Show.ResumeLayout(false);
            this.pal_Show.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DataList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pal_All;
        private System.Windows.Forms.Button btn_Print;
        private System.Windows.Forms.Panel pal_Show;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_GC;
        private System.Windows.Forms.Label lbl_Code;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_proCode;
        private System.Windows.Forms.Button btn_PrintSetup;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Drawing.Printing.PrintDocument printDocument;
        private System.Windows.Forms.DataGridView dgv_DataList;
        private System.Windows.Forms.DataGridViewTextBoxColumn fb_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fb_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn fb_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn fb_page;
        private System.Windows.Forms.DataGridViewTextBoxColumn fb_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn fb_remark;
    }
}