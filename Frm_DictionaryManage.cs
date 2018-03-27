using System;
using System.Data;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_DictionaryManage : Form
    {
        private object key;
        private object lastKey;
        public Frm_DictionaryManage(object key)
        {
            InitializeComponent();
            this.key = key;
            lastKey = key;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Frm_Dictionary_Add frm = new Frm_Dictionary_Add(key, null);
            if(frm.ShowDialog() == DialogResult.OK)
            {
                LoadDataListInstince(key);
            }
        }

        private void LoadDataList(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            cbo_SearchType.SelectedIndex = 0;
            LoadDataListInstince(key);
        }

        private void LoadDataListInstince(object key)
        {
            dgv_DataList.Rows.Clear();
            DataTable table = SQLiteHelper.ExecuteQuery($"SELECT * FROM data_dictionary WHERE dd_pId='{key}' ORDER BY dd_sort");
            for(int i = 0; i < table.Rows.Count; i++)
            {
                int index = dgv_DataList.Rows.Add();
                dgv_DataList.Rows[index].Cells["id"].Tag = table.Rows[i]["dd_id"];
                dgv_DataList.Rows[index].Cells["id"].Value = i + 1;
                dgv_DataList.Rows[index].Cells["name"].Value = table.Rows[i]["dd_name"];
                dgv_DataList.Rows[index].Cells["intro"].Value = table.Rows[i]["dd_note"];
                dgv_DataList.Rows[index].Cells["sort"].Value = table.Rows[i]["dd_sort"];
            }
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            if(dgv_DataList.SelectedRows.Count == 1)
            {
                object id = dgv_DataList.CurrentRow.Cells["id"].Tag;
                Frm_Dictionary_Add frm = new Frm_Dictionary_Add(key, id);
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    LoadDataListInstince(key);
                }
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if(dgv_DataList.SelectedRows.Count > 0)
            {
                if(MessageBox.Show("确定要删除当前选中行吗?", "确认提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    string ids = string.Empty;
                    foreach(DataGridViewRow item in dgv_DataList.SelectedRows)
                        ids += "'" + item.Cells["id"].Tag + "',";
                    ids = ids.Substring(0, ids.Length - 1);

                    SQLiteHelper.ExecuteNonQuery($"DELETE FROM data_dictionary WHERE dd_id IN({ids})");
                    MessageBox.Show("删除成功。");
                    LoadDataListInstince(key);
                }
            }
        }

        private void dgv_DataList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex!=-1 && e.ColumnIndex != -1)
            {
                if("name".Equals(dgv_DataList.CurrentCell.OwningColumn.Name))
                {
                    lastKey = key;
                    key = dgv_DataList.CurrentRow.Cells["id"].Tag;
                    LoadDataListInstince(key);
                }
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            key = lastKey;
            lastKey = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT dd_pId FROM data_dictionary WHERE dd_id='{key}'") ?? lastKey;
            LoadDataListInstince(key);
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            object _key = txt_SearchKey.Text;
            if(_key != null && !string.IsNullOrEmpty(_key.ToString()))
            {
                dgv_DataList.Rows.Clear();
                object type = cbo_SearchType.SelectedIndex == 0 ? "dd_name" : (cbo_SearchType.SelectedIndex == 1 ? "dd_note" : "dd_sort");
                DataTable table = SQLiteHelper.ExecuteQuery($"SELECT * FROM data_dictionary WHERE dd_pId='{key}' AND {type} LIKE '%{_key}%' ORDER BY dd_sort");
                for(int i = 0; i < table.Rows.Count; i++)
                {
                    int index = dgv_DataList.Rows.Add();
                    dgv_DataList.Rows[index].Cells["id"].Tag = table.Rows[i]["dd_id"];
                    dgv_DataList.Rows[index].Cells["id"].Value = i + 1;
                    dgv_DataList.Rows[index].Cells["name"].Value = table.Rows[i]["dd_name"];
                    dgv_DataList.Rows[index].Cells["intro"].Value = table.Rows[i]["dd_note"];
                    dgv_DataList.Rows[index].Cells["sort"].Value = table.Rows[i]["dd_sort"];
                }
            }
            else
                LoadDataListInstince(key);
        }
    }
}
