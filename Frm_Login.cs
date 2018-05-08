using System;
using System.Data;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = txt_Username.Text;
            string password = txt_Password.Text;
            if(!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                object uid = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT ui_id FROM user_info WHERE ui_username='{username}' AND ui_password='{password}'");
                if(!string.IsNullOrEmpty(GetValue(uid)))
                {
                    DataRow row = SQLiteHelper.ExecuteSingleRowQuery($"SELECT * FROM user_info WHERE ui_id='{uid}'");
                    User user = UserHelper.GetUser();
                    user.UserId = uid;
                    user.UserName = username;
                    user.RealName = GetValue(row["ui_realname"]);
                    user.UserSpecialId = GetValue(row["ui_special_id"]);
                    user.UserUnitId = GetValue(row["ui_unit"]);
                    user.UserUnitName = GetValue(row["ui_department"]);
                    user.PassWord = password;
                    DataRow spRow = SQLiteHelper.ExecuteSingleRowQuery($"SELECT spi_name FROM special_info WHERE spi_id='{user.UserSpecialId}'");
                    if(spRow != null)
                        user.SpecialName = GetValue(spRow["spi_name"]);
                    Frm_MainFrame frm = new Frm_MainFrame();
                    frm.Show();
                    Hide();
                }
                else
                    MessageBox.Show("用户名或密码错误。", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private string GetValue(object uid)
        {
            return uid == null ? string.Empty : uid.ToString();
        }

        private void Frm_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
