using System;
using System.Data;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_UnitManage : Form
    {
        public Frm_UnitManage(object id)
        {
            InitializeComponent();
            txt_Name.Tag = id;
        }

        private void btn_Save_Click(object sender, System.EventArgs e)
        {
            object id = txt_Name.Tag;
            object name = txt_Name.Text;
            object code = txt_Code.Text;
            object intro = txt_Intro.Text;
            if(id == null)
            {
                id = Guid.NewGuid().ToString();
                string insertSql = "INSERT INTO special_info(spi_id, spi_code, spi_name, spi_intro) " +
                    $"VALUES ('{id}','{code}','{name}','{intro}')";
                SQLiteHelper.ExecuteNonQuery(insertSql);
                MessageBox.Show("添加成功！");
            }
            else
            {
                string updateSql = $"UPDATE special_info SET spi_code='{code}', spi_name='{name}', spi_intro='{intro}' WHERE spi_id='{id}'";
                SQLiteHelper.ExecuteNonQuery(updateSql);
                MessageBox.Show("更新成功！");
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if("name".Equals(dgv_DataList.Columns[e.ColumnIndex].Name))
                {
                    txt_Name.Tag = dgv_DataList.Rows[e.RowIndex].Cells["id"].Tag;
                    txt_Name.Text = GetValue(dgv_DataList.Rows[e.RowIndex].Cells["name"].Value);
                    txt_Code.Text = GetValue(dgv_DataList.Rows[e.RowIndex].Cells["code"].Value);
                    txt_Intro.Text = GetValue(dgv_DataList.Rows[e.RowIndex].Cells["intro"].Value);
                    tab_Menu.SelectedIndex = 1;
                }
            }
        }

        private string GetValue(object value)
        {
            return value == null ? string.Empty : value.ToString();
        }

        private void Frm_UnitManage_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            dgv_DataList.Rows.Clear();
            DataTable table = SQLiteHelper.ExecuteQuery($"SELECT * FROM special_info");
            for(int i = 0; i < table.Rows.Count; i++)
            {
                int index = dgv_DataList.Rows.Add();
                dgv_DataList.Rows[index].Cells["id"].Tag = table.Rows[i]["spi_id"]; 
                dgv_DataList.Rows[index].Cells["id"].Value = i + 1;
                dgv_DataList.Rows[index].Cells["name"].Value = table.Rows[i]["spi_name"];
                dgv_DataList.Rows[index].Cells["code"].Value = table.Rows[i]["spi_code"];
                dgv_DataList.Rows[index].Cells["intro"].Value = table.Rows[i]["spi_intro"];
            }
        }

        private void tab_Menu_TabIndexChanged(object sender, EventArgs e)
        {
            if(tab_Menu.SelectedIndex == 0)
                Frm_UnitManage_Load(sender, e);
        }
    }
}
