using System;
using System.Data;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_Query : Form
    {
        private object rootId;
        public Frm_Query(object rootId)
        {
            InitializeComponent();
            this.rootId = rootId;
        }

        private void Frm_Query_Load(object sender, System.EventArgs e)
        {
            LoadProjectList(rootId);
            lbl_Back.Enabled = false;
        }

        /// <summary>
        /// 项目列表
        /// </summary>
        /// <param name="spid">专项ID</param>
        private void LoadProjectList(object spid)
        {
            dgv_ShowData.Rows.Clear();
            dgv_ShowData.Columns.Clear();

            dgv_ShowData.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn(){Name = "pro_id", HeaderText = "序号", FillWeight = 3 },
                new DataGridViewTextBoxColumn(){Name = "pro_code", HeaderText = "编号", FillWeight = 8 },
                new DataGridViewTextBoxColumn(){Name = "pro_name", HeaderText = "名称", FillWeight = 10 },
                new DataGridViewTextBoxColumn(){Name = "pro_unit", HeaderText = "承担单位", FillWeight = 8 },
                new DataGridViewTextBoxColumn(){Name = "pro_user", HeaderText = "负责人", FillWeight = 5 },
                new DataGridViewTextBoxColumn(){Name = "pro_phone", HeaderText = "手机", FillWeight = 5 },
                new DataGridViewLinkColumn(){Name = "pro_totalFileAmount", HeaderText = "总文件数", FillWeight = 3 },
                new DataGridViewLinkColumn(){Name = "pro_topicAmount", HeaderText = "课题/子课题数", FillWeight = 4 },
            });

            DataTable projectTable = SQLiteHelper.ExecuteQuery($"SELECT * FROM project_info WHERE pi_obj_id='{spid}'");
            for(int i = 0; i < projectTable.Rows.Count; i++)
            {
                int index = dgv_ShowData.Rows.Add();
                dgv_ShowData.Rows[index].Tag = projectTable.Rows[i]["pi_id"];
                dgv_ShowData.Rows[index].Cells["pro_id"].Value = i + 1;
                dgv_ShowData.Rows[index].Cells["pro_code"].Value = projectTable.Rows[i]["pi_code"];
                dgv_ShowData.Rows[index].Cells["pro_name"].Value = projectTable.Rows[i]["pi_name"];
                dgv_ShowData.Rows[index].Cells["pro_unit"].Value = projectTable.Rows[i]["pi_unit"];
                dgv_ShowData.Rows[index].Cells["pro_user"].Value = projectTable.Rows[i]["pi_contacts"];
                dgv_ShowData.Rows[index].Cells["pro_phone"].Value = projectTable.Rows[i]["pi_contacts_phone"];
                dgv_ShowData.Rows[index].Cells["pro_totalFileAmount"].Value = GetFileAmount(projectTable.Rows[i]["pi_id"]);
                dgv_ShowData.Rows[index].Cells["pro_topicAmount"].Value = GetTopicAmount(projectTable.Rows[i]["pi_id"]);
            }

            dgv_ShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv_ShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewStyleHelper.SetAlignWithCenter(dgv_ShowData, new string[] { "pro_id", "pro_totalFileAmount", "pro_topicAmount" });
        }

        /// <summary>
        /// 获取指定课题下的子课题数
        /// </summary>
        /// <param name="pid">指定ID</param>
        private int GetTopicAmount(object pid) => SQLiteHelper.ExecuteCountQuery($"SELECT COUNT(ti_id) FROM topic_info WHERE ti_obj_id='{pid}'");

        /// <summary>
        /// 获取指定课题下的文件数
        /// </summary>
        /// <param name="pid">指定ID</param>
        private int GetFileAmount(object pid) => SQLiteHelper.ExecuteCountQuery($"SELECT COUNT(fi_id) FROM files_info WHERE fi_obj_id='{pid}'");

        /// <summary>
        /// 单元格点击事件
        /// </summary>
        private void dgv_ShowData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex!=-1 && e.ColumnIndex != -1)
            {
                object id = dgv_ShowData.Rows[e.RowIndex].Tag;
                string columnName = dgv_ShowData.Columns[e.ColumnIndex].Name;
                if("pro_totalFileAmount".Equals(columnName))
                {
                    LoadFileList(id);
                    dgv_ShowData.Tag = id;
                    lbl_Back.Enabled = true;
                    lbl_Back.Tag = "project";
                }
                else if("pro_topicAmount".Equals(columnName))
                {
                    LoadTopicList(id);
                    dgv_ShowData.Tag = id;
                    lbl_Back.Enabled = true;
                    lbl_Back.Tag = "project";
                }
                else if("top_totalFileAmount".Equals(columnName))
                {
                    LoadFileList(id);
                    dgv_ShowData.Tag = id;
                    lbl_Back.Enabled = true;
                    lbl_Back.Tag = "topic";
                }
                else if("top_subjectAmount".Equals(columnName))
                {
                    LoadSubjectList(id);
                    dgv_ShowData.Tag = id;
                    lbl_Back.Enabled = true;
                    lbl_Back.Tag = "topic";
                }
                else if("sub_totalFileAmount".Equals(columnName))
                {
                    LoadFileList(id);
                    dgv_ShowData.Tag = id;
                    lbl_Back.Enabled = true;
                    lbl_Back.Tag = "subject";
                }
            }
        }

        /// <summary>
        /// 子课题列表
        /// </summary>
        /// <param name="id">课题ID</param>
        private void LoadSubjectList(object tid)
        {
            dgv_ShowData.Rows.Clear();
            dgv_ShowData.Columns.Clear();

            dgv_ShowData.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn(){Name = "sub_id", HeaderText = "序号", FillWeight = 3 },
                new DataGridViewTextBoxColumn(){Name = "sub_code", HeaderText = "编号", FillWeight = 8 },
                new DataGridViewTextBoxColumn(){Name = "sub_name", HeaderText = "名称", FillWeight = 10 },
                new DataGridViewTextBoxColumn(){Name = "sub_unit", HeaderText = "承担单位", FillWeight = 8 },
                new DataGridViewTextBoxColumn(){Name = "sub_user", HeaderText = "负责人", FillWeight = 5 },
                new DataGridViewTextBoxColumn(){Name = "sub_phone", HeaderText = "手机", FillWeight = 5 },
                new DataGridViewLinkColumn(){Name = "sub_totalFileAmount", HeaderText = "总文件数", FillWeight = 3 }
            });

            DataTable topicTable = SQLiteHelper.ExecuteQuery($"SELECT * FROM subject_info WHERE si_obj_id='{tid}'");
            for(int i = 0; i < topicTable.Rows.Count; i++)
            {
                int index = dgv_ShowData.Rows.Add();
                dgv_ShowData.Rows[index].Tag = topicTable.Rows[i]["si_id"];
                dgv_ShowData.Rows[index].Cells["sub_id"].Value = i + 1;
                dgv_ShowData.Rows[index].Cells["sub_code"].Value = topicTable.Rows[i]["si_code"];
                dgv_ShowData.Rows[index].Cells["sub_name"].Value = topicTable.Rows[i]["si_name"];
                dgv_ShowData.Rows[index].Cells["sub_unit"].Value = topicTable.Rows[i]["si_unit"];
                dgv_ShowData.Rows[index].Cells["sub_user"].Value = topicTable.Rows[i]["si_contacts"];
                dgv_ShowData.Rows[index].Cells["sub_phone"].Value = topicTable.Rows[i]["si_contacts_phone"];
                dgv_ShowData.Rows[index].Cells["sub_totalFileAmount"].Value = GetFileAmount(topicTable.Rows[i]["si_id"]);
            }
            dgv_ShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv_ShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewStyleHelper.SetAlignWithCenter(dgv_ShowData, new string[] { "sub_id", "sub_totalFileAmount" });
        }

        /// <summary>
        /// 课题列表
        /// </summary>
        /// <param name="pid">项目ID</param>
        private void LoadTopicList(object pid)
        {
            dgv_ShowData.Rows.Clear();
            dgv_ShowData.Columns.Clear();

            dgv_ShowData.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn(){Name = "top_id", HeaderText = "序号", FillWeight = 3 },
                new DataGridViewTextBoxColumn(){Name = "top_code", HeaderText = "编号", FillWeight = 8 },
                new DataGridViewTextBoxColumn(){Name = "top_name", HeaderText = "名称", FillWeight = 10 },
                new DataGridViewTextBoxColumn(){Name = "top_unit", HeaderText = "承担单位", FillWeight = 8 },
                new DataGridViewTextBoxColumn(){Name = "top_user", HeaderText = "负责人", FillWeight = 5 },
                new DataGridViewTextBoxColumn(){Name = "top_phone", HeaderText = "手机", FillWeight = 5 },
                new DataGridViewLinkColumn(){Name = "top_totalFileAmount", HeaderText = "总文件数", FillWeight = 3 },
                new DataGridViewLinkColumn(){Name = "top_subjectAmount", HeaderText = "子课题数", FillWeight = 4 },
            });

            DataTable topicTable = SQLiteHelper.ExecuteQuery($"SELECT * FROM topic_info WHERE ti_obj_id='{pid}'");
            for(int i = 0; i < topicTable.Rows.Count; i++)
            {
                int index = dgv_ShowData.Rows.Add();
                dgv_ShowData.Rows[index].Tag = topicTable.Rows[i]["ti_id"];
                dgv_ShowData.Rows[index].Cells["top_id"].Value = i + 1;
                dgv_ShowData.Rows[index].Cells["top_code"].Value = topicTable.Rows[i]["ti_code"];
                dgv_ShowData.Rows[index].Cells["top_name"].Value = topicTable.Rows[i]["ti_name"];
                dgv_ShowData.Rows[index].Cells["top_unit"].Value = topicTable.Rows[i]["ti_unit"];
                dgv_ShowData.Rows[index].Cells["top_user"].Value = topicTable.Rows[i]["ti_contacts"];
                dgv_ShowData.Rows[index].Cells["top_phone"].Value = topicTable.Rows[i]["ti_contacts_phone"];
                dgv_ShowData.Rows[index].Cells["top_totalFileAmount"].Value = GetFileAmount(topicTable.Rows[i]["ti_id"]);
                dgv_ShowData.Rows[index].Cells["top_subjectAmount"].Value = GetSubjectAmount(topicTable.Rows[i]["ti_id"]);
            }
            dgv_ShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv_ShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewStyleHelper.SetAlignWithCenter(dgv_ShowData, new string[] { "top_id", "top_totalFileAmount", "top_subjectAmount" });
        }

        /// <summary>
        /// 根据ID获取子课题数
        /// </summary>
        /// <param name="tid">课题ID</param>
        private int GetSubjectAmount(object tid) => SQLiteHelper.ExecuteCountQuery($"SELECT COUNT(si_id) FROM subject_info WHERE si_obj_id='{tid}'");

        /// <summary>
        /// 文件列表
        /// </summary>
        /// <param name="id">所属ID</param>
        private void LoadFileList(object id)
        {
            dgv_ShowData.Rows.Clear();
            dgv_ShowData.Columns.Clear();

            dgv_ShowData.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn(){ Name = "id", HeaderText = "序号", FillWeight = 3 },
                new DataGridViewTextBoxColumn(){ Name = "stage", HeaderText = "阶段", FillWeight = 5 },
                new DataGridViewTextBoxColumn(){ Name = "categor", HeaderText = "类别", FillWeight = 5 },
                new DataGridViewTextBoxColumn(){ Name = "name", HeaderText = "名称", FillWeight = 10 },
                new DataGridViewTextBoxColumn(){ Name = "user", HeaderText = "责任者", FillWeight = 5 },
                new DataGridViewTextBoxColumn(){ Name = "type", HeaderText = "类型", FillWeight = 5 },
                new DataGridViewTextBoxColumn(){ Name = "secret", HeaderText = "密级", FillWeight = 5 },
                new DataGridViewTextBoxColumn(){ Name = "pages", HeaderText = "页数", FillWeight = 3 },
                new DataGridViewTextBoxColumn(){ Name = "number", HeaderText = "份数", FillWeight = 3 },
                new DataGridViewTextBoxColumn(){ Name = "date", HeaderText = "形成日期", FillWeight = 5 },
                new DataGridViewTextBoxColumn(){ Name = "unit", HeaderText = "存放单位", FillWeight = 7}
            });
            DataTable table = SQLiteHelper.ExecuteQuery($"SELECT * FROM files_info WHERE fi_obj_id='{id}'");
            for(int i = 0; i < table.Rows.Count; i++)
            {
                int index = dgv_ShowData.Rows.Add();
                dgv_ShowData.Rows[index].Tag = table.Rows[i]["fi_id"];
                dgv_ShowData.Rows[index].Cells["id"].Value = i + 1;
                dgv_ShowData.Rows[index].Cells["stage"].Value = table.Rows[i]["fi_stage"];
                dgv_ShowData.Rows[index].Cells["categor"].Value = table.Rows[i]["fi_categor"];
                dgv_ShowData.Rows[index].Cells["name"].Value = table.Rows[i]["fi_name"];
                dgv_ShowData.Rows[index].Cells["user"].Value = table.Rows[i]["fi_user"];
                dgv_ShowData.Rows[index].Cells["type"].Value = table.Rows[i]["fi_type"];
                dgv_ShowData.Rows[index].Cells["secret"].Value = table.Rows[i]["fi_secret"];
                dgv_ShowData.Rows[index].Cells["pages"].Value = table.Rows[i]["fi_pages"];
                dgv_ShowData.Rows[index].Cells["number"].Value = table.Rows[i]["fi_number"];
                dgv_ShowData.Rows[index].Cells["date"].Value = table.Rows[i]["fi_create_date"];
                dgv_ShowData.Rows[index].Cells["unit"].Value = table.Rows[i]["fi_unit"];
            }

            dgv_ShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dgv_ShowData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridViewStyleHelper.SetAlignWithCenter(dgv_ShowData, new string[] { "pages", "number" });
        }

        private void lbl_Back_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel label = sender as LinkLabel;
            if("project".Equals(label.Tag))
            {
                LoadProjectList(rootId);
                lbl_Back.Enabled = false;
            }
            else if("topic".Equals(label.Tag))
            {
                object id = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT ti_obj_id FROM topic_info WHERE ti_id='{dgv_ShowData.Tag}'");
                LoadTopicList(id);
                lbl_Back.Tag = "project";
            }
            else if("subject".Equals(label.Tag))
            {
                object id = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT si_obj_id FROM subject_info WHERE si_id='{dgv_ShowData.Tag}'");
                LoadSubjectList(id);
                dgv_ShowData.Tag = id;
                lbl_Back.Tag = "topic";
            }
        }

        private void lbl_FirstPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadProjectList(rootId);
        }
    }
}
