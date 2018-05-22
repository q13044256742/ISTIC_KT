using System;
using System.Text;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_FileBackUpTable : Form
    {
        public Frm_FileBackUpTable()
        {
            InitializeComponent();
        }
        public int fileAmount;
        public int filePages;
        public object docNumber;
        public object user;
        private void Frm_FileBackUpTable_Load(object sender, System.EventArgs e)
        {
            pal_Table.Height = 1150;

            lbl_Amount.Text = GetZN(fileAmount);
            lbl_Count.Text = GetZN(filePages);

            lbl_DocNumber.Text = GetValue(docNumber);
            lbl_User.Text += GetValue(user);
        }

        private string GetValue(object value) => value == null ? string.Empty : value.ToString();

        private string GetZN(int param)
        {
            string[] number = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
            string[] dom = { "", "拾", "佰", "仟", "万", "拾万", "佰万", "仟万" };
            string index = GetValue(param);
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < index.Length; i++)
            {
                sb.Append(number[index[i] - '0']);
                sb.Append(dom[index.Length - 1 - i]);
            }
            return sb.ToString();
        }
    }
}
