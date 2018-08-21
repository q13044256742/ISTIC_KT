using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_ExportList : Form
    {
        private object objId;
        public object SpeCode;
        public object SpeName;
        public ControlType controlType;
        public Frm_ExportList(object objId, ControlType controlType)
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.objId = objId;
            this.controlType = controlType;
            if(controlType == ControlType.Default)
            {
                chk_TotalTable.Enabled = false;
            }
        }

        private void lbl_SelectPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                txt_Path.Text = dialog.SelectedPath;
            }
        }

        private void btn_Sure_Click(object sender, System.EventArgs e)
        {
            string path = txt_Path.Text;
            if(!string.IsNullOrEmpty(path))
            {
                bool result = false;
                Text = "正在合成Word文档，请稍等。。。";
                pic_Wait.Visible = true;
                btn_Sure.Enabled = false;
                new Thread(delegate ()
                {
                    //档案清单
                    if(chk_DocumentList.Checked)
                    {
                        string filePath = path + "\\重大专项项目（课题）档案清单.doc";
                        if(!File.Exists(filePath))
                            File.Create(filePath).Close();
                        DataTable table = SQLiteHelper.ExecuteQuery($"SELECT fi.fi_id, fi.fi_name name, fi_code categor, dd2.dd_name carrier, fi.fi_pages pages, fi.fi_remark remark FROM files_info fi " +
                            "LEFT JOIN data_dictionary dd ON dd.dd_id = fi.fi_categor  " +
                            "LEFT JOIN data_dictionary dd2 ON dd2.dd_id = fi.fi_carrier " +
                            $"WHERE fi.fi_obj_id='{objId}';");
                        result = MicrosoftWordExportHelper.WriteDocumentList(filePath, table, SpeName, SpeCode, objId);
                    }
                    //汇总表
                    if(chk_TotalTable.Checked)
                    {
                        string filePath = path + "\\重大专项项目（课题）档案汇总表.doc";
                        if(!File.Exists(filePath))
                            File.Create(filePath).Close();
                        DataTable table = new DataTable();
                        table.Columns.AddRange(new DataColumn[]
                        {
                        new DataColumn("id"),
                        new DataColumn("code"),
                        new DataColumn("name"),
                        new DataColumn("user"),
                        new DataColumn("count")
                        });
                        if(controlType == ControlType.Plan_Project)
                        {
                            string querySql = $"SELECT pi_id id, pi_code code, pi_name name, pi_project_user user, COUNT(fi_id) count FROM project_info " +
                                $"LEFT JOIN files_info ON fi_obj_id = pi_id WHERE pi_id='{objId}' GROUP BY id;";
                            DataRow proRow = SQLiteHelper.ExecuteSingleRowQuery(querySql);
                            table.ImportRow(proRow);

                            querySql = $"SELECT ti_id id, ti_code code, ti_name name, ti_project_user user, COUNT(fi_id) count FROM topic_info " +
                                $"LEFT JOIN files_info ON fi_obj_id = ti_id WHERE ti_obj_id='{proRow["id"]}' GROUP BY id";
                            DataTable topTable = SQLiteHelper.ExecuteQuery(querySql);
                            foreach(DataRow row in topTable.Rows)
                            {
                                table.ImportRow(row);
                                string _querySql = $"SELECT si_id id, si_code code, si_name name, si_project_user user, COUNT(fi_id) count FROM subject_info " +
                                    $"LEFT JOIN files_info ON fi_obj_id = si_id WHERE si_obj_id='{row["id"]}' GROUP BY id";
                                DataTable subTable = SQLiteHelper.ExecuteQuery(_querySql);
                                foreach(DataRow _row in subTable.Rows)
                                    table.ImportRow(_row);
                            }

                            string __querySql = $"SELECT si_id id, si_code code, si_name name, si_project_user user, COUNT(fi_id) count FROM subject_info " +
                                $"LEFT JOIN files_info ON fi_obj_id = si_id WHERE si_obj_id='{proRow["id"]}' GROUP BY id";
                            DataTable _subTable = SQLiteHelper.ExecuteQuery(__querySql);
                            foreach(DataRow _row in _subTable.Rows)
                                table.ImportRow(_row);
                        }
                        else if(controlType == ControlType.Topic)
                        {
                            string querySql = $"SELECT ti_id id, ti_code code, ti_name name, ti_project_user user, COUNT(fi_id) count FROM topic_info " +
                                 $"LEFT JOIN files_info ON fi_obj_id = ti_id WHERE ti_id='{objId}' GROUP BY id";
                            DataRow topRow = SQLiteHelper.ExecuteSingleRowQuery(querySql);
                            table.ImportRow(topRow);

                            string _querySql = $"SELECT si_id id, si_code code, si_name name, si_project_user user, COUNT(fi_id) count FROM subject_info " +
                                    $"LEFT JOIN files_info ON fi_obj_id = si_id WHERE si_obj_id='{topRow["id"]}' GROUP BY id";
                            DataTable subTable = SQLiteHelper.ExecuteQuery(_querySql);
                            foreach(DataRow _row in subTable.Rows)
                                table.ImportRow(_row);
                        }

                        result = MicrosoftWordExportHelper.WriteTotalTable(filePath, table, SpeName);
                    }
                    //缺失文件清单
                    if(chk_LostFileList.Checked)
                    {
                        string filePath = path + "\\重大专项项目（课题）缺失文件清单.doc";
                        if(!File.Exists(filePath))
                            File.Create(filePath).Close();
                        string querySql = "SELECT dd_name name, dd_name||' '||extend_3 dd_name, dd_note, extend_2 FROM data_dictionary WHERE dd_pId in(" +
                            "SELECT dd_id FROM data_dictionary WHERE dd_pId = (SELECT dd_id FROM data_dictionary  WHERE dd_code = 'dic_file_jd')) " +
                            $"AND name NOT IN(SELECT dd.dd_name FROM files_info fi LEFT JOIN data_dictionary dd ON fi.fi_categor = dd.dd_id where fi.fi_obj_id='{objId}') AND name<>'其他' " +
                            $"ORDER BY dd_name";
                        DataTable table = SQLiteHelper.ExecuteQuery(querySql);
                        result = MicrosoftWordExportHelper.WriteLostDocumentList(filePath, table, SpeName, SpeCode, objId);
                    }
                    pic_Wait.Visible = false;
                    btn_Sure.Enabled = true;

                    if(result)
                    {
                        if(MessageBox.Show("合成完毕，是否现在打开所在文件夹？", "确认提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            WinFormOpenHelper.OpenWinForm(0, "open", path, null, null, ShowWindowCommands.SW_NORMAL);
                        }
                        Close();
                    }
                }).Start();
            }
        }

        private void Frm_ExportList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!btn_Sure.Enabled)
            {
                MessageBox.Show("请等待任务完成，此时退出可能造成数据错误。", "提示", MessageBoxButtons.OK);
                e.Cancel = true;
            }
        }
    }
}
