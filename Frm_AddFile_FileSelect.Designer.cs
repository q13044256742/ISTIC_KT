namespace 数据采集档案管理系统___课题版
{
    partial class Frm_AddFile_FileSelect
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
            this.tv_file = new System.Windows.Forms.TreeView();
            this.btn_sure = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rdo_ShowAll = new System.Windows.Forms.CheckBox();
            this.lsv_Selected = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tv_file
            // 
            this.tv_file.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_file.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tv_file.Indent = 15;
            this.tv_file.LineColor = System.Drawing.Color.DimGray;
            this.tv_file.Location = new System.Drawing.Point(2, 122);
            this.tv_file.Name = "tv_file";
            this.tv_file.Size = new System.Drawing.Size(864, 541);
            this.tv_file.TabIndex = 0;
            this.tv_file.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Tv_file_NodeMouseClick);
            this.tv_file.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.Tv_file_NodeMouseDoubleClick);
            // 
            // btn_sure
            // 
            this.btn_sure.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_sure.Location = new System.Drawing.Point(397, 670);
            this.btn_sure.Name = "btn_sure";
            this.btn_sure.Size = new System.Drawing.Size(75, 31);
            this.btn_sure.TabIndex = 1;
            this.btn_sure.Text = "确定";
            this.btn_sure.UseVisualStyleBackColor = true;
            this.btn_sure.Click += new System.EventHandler(this.Btn_sure_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(2, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "当前已选择：";
            // 
            // rdo_ShowAll
            // 
            this.rdo_ShowAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdo_ShowAll.AutoSize = true;
            this.rdo_ShowAll.Location = new System.Drawing.Point(792, 4);
            this.rdo_ShowAll.Name = "rdo_ShowAll";
            this.rdo_ShowAll.Size = new System.Drawing.Size(72, 16);
            this.rdo_ShowAll.TabIndex = 4;
            this.rdo_ShowAll.Text = "全部显示";
            this.rdo_ShowAll.UseVisualStyleBackColor = true;
            this.rdo_ShowAll.CheckedChanged += new System.EventHandler(this.rdo_ShowAll_CheckedChanged);
            // 
            // lsv_Selected
            // 
            this.lsv_Selected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsv_Selected.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.lsv_Selected.Location = new System.Drawing.Point(2, 26);
            this.lsv_Selected.Name = "lsv_Selected";
            this.lsv_Selected.Size = new System.Drawing.Size(864, 95);
            this.lsv_Selected.TabIndex = 5;
            this.lsv_Selected.UseCompatibleStateImageBehavior = false;
            this.lsv_Selected.View = System.Windows.Forms.View.List;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(7, 679);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "（注：按 Ctrl + 鼠标左键可多选）";
            // 
            // Frm_AddFile_FileSelect
            // 
            this.AcceptButton = this.btn_sure;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 711);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lsv_Selected);
            this.Controls.Add(this.rdo_ShowAll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_sure);
            this.Controls.Add(this.tv_file);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_AddFile_FileSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件选择";
            this.Load += new System.EventHandler(this.Frm_AddFile_FileSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tv_file;
        private System.Windows.Forms.Button btn_sure;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox rdo_ShowAll;
        private System.Windows.Forms.ListView lsv_Selected;
        private System.Windows.Forms.Label label2;
    }
}