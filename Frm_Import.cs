using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_Import : Form
    {
        /// <summary>
        /// 共计文件数
        /// </summary>
        private int count = 0;
        /// <summary>
        /// 导入成功数
        /// </summary>
        private int okCount = 0;
        /// <summary>
        /// 导入失败输
        /// </summary>
        private int noCount = 0;
        int indexCount = 0;
        public Frm_Import()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
      
        /// <summary>
        /// 路径选择
        /// </summary>
        private void btn_Import_Click(object sender, EventArgs e)
        {
            if(fbd_Data.ShowDialog() == DialogResult.OK)
            {
                txt_FilePath.Text = fbd_Data.SelectedPath;
                pro_Show.Value = pro_Show.Minimum;
            }
        }

        /// <summary>
        /// 开始读取
        /// </summary>
        private void btn_Import_Click_1(object sender, EventArgs e)
        {
            string sPath = txt_FilePath.Text;
            if(!string.IsNullOrEmpty(sPath))
            {
                if(SQLiteHelper.ExecuteCountQuery($"SELECT COUNT(*) FROM backup_files_info WHERE bfi_name='{UserHelper.GetUser().RealName}' AND bfi_code='-1'") == 0)
                {
                    object IPAddress = null;
                    if(ServerHelper.GetConnectState(ref IPAddress))
                    {
                        btn_Import.Enabled = false;
                        count = okCount = noCount = indexCount = 0;
                        int totalFileAmount = Directory.GetFiles(sPath, "*", SearchOption.AllDirectories).Length;
                        pro_Show.Value = pro_Show.Minimum;
                        pro_Show.Maximum = totalFileAmount;

                        string rootFolder = @"\\" + IPAddress + @"\共享文件夹\" + UserHelper.GetUser().SpecialName + @"\";
                        if(!Directory.Exists(rootFolder))
                            Directory.CreateDirectory(rootFolder);
                        string primaryKey = Guid.NewGuid().ToString();
                        SQLiteHelper.ExecuteNonQuery($"INSERT INTO backup_files_info(bfi_id, bfi_code, bfi_name, bfi_date, bfi_userid) VALUES " +
                            $"('{primaryKey}', '{-1}', '{UserHelper.GetUser().RealName}', '{DateTime.Now.ToString("s")}', '{UserHelper.GetUser().UserId}')");
                        new Thread(delegate ()
                        {
                            CopyFile(sPath, rootFolder, primaryKey);
                            MessageBox.Show($"读取完毕,共计{count}个文件。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            Close();
                            Thread.CurrentThread.Abort();
                        }).Start();
                    }
                    else
                        MessageBox.Show("访问备份服务器失败。", "连接错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(MessageBox.Show("当前专项已导入,是否删除当前文件。", "操作失败", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    SQLiteHelper.ExecuteNonQuery($"DELETE FROM backup_files_info WHERE bfi_userid='{UserHelper.GetUser().UserId}'");
                    MessageBox.Show("删除完毕，重新导入即可。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        
        /// <summary>
        /// 拷贝文件到备份服务器
        /// </summary>
        /// <param name="sPath">源文件夹路径</param>
        /// <param name="rootFolder">目标文件夹基路径</param>
        private void CopyFile(string sPath, string rootFolder, string pid)
        {
            DirectoryInfo info = new DirectoryInfo(sPath);
            FileInfo[] file = info.GetFiles();
            count += file.Length;
            for(int i = 0; i < file.Length; i++)
            {
                string primaryKey = Guid.NewGuid().ToString();
                try
                {
                    SQLiteHelper.ExecuteNonQuery($"INSERT INTO backup_files_info(bfi_id, bfi_code, bfi_name, bfi_path, bfi_date, bfi_pid, bfi_userid) VALUES " +
                        $"('{primaryKey}', '{indexCount++.ToString().PadLeft(6, '0')}', '{file[i].Name}', '{rootFolder}', '{DateTime.Now.ToString("s")}', '{pid}', '{UserHelper.GetUser().UserId}')");
                    ServerHelper.UploadFile(file[i].FullName, rootFolder, file[i].Name);
                    okCount++;
                }
                catch(Exception)
                {
                    noCount++;
                }
                pro_Show.Value += 1;
            }
            DirectoryInfo[] infos = info.GetDirectories();
            for(int i = 0; i < infos.Length; i++)
            {
                string primaryKey = Guid.NewGuid().ToString();
                SQLiteHelper.ExecuteNonQuery($"INSERT INTO backup_files_info(bfi_id, bfi_code, bfi_name, bfi_path, bfi_date, bfi_pid, bfi_userid) VALUES " +
                        $"('{primaryKey}', '{indexCount++.ToString().PadLeft(6, '0')}', '{infos[i].Name}', '{rootFolder}', '{DateTime.Now.ToString("s")}', '{pid}', '{UserHelper.GetUser().UserId}')");
                CopyFile(infos[i].FullName, rootFolder + infos[i].Name + @"\", primaryKey);
            }
        }

        private void Frm_Import_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(okCount + noCount != count)
            {
                MessageBox.Show("请等待导入完毕,中途退出会导致数据错误。", "无法关闭", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Cancel = true;
            }
        }
    }
}
