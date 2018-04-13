using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using 数据采集档案管理系统___加工版;

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

                            CopyDataTable(sPath, rootFolder);

                            MessageBox.Show($"读取完毕,共计{count}个文件。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            DialogResult = DialogResult.OK;
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
        /// 拷贝数据库
        /// 【课题组 >> 专项办】
        /// </summary>
        /// <param name="rootFolder">课题组数据库文件路径</param>
        private void CopyDataTable(string sourPath, string rootFolder)
        {
            if(Directory.Exists(sourPath))
            {
                string[] files = Directory.GetFiles(sourPath, "*.db");
                if(files != null && files.Length > 0)
                {
                    FileInfo fileInfo = new FileInfo(files[0]);
                    for(int i = 1; i < files.Length; i++)
                    {
                        FileInfo _fileInfo = new FileInfo(files[i]);
                        if(_fileInfo.LastWriteTime > fileInfo.LastWriteTime)
                            fileInfo = _fileInfo;
                    }
                    CopyDataTableInstince(fileInfo.FullName, rootFolder);
                }
            }
        }

        /// <summary>
        /// 复制文件
        /// </summary>
        private void CopyDataTableInstince(string dataBasePath, string rootFolder)
        {
            SQLiteBackupHelper helper = new SQLiteBackupHelper(dataBasePath);
            DataTable projectTable = helper.ExecuteQuery($"SELECT * FROM project_info");
            int length = projectTable.Rows.Count;
            for(int i = 0; i < length; i++)
            {
                SetTip($"正在导入数据库[project_info({i}\\{length})]");
                DataRow row = projectTable.Rows[i];
                string insertSql = "INSERT INTO project_info VALUES(" +
                    $"'{row["pi_id"]}', '{row["pi_code"]}', '{row["pi_name"]}', '{row["pi_field"]}', '{row["pi_theme"]}', '{row["pi_funds"]}', '{GetFormatDate(row["pi_startdate"])}', '{GetFormatDate(row["pi_finishdate"])}', " +
                    $"'{row["pi_year"]}', '{row["pi_unit"]}', '{row["pi_province"]}', '{row["pi_unit_user"]}', '{row["pi_project_user"]}', '{row["pi_contacts"]}', '{row["pi_contacts_phone"]}', '{row["pi_introduction"]}', '{row["pi_obj_id"]}')";
                SQLiteHelper.ExecuteNonQuery($"DELETE FROM project_info WHERE pi_id='{row["pi_id"]}'");
                SQLiteHelper.ExecuteNonQuery(insertSql);
            }

            DataTable topicTable = helper.ExecuteQuery($"SELECT * FROM topic_info");
            length = topicTable.Rows.Count;
            for(int i = 0; i < length; i++)
            {
                SetTip($"正在导入数据库[topic_info({i}\\{length})]");
                DataRow row = topicTable.Rows[i];
                string insertSql = "INSERT INTO topic_info VALUES(" +
                    $"'{row["ti_id"]}', '{row["ti_code"]}', '{row["ti_name"]}', '{row["ti_field"]}', '{row["ti_theme"]}', '{row["ti_funds"]}', '{GetFormatDate(row["ti_startdate"])}', '{GetFormatDate(row["ti_finishdate"])}'," +
                    $"'{row["ti_year"]}', '{row["ti_unit"]}', '{row["ti_province"]}', '{row["ti_unit_user"]}', '{row["ti_project_user"]}', '{row["ti_contacts"]}', '{row["ti_contacts_phone"]}', '{ row["ti_introduction"]}', '{row["ti_obj_id"]}')";
                SQLiteHelper.ExecuteNonQuery($"DELETE FROM topic_info WHERE ti_id='{row["ti_id"]}'");
                SQLiteHelper.ExecuteNonQuery(insertSql);
            }

            DataTable subjectTable = helper.ExecuteQuery($"SELECT * FROM subject_info");
            length = subjectTable.Rows.Count;
            for(int i = 0; i < length; i++)
            {
                SetTip($"正在导入数据库[subject_info({i}\\{length})]");
                DataRow row = subjectTable.Rows[i];
                string insertSql = "INSERT INTO subject_info VALUES(" +
                    $"'{row["si_id"]}', '{row["si_code"]}', '{row["si_name"]}', '{row["si_field"]}', '{row["si_theme"]}', '{row["si_funds"]}', '{GetFormatDate(row["si_startdate"])}', '{GetFormatDate(row["si_finishdate"])}'," +
                    $"'{row["si_year"]}', '{row["si_unit"]}', '{row["si_province"]}', '{row["si_unit_user"]}', '{row["si_project_user"]}', '{row["si_contacts"]}', '{row["si_contacts_phone"]}', '{row["si_introduction"]}', '{row["si_obj_id"]}')";
                SQLiteHelper.ExecuteNonQuery($"DELETE FROM subject_info WHERE si_id='{row["si_id"]}'");
                SQLiteHelper.ExecuteNonQuery(insertSql);
            }

            DataTable fileTable = helper.ExecuteQuery($"SELECT * FROM files_info");
            length = fileTable.Rows.Count;
            for(int i = 0; i < length; i++)
            {
                SetTip($"正在导入数据库[files_info({i}\\{length})]");
                DataRow row = fileTable.Rows[i];
                //转换为当前服务器链接
                string link = GetValue(row["fi_link"]);
                if(!string.IsNullOrEmpty(link))
                {
                    string fileName = Path.GetFileName(link);
                    string[] files = Directory.GetFiles(rootFolder, "*" + fileName, SearchOption.AllDirectories);
                    for(int j = 0; j < files.Length; j++)
                    {
                        string parent = Directory.GetParent(files[j]).Name;
                        string real = GetRealParentName(row["fi_obj_id"]);
                        if(string.IsNullOrEmpty(real))
                            link = real;
                        else if(parent.Equals(real))
                        {
                            link = files[j];
                            break;
                        }
                    }
                }
                string insertSql = "INSERT INTO files_info VALUES(" +
                    $"'{row["fi_id"]}', '{row["fi_code"]}', '{row["fi_stage"]}', '{row["fi_categor"]}', '{row["fi_name"]}', '{row["fi_user"]}', '{row["fi_type"]}', '{row["fi_secret"]}', '{row["fi_pages"]}'," +
                    $"'{row["fi_number"]}', '{GetFormatDate(row["fi_create_date"])}', '{row["fi_unit"]}', '{row["fi_carrier"]}', '{row["fi_format"]}', '{row["fi_form"]}', '{link}', '{row["fi_status"]}', '{row["fi_obj_id"]}', '{row["fi_sort"]}')";
                SQLiteHelper.ExecuteNonQuery($"DELETE FROM files_info WHERE fi_id='{row["fi_id"]}'");
                SQLiteHelper.ExecuteNonQuery(insertSql);
            }

            DataTable lostTable = helper.ExecuteQuery($"SELECT * FROM files_lost_info");
            length = lostTable.Rows.Count;
            for(int i = 0; i < length; i++)
            {
                SetTip($"正在导入数据库[files_lost_info({i}\\{length})]");
                DataRow row = lostTable.Rows[i];
                string insertSql = $"INSERT INTO files_lost_info VALUES('{row["pfo_id"]}', '{row["pfo_categor"]}', '{row["pfo_name"]}', '{row["pfo_reason"]}', '{row["pfo_remark"]}', '{row["pfo_obj_id"]}')";
                SQLiteHelper.ExecuteNonQuery($"DELETE FROM files_lost_info WHERE pfo_id='{row["pfo_id"]}'");
                SQLiteHelper.ExecuteNonQuery(insertSql);
            }

            DataTable tagTable = helper.ExecuteQuery($"SELECT * FROM files_tag_info");
            length = tagTable.Rows.Count;
            for(int i = 0; i < length; i++)
            {
                SetTip($"正在导入数据库[files_tag_info({i}\\{length})]");
                DataRow row = tagTable.Rows[i];
                string insertSql = $"INSERT INTO files_tag_info(pt_id, pt_code, pt_name, pt_term, pt_secret, pt_user, pt_unit, pt_obj_id, pt_special_id) " +
                    $"VALUES('{row["pt_id"]}', '{row["pt_code"]}', '{row["pt_name"]}', '{row["pt_term"]}', '{row["pt_secret"]}', '{row["pt_user"]}', '{row["pt_unit"]}', '{row["pt_obj_id"]}', '{row["pt_special_id"]}')";
                SQLiteHelper.ExecuteNonQuery($"DELETE FROM files_tag_info WHERE pt_id='{row["pt_id"]}'");
                SQLiteHelper.ExecuteNonQuery(insertSql);
            }

            DataTable boxTable = helper.ExecuteQuery($"SELECT * FROM files_box_info");
            length = boxTable.Rows.Count;
            for(int i = 0; i < length; i++)
            {
                SetTip($"正在导入数据库[files_box_info({i}\\{length})]");
                DataRow row = boxTable.Rows[i];
                string insertSql = $"INSERT INTO files_box_info(pb_id, pb_box_number, pb_gc_id, pb_files_id, pb_obj_id, pb_special_id) " +
                    $"VALUES('{row["pb_id"]}', '{row["pb_box_number"]}', '{row["pb_gc_id"]}', '{row["pb_files_id"]}', '{row["pb_obj_id"]}', '{row["pb_special_id"]}')";
                SQLiteHelper.ExecuteNonQuery($"DELETE FROM files_box_info WHERE pb_id='{row["pb_id"]}'");
                SQLiteHelper.ExecuteNonQuery(insertSql);
            }
        }

        private string GetRealParentName(object id)
        {
            object name = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT pi_name FROM project_info WHERE pi_id='{id}'");
            if(name == null)
                name = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT ti_name FROM topic_info WHERE ti_id='{id}'");
            if(name == null)
                name = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT si_name FROM subject_info WHERE si_id='{id}'");
            return GetValue(name);
        }

        private string GetValue(object v) => v == null ? string.Empty : v.ToString();

        private void SetTip(string msg) => tip.Text = "提示：" + msg;

        private object GetFormatDate(object v) => v == null ? DateTime.Now.ToString("s") : Convert.ToDateTime(v).ToString("s");

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
