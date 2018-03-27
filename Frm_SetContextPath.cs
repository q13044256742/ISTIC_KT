using System;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_SetContextPath : Form
    {
        private object KEY = "SAVE_PATH";
        public Frm_SetContextPath()
        {
            InitializeComponent();
        }

        private void btn_ChoosePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txt_ContextPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btn_Sure_Click(object sender, EventArgs e)
        {
            object id = txt_ContextPath.Tag;
            string path = txt_ContextPath.Text;
            if(!string.IsNullOrEmpty(path))
            {
                if(id == null)
                    SQLiteHelper.ExecuteNonQuery($"INSERT INTO data_dictionary(dd_id, dd_code, dd_name) VALUES('{Guid.NewGuid().ToString()}','{KEY}','{path}')");
                else
                    SQLiteHelper.ExecuteNonQuery($"UPDATE data_dictionary SET dd_name='{path}' WHERE dd_id='{id}'");
                MessageBox.Show("设置成功！", "恭喜", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void Frm_SetContextPath_Load(object sender, EventArgs e)
        {
            object[] obj = SQLiteHelper.ExecuteRowsQuery($"SELECT dd_id, dd_name FROM data_dictionary WHERE dd_code='{KEY}'");
            if(obj != null)
            {
                txt_ContextPath.Tag = obj[0];
                txt_ContextPath.Text = obj[1] == null ? string.Empty : obj[1].ToString();
            }
        }
    }
}
