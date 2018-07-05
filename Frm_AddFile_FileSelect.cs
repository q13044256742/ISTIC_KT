﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using 数据采集档案管理系统___课题版.Properties;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_AddFile_FileSelect : Form
    {
        public string SelectedFileName;
        public string SelectedFileId;
        /// <summary>
        /// <para>0：默认文件夹</para>
        /// <para>1：小锁</para>
        /// <para>2：默认文件</para>
        /// <para>3：WORD</para>
        /// <para>4：EXCEL</para>
        /// <para>5：PDF</para>
        /// </summary>
        private ImageList imageList;

        private object[] rootId;
        public Frm_AddFile_FileSelect(object[] rootId)
        {
            InitializeComponent();
            this.rootId = rootId;
            LoadRootTree(rdo_ShowAll.Checked);
        }

        /// <summary>
        /// 加载根节点树（调用树节点方法）
        /// </summary>
        /// <param name="isShowAll">是否显示已加工节点</param>
        private void LoadRootTree(bool isShowAll)
        {
            tv_file.Nodes.Clear();
            for(int i = 0; i < rootId.Length; i++)
            {
                object[] objs = SQLiteHelper.ExecuteRowsQuery($"SELECT bfi_id, bfi_name, bfi_path, bfi_type FROM backup_files_info WHERE bfi_id='{rootId[i]}'");
                TreeNode treeNode = new TreeNode()
                {
                    Name = GetValue(objs[0]),
                    Text = GetValue(objs[1]),
                    Tag = GetValue(objs[2]),
                    ToolTipText = GetValue(objs[3]),
                };
                tv_file.Nodes.Add(treeNode);
                InitialTree(rootId[i], treeNode, isShowAll);
            }
            if(tv_file.Nodes.Count > 0)
            {
                tv_file.Nodes[0].Expand();
                if(!rdo_ShowAll.Checked)
                {
                    ClearHasWordedWithFolder(tv_file.Nodes[0]);
                }
            }
        }

        /// <summary>
        /// 判断指定文件夹节点下的所有文件是否全部已加工，如果是，则移除此文件夹
        /// </summary>
        private bool ClearHasWordedWithFolder(TreeNode node)
        {
            bool result = true;
            bool flag = true;
            foreach(TreeNode item in node.Nodes)
            {
                int type = Convert.ToInt32(item.ToolTipText);//0:文件 1:文件夹
                if(type == 0)//当前文件夹下存在文件的情况下，无论其子文件夹是否被删除，当前节点都不删除
                    flag = false;
                else if(type == 1)
                    result = ClearHasWordedWithFolder(item);
            }
            if(result)
            {
                foreach(TreeNode item in node.Nodes)
                {
                    int type = Convert.ToInt32(item.ToolTipText);//0:文件 1:文件夹
                    int state = item.ImageIndex;//3:已加工
                    if(type == 0 && state != 3)
                    {
                        result = false;
                        break;
                    }
                }
            }
            if(result && flag)
            {
                if(!string.IsNullOrEmpty(GetValue(node.Tag)))//批次名称永不消逝
                {
                    node.Remove();
                }
            }
            return result;
        }

        private string GetValue(object v) => v == null ? string.Empty : v.ToString();

        /// <summary>
        /// 生成树节点
        /// </summary>
        /// <param name="parentId">父级节点ID</param>
        /// <param name="parentNode">父级节点</param>
        /// <param name="isShowAll">是否显示已加工节点</param>
        private void InitialTree(object parentId, TreeNode parentNode, bool isShowAll)
        {
            List<object[]> list = SQLiteHelper.ExecuteColumnsQuery($"SELECT bfi_id, bfi_name, bfi_path, bfi_state, bfi_type FROM backup_files_info WHERE bfi_pid='{parentId}' ORDER BY rowid", 5);
            for(int i = 0; i < list.Count; i++)
            {
                int state = Convert.ToInt32(list[i][3]);
                if(state != 1 || isShowAll)
                {
                    int imageIndex = GetFileIconIndex(state, GetValue(list[i][1]));
                    TreeNode treeNode = new TreeNode()
                    {
                        Name = GetValue(list[i][0]),
                        Text = GetValue(list[i][1]),
                        Tag = GetValue(list[i][2]),
                        ImageIndex = imageIndex,
                        SelectedImageIndex = imageIndex,
                        ToolTipText = GetValue(list[i][4]),
                        StateImageKey = state.ToString(),
                    };
                    parentNode.Nodes.Add(treeNode);
                    InitialTree(treeNode.Name, treeNode, isShowAll);
                }
            }
        }

        private int GetFileIconIndex(int state, string fileName)
        {
            //小锁
            if(state == 1)
                return 1;
            else
            {
                string format = Path.GetExtension(fileName).ToUpper();
                if(".DOC".Equals(format) || ".DOCX".Equals(format))
                    return 3;
                else if(".XLS".Equals(format) || ".XLSX".Equals(format))
                    return 4;
                else if(".PDF".Equals(format))
                    return 5;
                else if(".RAR".Equals(format))
                    return 6;
            }
            return 2;
        }

        private void Frm_AddFile_FileSelect_Load(object sender, EventArgs e)
        {
            imageList = new ImageList();
            imageList.Images.AddRange(new System.Drawing.Image[] {
                Resources.file2, Resources._lock, Resources.file, Resources.doc, Resources.xsl, Resources.pdf, Resources.rar
            });
            tv_file.ImageList = imageList;
        }


        private void Tv_file_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            int type = Convert.ToInt32(node.ToolTipText);//0:文件 1:文件夹
            string state = node.StateImageKey;//1:已加工
            if(type == 0 && !"1".Equals(state))
            {
                SelectedFileId = node.Name;
                lbl_filename.Text = node.Text;
                SelectedFileName = node.Tag + "\\" + node.Text;
            }
            else
            {
                lbl_filename.Text = string.Empty;
                SelectedFileName = string.Empty;
                SelectedFileId = string.Empty;
            }
        }

        private void Btn_sure_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(SelectedFileName))
                DialogResult = DialogResult.OK;
            Close();
        }

        private void rdo_ShowAll_CheckedChanged(object sender, EventArgs e)
        {
            LoadRootTree(rdo_ShowAll.Checked);
        }

        private void Tv_file_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                if(!string.IsNullOrEmpty(SelectedFileName))
                    Btn_sure_Click(null, null);
        }
    }
}
