﻿using System;
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
            string key = "AD534039-A38F-412E-974E-B18BD9B8A2C0";
            DataTable table = SQLiteHelper.ExecuteQuery($"SELECT * FROM data_dictionary WHERE dd_pId='{key}' ORDER BY dd_sort");
            cbo_Special.DataSource = table;
            cbo_Special.DisplayMember = "dd_name";
            cbo_Special.ValueMember = "dd_id";
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
            object id = txt_UserName.Tag;
            object username = txt_UserName.Text;
            object password = txt_PassWord.Text;
            object passwordAgain = txt_PassWordAagin.Text;
            object special = cbo_Special.SelectedValue;
            object department = txt_Department.Text;
            object realname = txt_RealName.Text;
            object email = txt_Email.Text;
            object phone = txt_Phone.Text;
            object remark = txt_Remark.Text;
            if(id == null)
            {
                id = Guid.NewGuid().ToString();
                string insertSql = "INSERT INTO user_info (ui_id, ui_username, ui_password, ui_special_id, ui_department, ui_realname, ui_email, ui_phone, ui_remark) VALUES( " +
                    $"'{id}', '{username}', '{password}', '{special}', '{department}', '{realname}', '{email}', '{phone}', '{remark}')";

                SQLiteHelper.ExecuteNonQuery(insertSql);
                MessageBox.Show("保存成功。", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                txt_UserName.Tag = id;
            }
            else
            {
                string updateSql = "UPDATE user_info SET " +
                    $"ui_username = '{username}', " +
                    $"ui_password = '{password}', " +
                    $"ui_special_id = '{special}', " +
                    $"ui_department = '{department}', " +
                    $"ui_realname = '{realname}', " +
                    $"ui_email = '{email}', " +
                    $"ui_phone = '{phone}', " +
                    $"ui_remark = '{remark}' " +
                    $"WHERE ui_id = '{id}'";
                SQLiteHelper.ExecuteNonQuery(updateSql);
                MessageBox.Show("更新成功。", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            foreach(Control item in tab_UserAdd.Controls)
            {
                item.Tag = null;
                if(item is TextBox)
                {
                    (item as TextBox).Clear();
                }
            }
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

        private void dgv_UserList_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            object id = dgv_UserList.Rows[e.RowIndex].Cells[0].Tag;
            if(id != null)
            {
                LoadUserInfoById(id);
                tab_UseList.SelectedIndex = tab_UseList.TabCount - 1;
            }
        }

        private void LoadUserInfoById(object _id)
        {
            DataRow row = SQLiteHelper.ExecuteSingleRowQuery($"SELECT * FROM user_info WHERE ui_id='{_id}'");
            if(row != null)
            {
                txt_UserName.Tag = row["ui_id"];
                txt_UserName.Text = GetValue(row["ui_username"]);
                txt_PassWord.Text = GetValue(row["ui_password"]);
                txt_PassWordAagin.Text = txt_PassWord.Text;
                cbo_Special.SelectedValue = row["ui_special_id"];
                txt_Department.Text = GetValue(row["ui_department"]);
                txt_RealName.Text = GetValue(row["ui_realname"]);
                txt_Email.Text = GetValue(row["ui_email"]);
                txt_Phone.Text = GetValue(row["ui_phone"]);
                txt_Remark.Text = GetValue(row["ui_remark"]);
            }
        }

        private string GetValue(object _obj) => _obj == null ? string.Empty : _obj.ToString();
    }
}
