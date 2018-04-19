using System;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_Dictionary_Add : Form
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key">父ID</param>
        /// <param name="id">当前ID</param>
        public Frm_Dictionary_Add(object key, object id)
        {
            InitializeComponent();
            LoadParentInfo(key, id);
        }

        private void LoadParentInfo(object key, object id)
        {
            txt_Pname.Tag = key;
            txt_Pname.Text = GetValue(SQLiteHelper.ExecuteOnlyOneQuery($"SELECT dd_name FROM data_dictionary WHERE dd_id='{key}'"));
            txt_Sort.Value = SQLiteHelper.ExecuteCountQuery($"SELECT COUNT(*) FROM data_dictionary WHERE dd_pId='{key}'");
            if(id != null)
            {
                object[] obj = SQLiteHelper.ExecuteRowsQuery($"SELECT dd_name, dd_note, dd_sort FROM data_dictionary WHERE dd_id='{id}'");
                txt_name.Tag = id;
                txt_name.Text = GetValue(obj[0]);
                txt_Intro.Text = GetValue(obj[1]);
                txt_Sort.Value = GetIntValue(obj[2]);
            }
        }

        private int GetIntValue(object v)
        {
            int index = 0;
            if(v != null)
                int.TryParse(v.ToString(), out index);
            return index;
        }

        private string GetValue(object v)
        {
            return v == null ? string.Empty : v.ToString();
        }

        private void btn_Save_Click(object sender, System.EventArgs e)
        {
            object name = txt_name.Text;
            object sort = txt_Sort.Value;
            object intro = txt_Intro.Text;
            object id = txt_name.Tag;
            if(id == null)
            {
                object pid = txt_Pname.Tag;
                id = Guid.NewGuid().ToString();
                SQLiteHelper.ExecuteNonQuery($"INSERT INTO data_dictionary(dd_id, dd_name, dd_sort, dd_note, dd_pId) VALUES('{id}', '{name}', '{sort}', '{intro}', '{pid}')");
                MessageBox.Show("新增成功。");
                txt_Sort.Value += 1;
                txt_name.Clear();
                txt_Intro.Clear();
            }
            else
            {
                SQLiteHelper.ExecuteNonQuery($"UPDATE data_dictionary SET dd_name='{name}', dd_sort='{sort}', dd_note='{intro}' WHERE dd_id='{id}'");
                MessageBox.Show("更新成功。");
            }
            btn_Cancel_Click(sender, e);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Frm_Dictionary_Add_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
