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
            LoadLevelOneList();
        }

        private void LoadLevelOneList()
        {
            dgv_ShowData.Rows.Clear();
            dgv_ShowData.Columns.Clear();

            dgv_ShowData.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewColumn(){Name = "id", HeaderText = "序号", FillWeight = 10 },
                new DataGridViewColumn(){Name = "code", HeaderText = "编号", FillWeight = 10 },
                new DataGridViewColumn(){Name = "name", HeaderText = "名称", FillWeight = 10 },
                new DataGridViewColumn(){Name = "unit", HeaderText = "承担单位", FillWeight = 10 },
                new DataGridViewColumn(){Name = "user", HeaderText = "负责人", FillWeight = 10 },
                new DataGridViewColumn(){Name = "phone", HeaderText = "手机", FillWeight = 10 },
                new DataGridViewColumn(){Name = "totalFiles", HeaderText = "总文件数", FillWeight = 10 },
                new DataGridViewColumn(){Name = "level2", HeaderText = "课题/子课题数", FillWeight = 10 },
            });

            DataTable projectTable = SQLiteHelper.ExecuteQuery($"SELECT * FROM project_info WHERE pi_obj_id='{rootId}'");
            for(int i = 0; i < projectTable.Rows.Count; i++)
            {

            }

        }
    }
}
