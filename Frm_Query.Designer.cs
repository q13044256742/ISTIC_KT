namespace 数据采集档案管理系统___课题版
{
    partial class Frm_Query
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_ShowData = new System.Windows.Forms.DataGridView();
            this.lbl_Back = new System.Windows.Forms.LinkLabel();
            this.lbl_FirstPage = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShowData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_FirstPage);
            this.panel1.Controls.Add(this.lbl_Back);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(991, 65);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgv_ShowData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 65);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(991, 540);
            this.panel2.TabIndex = 1;
            // 
            // dgv_ShowData
            // 
            this.dgv_ShowData.AllowUserToAddRows = false;
            this.dgv_ShowData.AllowUserToDeleteRows = false;
            this.dgv_ShowData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_ShowData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ShowData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ShowData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ShowData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_ShowData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ShowData.Location = new System.Drawing.Point(0, 0);
            this.dgv_ShowData.Name = "dgv_ShowData";
            this.dgv_ShowData.ReadOnly = true;
            this.dgv_ShowData.RowTemplate.Height = 23;
            this.dgv_ShowData.Size = new System.Drawing.Size(991, 540);
            this.dgv_ShowData.TabIndex = 0;
            this.dgv_ShowData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ShowData_CellContentClick);
            // 
            // lbl_Back
            // 
            this.lbl_Back.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Back.AutoSize = true;
            this.lbl_Back.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_Back.Location = new System.Drawing.Point(904, 22);
            this.lbl_Back.Name = "lbl_Back";
            this.lbl_Back.Size = new System.Drawing.Size(79, 20);
            this.lbl_Back.TabIndex = 0;
            this.lbl_Back.TabStop = true;
            this.lbl_Back.Text = "返回上一级";
            this.lbl_Back.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_Back_LinkClicked);
            // 
            // lbl_FirstPage
            // 
            this.lbl_FirstPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_FirstPage.AutoSize = true;
            this.lbl_FirstPage.Location = new System.Drawing.Point(861, 22);
            this.lbl_FirstPage.Name = "lbl_FirstPage";
            this.lbl_FirstPage.Size = new System.Drawing.Size(37, 20);
            this.lbl_FirstPage.TabIndex = 1;
            this.lbl_FirstPage.TabStop = true;
            this.lbl_FirstPage.Text = "首页";
            this.lbl_FirstPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_FirstPage_LinkClicked);
            // 
            // Frm_Query
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 605);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Frm_Query";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查询统计";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_Query_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShowData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_ShowData;
        private System.Windows.Forms.LinkLabel lbl_Back;
        private System.Windows.Forms.LinkLabel lbl_FirstPage;
    }
}