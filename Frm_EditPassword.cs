using System;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_EditPassword : Form
    {
        public Frm_EditPassword()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            string yPW = txt_PassWord.Text;
            if(UserHelper.GetUser().PassWord.Equals(yPW))
            {
                string nPW = txt_NewPassWord.Text;
                string nPWA = txt_NewPassWordAgain.Text;
                if(nPW.Equals(nPWA) && MessageBox.Show("确定要修改密码吗?", "确认提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    SQLiteHelper.ExecuteNonQuery($"UPDATE user_info SET ui_password='{nPW}' WHERE ui_id='{UserHelper.GetUser().UserId}'");
                    UserHelper.GetUser().PassWord = nPW;
                    MessageBox.Show("修改成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Close();
                }
                else
                    MessageBox.Show("两次输入密码不一致。", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("原密码不正确。", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Frm_EditPassword_Load(object sender, EventArgs e)
        {
            lbl_UserName.Text = UserHelper.GetUser().UserName;
        }
    }
}
