using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{

    public partial class Frm_MainFrame : Form
    {
        public Frm_MainFrame()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Pic_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = (sender as PictureBox).Parent as Panel;
            panel.BackColor = System.Drawing.Color.FromName("control");
            Cursor = Cursors.Default;
        }

        private void Pic_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = (sender as PictureBox).Parent as Panel;
            panel.BackColor = System.Drawing.Color.Gainsboro;
            Cursor = Cursors.Hand;
        }

        private void Pic_Add_Click(object sender, EventArgs e)
        {
            TreeNode node = new TreeNode() { Name = UserHelper.GetUser().SpecialId, Tag = ControlType.Plan_Project };
            Frm_Wroking frm_Wroking = new Frm_Wroking(node, LoadTreeList);
            frm_Wroking.Show();
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if(dgv_DataList.SelectedRows.Count > 0)
            {
                string ids = string.Empty;
                int count = 0;
                foreach(DataGridViewRow row in dgv_DataList.SelectedRows)
                {
                    object id = row.Cells["id"].Tag;
                    bool hasChild = HasChild((ControlType)row.Tag, id);
                    if(hasChild)
                        if(MessageBox.Show("编号【" + row.Cells["code"].Value + "】下存在子数据，确认将其全部删除?", "删除确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel)
                            continue;
                    ids += $"'{id}',";
                    count++;
                }
                if(count > 0 && MessageBox.Show($"确认删除指定共{count}条数据?", "确认提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    ids = ids.Substring(0, ids.Length - 1);
                    SQLiteHelper.ExecuteNonQuery(
                        $"DELETE FROM project_info WHERE pi_id IN({ids});" +
                        $"DELETE FROM topic_info WHERE ti_obj_id IN({ids});" +
                        $"DELETE FROM subject_info WHERE si_obj_id IN({ids});" +
                        $"DELETE FROM topic_info WHERE ti_id IN({ids});" +
                        $"DELETE FROM subject_info WHERE si_id IN({ids});");

                    MessageBox.Show("删除成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    btn_Refresh_Click(sender, e);
                }
            }
        }

        private bool HasChild(ControlType type, object id)
        {
            int index = 0;
            if(type == ControlType.Plan_Project)
            {
                index = SQLiteHelper.ExecuteCountQuery($"SELECT COUNT(ti_id) FROM topic_info WHERE ti_obj_id='{id}'");
                if(index == 0)
                    index = SQLiteHelper.ExecuteCountQuery($"SELECT COUNT(si_id) FROM subject_info WHERE si_obj_id='{id}'");
            }
            else if(type == ControlType.Plan_Topic || type == ControlType.Topic)
            {
                index = index = SQLiteHelper.ExecuteCountQuery($"SELECT COUNT(si_id) FROM subject_info WHERE si_obj_id='{id}'");
            }
            return index == 0 ? false : true;
        }

        private void Btn_Query_Click(object sender, EventArgs e)
        {
            int count = dgv_DataList.RowCount;
            string queryCode = txt_Query_Code.Text;
            string queryName = txt_Query_Name.Text;
            foreach(DataGridViewRow item in dgv_DataList.Rows)
                item.Visible = true;
            if(!string.IsNullOrEmpty(queryCode))
                foreach(DataGridViewRow item in dgv_DataList.Rows)
                    if(!GetValue(item.Cells["code"].Value).Contains(queryCode))
                    {
                        item.Visible = false;
                        count--;
                    }
            if(!string.IsNullOrEmpty(queryName))
                foreach(DataGridViewRow item in dgv_DataList.Rows)
                    if(!GetValue(item.Cells["name"].Value).Contains(queryName))
                    {
                        item.Visible = false;
                        count--;
                    }
        }

        private void Pic_Import_Click(object sender, EventArgs e)
        {
            if(new Frm_Import().ShowDialog() == DialogResult.OK)
            {
                btn_Refresh_Click(null, null);
            }
        }

        private void Frm_MainFrame_Shown(object sender, EventArgs e)
        {
            string querySql = $"SELECT ui_special_id FROM user_info WHERE ui_id='{UserHelper.GetUser().UserId}'";
            object obj = SQLiteHelper.ExecuteOnlyOneQuery(querySql);
            if(obj == null)
            {
                Frm_IdentityChoose frm_Identity = new Frm_IdentityChoose();
                if(frm_Identity.ShowDialog() == DialogResult.OK)
                {
                    obj = SQLiteHelper.ExecuteOnlyOneQuery(querySql);
                    new Frm_Explain().ShowDialog();
                }
            }
            if(obj != null)
            {

                UserHelper.GetUser().SpecialId = GetValue(obj);
                UserHelper.GetUser().SpecialName = SQLiteHelper.GetValueByKey(obj);

                object unitName = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT ui_department FROM user_info WHERE ui_id='{UserHelper.GetUser().UserId}'");
                UserHelper.GetUser().UserUnitName = GetValue(unitName);

                LoadTreeList(UserHelper.GetUser().SpecialId);

                NodeMouseClick(sender, new TreeNodeMouseClickEventArgs(tv_DataTree.Nodes[0], MouseButtons.Left, 1, 0, 0));
                LoadStateTip();

                lbl_UserName.Text = UserHelper.GetUser().RealName;
                lbl_UserUnit.Text = UserHelper.GetUser().UserUnitName;
            }
        }
        
        /// <summary>
        /// 加载目录树
        /// </summary>
        /// <param name="specialId">专项ID</param>
        public void LoadTreeList(object specialId)
        {
            tv_DataTree.Nodes.Clear();
            TreeNode rootNode = null;
            //【计划】
            DataRow row = SQLiteHelper.ExecuteSingleRowQuery($"SELECT dd_id, dd_code, dd_name FROM data_dictionary WHERE dd_id='{specialId ?? UserHelper.GetUser().SpecialId}'");
            if(row != null)
            {
                rootNode = new TreeNode()
                {
                    Name = GetValue(row["dd_id"]),
                    Text = GetValue(row["dd_name"]) + "    ",
                    Tag = ControlType.Plan,
                    NodeFont = new System.Drawing.Font("微软雅黑", 10f)
                };
                //【项目】
                DataTable projectTable = SQLiteHelper.ExecuteQuery($"SELECT pi_id, pi_code, pi_name FROM project_info WHERE pi_obj_id='{rootNode.Name}'");
                for(int i = 0; i < projectTable.Rows.Count; i++)
                {
                    TreeNode treeNode = new TreeNode()
                    {
                        Name = GetValue(projectTable.Rows[i]["pi_id"]),
                        Text = GetValue(projectTable.Rows[i]["pi_code"]),
                        Tag = ControlType.Plan_Project
                    };
                    rootNode.Nodes.Add(treeNode);
                    //【课题】
                    DataTable table2 = SQLiteHelper.ExecuteQuery($"SELECT ti_id, ti_code, ti_name FROM topic_info WHERE ti_obj_id='{treeNode.Name}' ORDER BY ti_code");
                    for(int j = 0; j < table2.Rows.Count; j++)
                    {
                        TreeNode treeNode2 = new TreeNode()
                        {
                            Name = GetValue(table2.Rows[j]["ti_id"]),
                            Text = GetValue(table2.Rows[j]["ti_code"]),
                            Tag = ControlType.Plan_Topic
                        };
                        treeNode.Nodes.Add(treeNode2);
                        //【子课题】
                        DataTable table3 = SQLiteHelper.ExecuteQuery($"SELECT si_id, si_code, si_name FROM subject_info WHERE si_obj_id='{treeNode2.Name}' ORDER BY si_code");
                        for(int k = 0; k < table3.Rows.Count; k++)
                        {
                            treeNode2.Nodes.Add(new TreeNode()
                            {
                                Name = GetValue(table3.Rows[k]["si_id"]),
                                Text = GetValue(table3.Rows[k]["si_code"]),
                                Tag = ControlType.Plan_Topic_Subject
                            });
                        }
                    }
                    //【子课题】
                    DataTable table4 = SQLiteHelper.ExecuteQuery($"SELECT si_id, si_code, si_name FROM subject_info WHERE si_obj_id='{treeNode.Name}' ORDER BY si_code");
                    for(int k = 0; k < table4.Rows.Count; k++)
                    {
                        treeNode.Nodes.Add(new TreeNode()
                        {
                            Name = GetValue(table4.Rows[k]["si_id"]),
                            Text = GetValue(table4.Rows[k]["si_code"]),
                            Tag = ControlType.Plan_Topic_Subject
                        });
                    }
                }
                //【课题】
                DataTable topicTable = SQLiteHelper.ExecuteQuery($"SELECT ti_id, ti_code, ti_name FROM topic_info WHERE ti_obj_id='{rootNode.Name}'");
                for(int j = 0; j < topicTable.Rows.Count; j++)
                {
                    TreeNode treeNode = new TreeNode()
                    {
                        Name = GetValue(topicTable.Rows[j]["ti_id"]),
                        Text = GetValue(topicTable.Rows[j]["ti_code"]),
                        Tag = ControlType.Topic
                    };
                    rootNode.Nodes.Add(treeNode);
                    //【子课题】
                    DataTable table3 = SQLiteHelper.ExecuteQuery($"SELECT si_id, si_code, si_name FROM subject_info WHERE si_obj_id='{treeNode.Name}' ORDER BY si_code");
                    for(int k = 0; k < table3.Rows.Count; k++)
                    {
                        treeNode.Nodes.Add(new TreeNode()
                        {
                            Name = GetValue(table3.Rows[k]["si_id"]),
                            Text = GetValue(table3.Rows[k]["si_code"]),
                            Tag = ControlType.Plan_Topic_Subject
                        });
                    }
                }
                tv_DataTree.Nodes.Add(rootNode);
            }
            tv_DataTree.ExpandAll();

            LoadStateTip();
        }

        private void Frm_MainFrame_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("确定要退出吗？", "确认提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                Environment.Exit(0);
            else
                e.Cancel = true;
        }

        private void Dgv_DataList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1 && e.ColumnIndex != -1)
            {

            }
        }

        private void pic_Manager_Click(object sender, EventArgs e)
        {
            string specialId = UserHelper.GetUser().SpecialId;
            if(!string.IsNullOrEmpty(specialId))
            {
                Frm_Manager manager = new Frm_Manager(specialId);
                manager.ShowDialog();
            }
            else
                MessageBox.Show("当前用户尚未指定专项。");
        }

        private void pic_Export_Click(object sender, EventArgs e)
        {
            Frm_Export frm_Export = new Frm_Export();
            frm_Export.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确定要备份当前系统数据吗？", "确认提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                object KEY = "SAVE_PATH";
                object value = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT dd_name FROM data_dictionary WHERE dd_code='{KEY}'");
                if(value != null)
                {
                    string destPath = value + $"\\ISTIC_{DateTime.Now.ToString("yyyyMMddHHmm")}.db";
                    if(!Directory.Exists(Path.GetDirectoryName(destPath)))
                        Directory.CreateDirectory(Path.GetDirectoryName(destPath));
                    if(!File.Exists(destPath))
                        File.Create(destPath).Close();
                    string sourFile = Application.StartupPath + @"\ISTIC.db";
                    File.Copy(sourFile, destPath, true);
                    MessageBox.Show("备份完毕。", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                    MessageBox.Show("尚未指定数据存放路径。", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void pic_Editpassword(object sender, EventArgs e)
        {
            Frm_EditPassword frm_EditPassword = new Frm_EditPassword();
            frm_EditPassword.ShowDialog();
        }

        private string GetValue(object obj) => obj == null ? string.Empty : obj.ToString();

        private void Tv_DataTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                if(!e.Node.Tag.Equals(ControlType.Plan))
                {
                    Frm_Wroking frm = new Frm_Wroking(e.Node, LoadTreeList);
                    frm.Show();
                }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            int index = dgv_DataList.SelectedRows.Count;
            if(index == 1)
            {
                new Frm_Wroking(new TreeNode()
                {
                    Name = GetValue(dgv_DataList.CurrentRow.Cells["id"].Tag),
                    Tag = dgv_DataList.CurrentRow.Tag
                }, LoadTreeList).Show();
            }
        }

        /// <summary>
        /// 获取对象的文件数（纸本和电子）
        /// </summary>
        /// <param name="objid">对象主键</param>
        /// <param name="isPaper">是否纸本</param>
        /// <returns>文件数量</returns>
        private object GetFileAmount(object objid, bool isPaper)
        {
            string querySql = $"SELECT COUNT(*) FROM files_info fi LEFT JOIN data_dictionary dd ON fi.fi_carrier = dd.dd_id WHERE fi.fi_obj_id='{objid}' ";
            if(isPaper)
                querySql += "AND (dd_code = 'ZT_ZZ' OR dd_code = 'ZT_ALL')";
            else
                querySql += "AND (dd_code = 'ZT_DZ' OR dd_code = 'ZT_ALL')";
            return SQLiteHelper.ExecuteOnlyOneQuery(querySql); ;
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadTreeList(tv_DataTree.Nodes[0].Name);
            NodeMouseClick(sender, new TreeNodeMouseClickEventArgs(tv_DataTree.Nodes[0], MouseButtons.Left, 1, 0, 0));
        }

        private void pic_Query_Click(object sender, EventArgs e)
        {
            new Frm_Query(UserHelper.GetUser().SpecialId).ShowDialog();
        }

        private void pic_Exit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("确定要注销当前登录用户吗?", "确认提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Hide();
                new Frm_Login().Show();
            }
        }

        private void LoadStateTip()
        {
            int totalFileAmount = SQLiteHelper.ExecuteCountQuery($"SELECT COUNT(bfi_id) FROM backup_files_info WHERE bfi_userid='{UserHelper.GetUser().UserId}' AND bfi_type=0");
            int workedFileAmount = SQLiteHelper.ExecuteCountQuery($"SELECT COUNT(bfi_id) FROM backup_files_info WHERE bfi_userid='{UserHelper.GetUser().UserId}' AND bfi_state=1 AND bfi_type=0");
            int disWorkedFileAmount = SQLiteHelper.ExecuteCountQuery($"SELECT COUNT(bfi_id) FROM backup_files_info WHERE bfi_userid='{UserHelper.GetUser().UserId}' AND bfi_state=0 AND bfi_type=0");

            int gdFileAmount = SQLiteHelper.ExecuteCountQuery($"SELECT COUNT(bfi_id) FROM backup_files_info WHERE bfi_userid='{UserHelper.GetUser().UserId}' AND bfi_state_gd=1 AND bfi_type=0");
            int disGdFileAmount = SQLiteHelper.ExecuteCountQuery($"SELECT COUNT(bfi_id) FROM backup_files_info WHERE bfi_userid='{UserHelper.GetUser().UserId}' AND bfi_state_gd=0 AND bfi_type=0");
            string tipString = $"总文件数：{totalFileAmount}，已处理：{workedFileAmount}，未处理：{disWorkedFileAmount}，已归档：{gdFileAmount}，未归档：{disGdFileAmount}";
            stateTip.Text = "当前加工统计：" + tipString;
        }

        private void NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if(e.Node.Tag != null)
                {
                    dgv_DataList.Rows.Clear();
                    object objId = e.Node.Name;
                    ControlType type = (ControlType)e.Node.Tag;
                    if(type == ControlType.Plan)
                    {
                        int rowNumber = 1;
                        DataTable projectTable = SQLiteHelper.ExecuteQuery($"SELECT * FROM project_info WHERE pi_obj_id='{e.Node.Name}'");
                        for(int i = 0; i < projectTable.Rows.Count; i++)
                        {
                            int rid = dgv_DataList.Rows.Add();
                            dgv_DataList.Rows[rid].Tag = ControlType.Plan_Project;
                            dgv_DataList.Rows[rid].Cells["id"].Tag = projectTable.Rows[i]["pi_id"];
                            dgv_DataList.Rows[rid].Cells["id"].Value = rowNumber++;
                            dgv_DataList.Rows[rid].Cells["code"].Value = projectTable.Rows[i]["pi_code"];
                            dgv_DataList.Rows[rid].Cells["name"].Value = projectTable.Rows[i]["pi_name"];
                            dgv_DataList.Rows[rid].Cells["unit"].Value = projectTable.Rows[i]["pi_unit"];
                            dgv_DataList.Rows[rid].Cells["user"].Value = projectTable.Rows[i]["pi_unit_user"];
                            dgv_DataList.Rows[rid].Cells["phone"].Value = projectTable.Rows[i]["pi_contacts_phone"];
                            dgv_DataList.Rows[rid].Cells["files"].Value = GetFileAmount(projectTable.Rows[i]["pi_id"], true);
                            dgv_DataList.Rows[rid].Cells["eles"].Value = GetFileAmount(projectTable.Rows[i]["pi_id"], false);
                        }
                        DataTable topicTable = SQLiteHelper.ExecuteQuery($"SELECT * FROM topic_info WHERE ti_obj_id='{e.Node.Name}'");
                        for(int i = 0; i < topicTable.Rows.Count; i++)
                        {
                            int rid = dgv_DataList.Rows.Add();
                            dgv_DataList.Rows[rid].Tag = ControlType.Topic;
                            dgv_DataList.Rows[rid].Cells["id"].Tag = topicTable.Rows[i]["ti_id"];
                            dgv_DataList.Rows[rid].Cells["id"].Value = rowNumber++;
                            dgv_DataList.Rows[rid].Cells["code"].Value = topicTable.Rows[i]["ti_code"];
                            dgv_DataList.Rows[rid].Cells["name"].Value = topicTable.Rows[i]["ti_name"];
                            dgv_DataList.Rows[rid].Cells["unit"].Value = topicTable.Rows[i]["ti_unit"];
                            dgv_DataList.Rows[rid].Cells["user"].Value = topicTable.Rows[i]["ti_unit_user"];
                            dgv_DataList.Rows[rid].Cells["phone"].Value = topicTable.Rows[i]["ti_contacts_phone"];
                            dgv_DataList.Rows[rid].Cells["files"].Value = GetFileAmount(topicTable.Rows[i]["ti_id"], true);
                            dgv_DataList.Rows[rid].Cells["eles"].Value = GetFileAmount(topicTable.Rows[i]["ti_id"], false);
                        }
                    }
                    else if(type == ControlType.Plan_Project)
                    {
                        DataTable subjectTable = SQLiteHelper.ExecuteQuery($"SELECT * FROM subject_info WHERE si_obj_id='{e.Node.Name}'");
                        int rowNumber = 1;
                        for(int i = 0; i < subjectTable.Rows.Count; i++)
                        {
                            int rid = dgv_DataList.Rows.Add();
                            dgv_DataList.Rows[rid].Tag = ControlType.Plan_Topic_Subject;
                            dgv_DataList.Rows[rid].Cells["id"].Tag = subjectTable.Rows[i]["si_id"];
                            dgv_DataList.Rows[rid].Cells["id"].Value = rowNumber++;
                            dgv_DataList.Rows[rid].Cells["code"].Value = subjectTable.Rows[i]["si_code"];
                            dgv_DataList.Rows[rid].Cells["name"].Value = subjectTable.Rows[i]["si_name"];
                            dgv_DataList.Rows[rid].Cells["unit"].Value = subjectTable.Rows[i]["si_unit"];
                            dgv_DataList.Rows[rid].Cells["user"].Value = subjectTable.Rows[i]["si_unit_user"];
                            dgv_DataList.Rows[rid].Cells["phone"].Value = subjectTable.Rows[i]["si_contacts_phone"];
                            dgv_DataList.Rows[rid].Cells["files"].Value = GetFileAmount(subjectTable.Rows[i]["si_id"], true);
                            dgv_DataList.Rows[rid].Cells["eles"].Value = GetFileAmount(subjectTable.Rows[i]["si_id"], false);
                        }
                        DataTable topicTable = SQLiteHelper.ExecuteQuery($"SELECT * FROM topic_info WHERE ti_obj_id='{e.Node.Name}'");
                        for(int i = 0; i < topicTable.Rows.Count; i++)
                        {
                            int rid = dgv_DataList.Rows.Add();
                            dgv_DataList.Rows[rid].Tag = ControlType.Plan_Topic;
                            dgv_DataList.Rows[rid].Cells["id"].Tag = topicTable.Rows[i]["ti_id"];
                            dgv_DataList.Rows[rid].Cells["id"].Value = rowNumber++;
                            dgv_DataList.Rows[rid].Cells["code"].Value = topicTable.Rows[i]["ti_code"];
                            dgv_DataList.Rows[rid].Cells["name"].Value = topicTable.Rows[i]["ti_name"];
                            dgv_DataList.Rows[rid].Cells["unit"].Value = topicTable.Rows[i]["ti_unit"];
                            dgv_DataList.Rows[rid].Cells["user"].Value = topicTable.Rows[i]["ti_unit_user"];
                            dgv_DataList.Rows[rid].Cells["phone"].Value = topicTable.Rows[i]["ti_contacts_phone"];
                            dgv_DataList.Rows[rid].Cells["files"].Value = GetFileAmount(topicTable.Rows[i]["ti_id"], true);
                            dgv_DataList.Rows[rid].Cells["eles"].Value = GetFileAmount(topicTable.Rows[i]["ti_id"], false);
                        }
                    }
                    else if(type == ControlType.Plan_Topic || type == ControlType.Topic)
                    {
                        DataTable subjectTable = SQLiteHelper.ExecuteQuery($"SELECT * FROM subject_info WHERE si_obj_id='{e.Node.Name}'");
                        for(int i = 0; i < subjectTable.Rows.Count; i++)
                        {
                            int rid = dgv_DataList.Rows.Add();
                            dgv_DataList.Rows[rid].Tag = ControlType.Plan_Topic_Subject;
                            dgv_DataList.Rows[rid].Cells["id"].Tag = subjectTable.Rows[i]["si_id"];
                            dgv_DataList.Rows[rid].Cells["id"].Value = i + 1;
                            dgv_DataList.Rows[rid].Cells["code"].Value = subjectTable.Rows[i]["si_code"];
                            dgv_DataList.Rows[rid].Cells["name"].Value = subjectTable.Rows[i]["si_name"];
                            dgv_DataList.Rows[rid].Cells["unit"].Value = subjectTable.Rows[i]["si_unit"];
                            dgv_DataList.Rows[rid].Cells["user"].Value = subjectTable.Rows[i]["si_unit_user"];
                            dgv_DataList.Rows[rid].Cells["phone"].Value = subjectTable.Rows[i]["si_contacts_phone"];
                            dgv_DataList.Rows[rid].Cells["files"].Value = GetFileAmount(subjectTable.Rows[i]["si_id"], true);
                            dgv_DataList.Rows[rid].Cells["eles"].Value = GetFileAmount(subjectTable.Rows[i]["si_id"], false);
                        }
                    }
                }
            }
            else if(e.Button == MouseButtons.Right)
            {
                TreeNode node = tv_DataTree.GetNodeAt(e.X, e.Y);
                if(node != null)
                {
                    tv_DataTree.SelectedNode = node;
                    cms_TreeView.Show(MousePosition);

                    ControlType type = (ControlType)node.Tag;
                    if(type == ControlType.Plan)
                    {
                        项目toolStripMenuItem1.Visible = true;
                        课题TToolStripMenuItem.Visible = true;
                        子课题SToolStripMenuItem.Visible = false;
                        添加子节点AToolStripMenuItem.Visible = true;
                    }
                    else if(type == ControlType.Plan_Project)
                    {
                        项目toolStripMenuItem1.Visible = false;
                        课题TToolStripMenuItem.Visible = true;
                        子课题SToolStripMenuItem.Visible = true;
                        添加子节点AToolStripMenuItem.Visible = true;
                    }
                    else if(type == ControlType.Plan_Topic || type == ControlType.Topic)
                    {
                        项目toolStripMenuItem1.Visible = false;
                        课题TToolStripMenuItem.Visible = false;
                        子课题SToolStripMenuItem.Visible = true;
                        添加子节点AToolStripMenuItem.Visible = true;
                    }
                    else if(type == ControlType.Plan_Topic_Subject)
                    {
                        cms_TreeView.Close();
                    }
                }
            }
        }

        private void 刷新RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btn_Refresh_Click(null, null);
        }

        private void 课题TToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = tv_DataTree.SelectedNode;
            if(!node.Tag.Equals(ControlType.Plan))
            {
                Frm_Wroking frm = new Frm_Wroking(node, LoadTreeList);
                frm.cbo_Project_HasNext.SelectedIndex = 2;
                frm.Cbo_Project_HasNext_SelectionChangeCommitted(sender, e);
                frm.tab_Menu.SelectedIndex = frm.tab_Menu.TabCount - 1;
                frm.Show();
            }
            else
            {
                TreeNode _node = new TreeNode() { Name = UserHelper.GetUser().SpecialId, Tag = ControlType.Topic };
                Frm_Wroking frm_Wroking = new Frm_Wroking(_node, LoadTreeList);
                frm_Wroking.Show();
            }
        }

        private void 子课题SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = tv_DataTree.SelectedNode;
            if(!node.Tag.Equals(ControlType.Plan))
            {
                if(node.Tag.Equals(ControlType.Plan_Project))
                {
                    Frm_Wroking frm = new Frm_Wroking(node, LoadTreeList);
                    frm.cbo_Project_HasNext.SelectedIndex = 3;
                    frm.Cbo_Project_HasNext_SelectionChangeCommitted(sender, e);
                    frm.tab_Menu.SelectedIndex = frm.tab_Menu.TabCount - 1;
                    frm.Show();
                }
                else if(node.Tag.Equals(ControlType.Plan_Topic) || node.Tag.Equals(ControlType.Topic))
                {
                    Frm_Wroking frm = new Frm_Wroking(node, LoadTreeList);
                    frm.cbo_Topic_HasNext.SelectedIndex = 1;
                    frm.Cbo_Topic_HasNext_SelectionChangeCommitted(sender, e);
                    frm.tab_Menu.SelectedIndex = frm.tab_Menu.TabCount - 1;
                    frm.Show();
                }
            }
        }

        private void 删除节点DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = tv_DataTree.SelectedNode;
            if(node != null)
            {
                if(MessageBox.Show("确认要删除当前选中数据吗?", "确认提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    SQLiteHelper.ExecuteNonQuery($"DELETE FROM project_info WHERE pi_id='{node.Name}';" +
                        $"DELETE FROM topic_info WHERE ti_id='{node.Name}';" +
                        $"DELETE FROM subject_info WHERE si_id='{node.Name}';");

                    MessageBox.Show("删除成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    btn_Refresh_Click(sender, e);
                }
            }
        }

        private void 项目toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Pic_Add_Click(null, null);
        }

        private void dgv_DataList_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            new Frm_Wroking(new TreeNode()
            {
                Name = GetValue(dgv_DataList.Rows[e.RowIndex].Cells["id"].Tag),
                Tag = dgv_DataList.Rows[e.RowIndex].Tag
            }, LoadTreeList).Show();
        }

        private void pic_Help_Click(object sender, EventArgs e)
        {
            new Frm_Explain().ShowDialog();
        }

        private void txt_Query_Code_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Btn_Query_Click(null, null);
            }
        }
    }
}
