using System;
using System.Data;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_IdentityChoose : Form
    {
        public Frm_IdentityChoose()
        {
            InitializeComponent();
        }

        private void Frm_IdentityChoose_Load(object sender, EventArgs e)
        {
            string key = "AD534039-A38F-412E-974E-B18BD9B8A2C0";
            DataTable table = SQLiteHelper.ExecuteQuery($"SELECT dd_id, dd_name FROM data_dictionary WHERE dd_pId='{key}' ORDER BY dd_sort ASC");
            cbo_ChooseIdentity.DataSource = table;
            cbo_ChooseIdentity.DisplayMember = "dd_name";
            cbo_ChooseIdentity.ValueMember = "dd_id";
        }

        private void btn_Sure_Click(object sender, EventArgs e)
        {
            object id = cbo_ChooseIdentity.SelectedValue;
            string name = cbo_ChooseIdentity.Text;
            string depName = txt_Unit.Text;
            if(string.IsNullOrEmpty(depName))
            {
                new ErrorProvider().SetError(txt_Unit, "提示：单位名称不能为空。");
            }
            else if(MessageBox.Show($"选择后不可修改，确定是属于{name}吗？", "确认提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                SQLiteHelper.ExecuteNonQuery($"UPDATE user_info SET ui_department='{depName}', ui_special_id='{id}' WHERE ui_id='{UserHelper.GetUser().UserId}'");

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Frm_IdentityChoose_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(DialogResult != DialogResult.OK)
            {
                if(MessageBox.Show("尚未选择身份，是否退出？", "无法进入", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Application.Exit();
                else
                    e.Cancel = true;
            }
        }
    }
}
