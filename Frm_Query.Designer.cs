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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_ShowData = new System.Windows.Forms.DataGridView();
            this.btn_Query = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbo_QueryType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_QueryKey = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ShowData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_QueryKey);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbo_QueryType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_Query);
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
            this.panel2.Size = new System.Drawing.Size(991, 432);
            this.panel2.TabIndex = 1;
            // 
            // dgv_ShowData
            // 
            this.dgv_ShowData.AllowUserToAddRows = false;
            this.dgv_ShowData.AllowUserToDeleteRows = false;
            this.dgv_ShowData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ShowData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ShowData.Location = new System.Drawing.Point(0, 0);
            this.dgv_ShowData.Name = "dgv_ShowData";
            this.dgv_ShowData.ReadOnly = true;
            this.dgv_ShowData.RowTemplate.Height = 23;
            this.dgv_ShowData.Size = new System.Drawing.Size(991, 432);
            this.dgv_ShowData.TabIndex = 0;
            // 
            // btn_Query
            // 
            this.btn_Query.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btn_Query.Location = new System.Drawing.Point(472, 19);
            this.btn_Query.Name = "btn_Query";
            this.btn_Query.Size = new System.Drawing.Size(96, 30);
            this.btn_Query.TabIndex = 0;
            this.btn_Query.Text = "查询";
            this.btn_Query.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(22, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "按";
            // 
            // cbo_QueryType
            // 
            this.cbo_QueryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_QueryType.FormattingEnabled = true;
            this.cbo_QueryType.Location = new System.Drawing.Point(48, 21);
            this.cbo_QueryType.Name = "cbo_QueryType";
            this.cbo_QueryType.Size = new System.Drawing.Size(131, 28);
            this.cbo_QueryType.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(181, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "检索";
            // 
            // txt_QueryKey
            // 
            this.txt_QueryKey.Location = new System.Drawing.Point(221, 21);
            this.txt_QueryKey.Name = "txt_QueryKey";
            this.txt_QueryKey.Size = new System.Drawing.Size(208, 26);
            this.txt_QueryKey.TabIndex = 4;
            // 
            // Frm_Query
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 497);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
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
        private System.Windows.Forms.TextBox txt_QueryKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbo_QueryType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Query;
    }
}