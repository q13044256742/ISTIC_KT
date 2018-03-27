using System;
using System.Data;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_UserManage : Form
    {
        public Frm_UserManage()
        {
            InitializeComponent();
        }

        private void Frm_UserManager_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            cbo_Search_Type.SelectedIndex = 0;
            LoadUserList(string.Empty);

            string key = "00f09cef-59be-4607-93bf-3b70b2db1e2b";
            DataTable table = SQLiteHelper.ExecuteQuery($"SELECT * FROM data_dictionary WHERE dd_pId='{key}' ORDER BY dd_sort");
            cbo_Unit.DataSource = table;
            cbo_Unit.DisplayMember = "dd_name";
            cbo_Unit.ValueMember = "dd_id";
        }

        private void LoadUserList(object queryCondition)
        {
            dgv_UserList.Rows.Clear();
            DataTable table = SQLiteHelper.ExecuteQuery($"SELECT * FROM user_info {queryCondition}");
            for(int i = 0; i < table.Rows.Count; i++)
            {
                int index = dgv_UserList.Rows.Add();
                dgv_UserList.Rows[index].Cells["id"].Tag = table.Rows[i]["ui_id"];
                dgv_UserList.Rows[index].Cells["id"].Value = i + 1;
                dgv_UserList.Rows[index].Cells["realname"].Value = table.Rows[i]["ui_realname"];
                dgv_UserList.Rows[index].Cells["username"].Value = table.Rows[i]["ui_username"];
                dgv_UserList.Rows[index].Cells["phone"].Value = table.Rows[i]["ui_phone"];
                dgv_UserList.Rows[index].Cells["unit"].Value = SQLiteHelper.GetValueByKey(table.Rows[i]["ui_unit"]);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            object id = Guid.NewGuid().ToString();
            object username = txt_UserName.Text;
            object password = txt_PassWord.Text;
            object passwordAgain = txt_PassWordAagin.Text;
            object unit = cbo_Unit.SelectedValue;
            object department = txt_Department.Text;
            object realname = txt_RealName.Text;
            object email = txt_Email.Text;
            object phone = txt_Phone.Text;
            object remark = txt_Remark.Text;
            string insertSql = "INSERT INTO user_info (ui_id, ui_username, ui_password, ui_unit, ui_department, ui_realname, ui_email, ui_phone, ui_remark) VALUES( " +
                $"'{id}', '{username}', '{password}', '{unit}', '{department}', '{realname}', '{email}', '{phone}', '{remark}')";

            SQLiteHelper.ExecuteNonQuery(insertSql);
            MessageBox.Show("保存成功。", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            foreach(Control item in tab_UserAdd.Controls)
                if(item is TextBox)
                    (item as TextBox).Clear();
        }

        private void txt_PassWordAagin_Leave(object sender, EventArgs e)
        {
            string psd = txt_PassWord.Text;
            if(!string.IsNullOrEmpty(psd))
            {
                string psda = txt_PassWordAagin.Text;
                if(!psd.Equals(psda))
                    errorTip.SetError(txt_PassWordAagin, "两次输入密码不一致！");
                else
                    errorTip.SetError(txt_PassWordAagin, null);
            }
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            LoadUserList(string.Empty);
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string key = txt_Search_KeyWord.Text;
            if(string.IsNullOrEmpty(key))
                LoadUserList(string.Empty);
            else
            {
                //真实姓名 登录名 联系方式 所属单位
                string cdn = string.Empty;
                int type = cbo_Search_Type.SelectedIndex;
                if(type == 0)
                    cdn = $"WHERE ui_realname LIKE '%{key}%'";
                else if(type == 1)
                    cdn = $"WHERE ui_username LIKE '%{key}%'";
                else if(type == 2)
                    cdn = $"WHERE ui_phone LIKE '%{key}%'";
                else if(type == 3)
                    cdn = $"WHERE ui_unit LIKE '%{key}%'";
                LoadUserList(cdn);
            }
        }
    }
}
