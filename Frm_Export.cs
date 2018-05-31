using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_Export : Form
    {
        public Frm_Export()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            LoadTopicList();
        }

        private void LoadTopicList()
        {
            DataTable _table = new DataTable();
            _table.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("id"),
                new DataColumn("code")
            });

            //项目
            DataTable proTable = SQLiteHelper.ExecuteQuery($"SELECT pi_id id, pi_code code FROM project_info WHERE pi_obj_id='{UserHelper.GetUser().SpecialId}'");
            for(int i = 0; i < proTable.Rows.Count; i++)
            {
                DataRow _proRow = proTable.Rows[i];
                _table.ImportRow(_proRow);
                //项目-课题
                DataTable proTopTable = SQLiteHelper.ExecuteQuery($"SELECT ti_id id, ti_code code FROM topic_info WHERE ti_obj_id='{_proRow[0]}'");
                for(int j = 0; j < proTopTable.Rows.Count; j++)
                {
                    DataRow _proTopRow = proTopTable.Rows[j];
                    _table.ImportRow(_proTopRow);
                    //项目-课题-子课题
                    DataTable proTopSubTable = SQLiteHelper.ExecuteQuery($"SELECT si_id id, si_code code FROM subject_info WHERE si_obj_id='{_proTopRow[0]}'");
                    for(int k = 0; k < proTopSubTable.Rows.Count; k++)
                    {
                        DataRow _proTopSubRow = proTopSubTable.Rows[k];
                        _table.ImportRow(_proTopSubRow);
                    }
                }
            }

            //课题
            DataTable topTable = SQLiteHelper.ExecuteQuery($"SELECT ti_id id, ti_code code FROM topic_info WHERE ti_obj_id='{UserHelper.GetUser().SpecialId}'");
            for(int j = 0; j < topTable.Rows.Count; j++)
            {
                DataRow _topRow = topTable.Rows[j];
                _table.ImportRow(_topRow);
                //课题-子课题
                DataTable topSubTable = SQLiteHelper.ExecuteQuery($"SELECT si_id id, si_code code FROM subject_info WHERE si_obj_id='{_topRow[0]}'");
                for(int k = 0; k < topSubTable.Rows.Count; k++)
                {
                    DataRow _topSubRow = topSubTable.Rows[k];
                    _table.ImportRow(_topSubRow);
                }
            }

            cbo_TopicId.DataSource = _table;
            cbo_TopicId.DisplayMember = "code";
            cbo_TopicId.ValueMember = "id";

        }

        private List<DataRow> InitialList(object id)
        {
            List<DataRow> list = new List<DataRow>();
            LoadFileInfo(list, UserHelper.GetUser().SpecialId);
            //项目
            DataRow projectRow = SQLiteHelper.ExecuteSingleRowQuery($"SELECT pi_id FROM project_info WHERE pi_id='{id}'");
            if(projectRow != null)
            {
                LoadFileInfo(list, id);
                //项目-课题
                List<object[]> pro_top_ids = SQLiteHelper.ExecuteColumnsQuery($"SELECT ti_id FROM topic_info WHERE ti_obj_id='{id}'", 1);
                for(int j = 0; j < pro_top_ids.Count; j++)
                {
                    LoadFileInfo(list, pro_top_ids[j][0]);
                    //项目-课题-子课题
                    List<object[]> pro_top_sub_ids = SQLiteHelper.ExecuteColumnsQuery($"SELECT si_id FROM subject_info WHERE si_obj_id='{pro_top_ids[j][0]}'", 1);
                    for(int k = 0; k < pro_top_sub_ids.Count; k++)
                    {
                        LoadFileInfo(list, pro_top_sub_ids[k][0]);
                    }
                }
            }
            //课题
            DataRow topicRow = SQLiteHelper.ExecuteSingleRowQuery($"SELECT ti_id FROM topic_info WHERE ti_id='{id}'");
            if(topicRow != null)
            {
                LoadFileInfo(list, id);
                //课题 - 子课题
                List<object[]> pro_top_sub_ids = SQLiteHelper.ExecuteColumnsQuery($"SELECT si_id FROM subject_info WHERE si_obj_id='{id}'", 1);
                for(int k = 0; k < pro_top_sub_ids.Count; k++)
                {
                    LoadFileInfo(list, pro_top_sub_ids[k][0]);
                }
            }
            //子课题
            DataRow subjectRow = SQLiteHelper.ExecuteSingleRowQuery($"SELECT si_id FROM subject_info WHERE si_id='{id}'");
            if(subjectRow != null)
                LoadFileInfo(list, id);
            return list;
        }

        private void LoadFileInfo(List<DataRow> list, object pid)
        {
            DataTable table = SQLiteHelper.ExecuteQuery($"SELECT * FROM files_info WHERE fi_obj_id='{pid}'");
            list.AddRange(GetArray(table));
        }

        private DataRow[] GetArray(DataTable table)
        {
            DataRow[] _row = new DataRow[table.Rows.Count];
            table.Rows.CopyTo(_row, 0);
            return _row;
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            object KEY = "SAVE_PATH";
            object value = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT dd_name FROM data_dictionary WHERE dd_code='{KEY}'");
            if(value != null)
            {
                pic_Wait.Visible = true;
                btn_Export.Enabled = false;
                txt_ExportPath.Enabled = false;
                lbl_ExportPath.Enabled = false;

                new Thread(delegate ()
                {
                    /* ----复制文件----*/
                    string rootFolder = value + "\\" + UserHelper.GetUser().SpecialName;
                    if(!Directory.Exists(rootFolder))
                    {
                        try { Directory.CreateDirectory(rootFolder); }
                        catch(Exception ex) { MessageBox.Show(ex.Message); return; }
                    }
                    //专项下的项目
                    List<object[]> list2 = SQLiteHelper.ExecuteColumnsQuery($"SELECT pi_id, pi_code FROM project_info WHERE pi_obj_id='{UserHelper.GetUser().SpecialId}'", 2);
                    for(int i = 0; i < list2.Count; i++)
                    {
                        string _rootFolder = rootFolder + "\\" + list2[i][1];
                        if(!Directory.Exists(_rootFolder))
                            Directory.CreateDirectory(_rootFolder);
                        //项目下的文件
                        CopyFile(_rootFolder, GetFileLinkByObjId(list2[i][0]), true);

                        //项目下的课题
                        List<object[]> list5 = SQLiteHelper.ExecuteColumnsQuery($"SELECT ti_id, ti_code FROM topic_info WHERE ti_obj_id='{list2[i][0]}'", 2);
                        for(int j = 0; j < list5.Count; j++)
                        {
                            string _rootFolder2 = _rootFolder + "\\" + list5[j][1];
                            if(!Directory.Exists(_rootFolder2))
                                Directory.CreateDirectory(_rootFolder2);
                            //课题下的文件
                            CopyFile(_rootFolder2, GetFileLinkByObjId(list5[j][0]), true);

                            //课题下的子课题
                            List<object[]> list6 = SQLiteHelper.ExecuteColumnsQuery($"SELECT si_id, si_code FROM subject_info WHERE si_obj_id='{list5[j][0]}'", 2);
                            for(int k = 0; k < list6.Count; k++)
                            {
                                string _rootFolder3 = _rootFolder2 + "\\" + list6[k][1];
                                if(!Directory.Exists(_rootFolder3))
                                    Directory.CreateDirectory(_rootFolder3);
                                CopyFile(_rootFolder3, GetFileLinkByObjId(list6[k][0]), true);
                            }
                        }
                        //项目下的子课题
                        List<object[]> list7 = SQLiteHelper.ExecuteColumnsQuery($"SELECT si_id, si_code FROM subject_info WHERE si_obj_id='{list2[i][0]}'", 2);
                        for(int j = 0; j < list7.Count; j++)
                        {
                            string _rootFolder2 = _rootFolder + "\\" + list7[j][1];
                            if(!Directory.Exists(_rootFolder2))
                                Directory.CreateDirectory(_rootFolder2);
                            CopyFile(_rootFolder2, GetFileLinkByObjId(list7[j][0]), true);
                        }
                    }
                    //专项下的课题
                    List<object[]> list4 = SQLiteHelper.ExecuteColumnsQuery($"SELECT ti_id, ti_code FROM topic_info WHERE ti_obj_id='{UserHelper.GetUser().SpecialId}'", 2);
                    for(int i = 0; i < list4.Count; i++)
                    {
                        string _rootFolder = rootFolder + "\\" + list4[i][1];
                        if(!Directory.Exists(_rootFolder))
                            Directory.CreateDirectory(_rootFolder);
                        //课题下的文件
                        CopyFile(_rootFolder, GetFileLinkByObjId(list4[i][0]), true);

                        //课题下的子课题
                        List<object[]> list6 = SQLiteHelper.ExecuteColumnsQuery($"SELECT si_id, si_code FROM subject_info WHERE si_obj_id='{list4[i][0]}'", 2);
                        for(int k = 0; k < list6.Count; k++)
                        {
                            string _rootFolder3 = _rootFolder + "\\" + list6[k][1];
                            if(!Directory.Exists(_rootFolder3))
                                Directory.CreateDirectory(_rootFolder3);
                            CopyFile(_rootFolder3, GetFileLinkByObjId(list6[k][0]), true);
                        }
                    }

                    /* ========== 移交 ========== */
                    string exportPath = txt_ExportPath.Text;
                    object cboId = cbo_TopicId.SelectedValue;
                    object code = null;
                    object name = null;
                    if(!string.IsNullOrEmpty(exportPath) && cboId != null)
                    {
                        /* ------ 项目 ------ */
                        object[] project = SQLiteHelper.ExecuteRowsQuery($"SELECT pi_id, pi_code, pi_name FROM project_info WHERE pi_id='{cboId}'");
                        if(project != null)
                        {
                            code = project[1]; name = project[2];
                            string _tf_Pro = exportPath + "\\" + project[1];
                            if(!Directory.Exists(_tf_Pro)) Directory.CreateDirectory(_tf_Pro);
                            CopyFile(_tf_Pro, GetFileLinkByObjId(project[0]), false);
                            //项目-课题
                            List<object[]> proTopic = SQLiteHelper.ExecuteColumnsQuery($"SELECT ti_id, ti_code FROM topic_info WHERE ti_obj_id='{project[0]}'", 2);
                            foreach(object[] item in proTopic)
                            {
                                string _tf_ProTopic = _tf_Pro + "\\" + item[1];
                                if(!Directory.Exists(_tf_ProTopic)) Directory.CreateDirectory(_tf_ProTopic);
                                CopyFile(_tf_ProTopic, GetFileLinkByObjId(item[0]), false);

                                //项目-课题-子课题
                                List<object[]> proTopicSubject = SQLiteHelper.ExecuteColumnsQuery($"SELECT si_id, si_code FROM subject_info WHERE si_obj_id='{item[0]}'", 2);
                                foreach(object[] _item in proTopicSubject)
                                {
                                    string _tfs = _tf_ProTopic + "\\" + _item[1];
                                    if(!Directory.Exists(_tfs)) Directory.CreateDirectory(_tfs);
                                    CopyFile(_tfs, GetFileLinkByObjId(_item[0]), false);
                                }
                            }
                            //项目-子课题
                            List<object[]> proSubject = SQLiteHelper.ExecuteColumnsQuery($"SELECT si_id, si_code FROM subject_info WHERE si_obj_id='{project[0]}'", 2);
                            foreach(object[] item in proSubject)
                            {
                                string _tf_ProSubject = _tf_Pro + "\\" + item[1];
                                if(!Directory.Exists(_tf_ProSubject)) Directory.CreateDirectory(_tf_ProSubject);
                                CopyFile(_tf_ProSubject, GetFileLinkByObjId(item[0]), false);
                            }
                        }
                        /* ------ 课题 ------ */
                        object[] topic = SQLiteHelper.ExecuteRowsQuery($"SELECT ti_id, ti_code, ti_name FROM topic_info WHERE ti_id='{cboId}'");
                        if(topic != null)
                        {
                            code = topic[1]; name = topic[2];
                            string _tf = exportPath + "\\" + topic[1];
                            if(!Directory.Exists(_tf)) Directory.CreateDirectory(_tf);
                            CopyFile(_tf, GetFileLinkByObjId(topic[0]), false);
                            //课题-子课题
                            List<object[]> _list = SQLiteHelper.ExecuteColumnsQuery($"SELECT si_id, si_code FROM subject_info WHERE si_obj_id='{topic[0]}'", 2);
                            for(int k = 0; k < _list.Count; k++)
                            {
                                string _tfs = _tf + "\\" + _list[k][1];
                                if(!Directory.Exists(_tfs)) Directory.CreateDirectory(_tfs);
                                CopyFile(_tfs, GetFileLinkByObjId(_list[k][0]), false);
                            }
                        }
                        /* ------ 子课题 ------ */
                        object[] subject = SQLiteHelper.ExecuteRowsQuery($"SELECT si_id, si_code, si_name FROM subject_info WHERE si_id='{cboId}'");
                        if(subject != null)
                        {
                            code = subject[1]; name = subject[2];
                            string _tf_Pro = exportPath + "\\" + subject[1];
                            if(!Directory.Exists(_tf_Pro)) Directory.CreateDirectory(_tf_Pro);
                            CopyFile(_tf_Pro, GetFileLinkByObjId(subject[0]), false);
                        }
                        string filePath = exportPath + "\\课题档案交接清单";
                        MicrosoftWordHelper.WriteDocument(ref filePath, InitialList(cboId), name, code);

                        if(MessageBox.Show($"操作成功，是否打开移交文件夹？", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk) == DialogResult.OK)
                            WinFormOpenHelper.OpenWinForm(0, "open", Path.GetDirectoryName(filePath), null, null, ShowWindowCommands.SW_NORMAL);
                    }

                    pic_Wait.Visible = false;
                    btn_Export.Enabled = true;
                    txt_ExportPath.Enabled = true;
                    lbl_ExportPath.Enabled = true;

                }).Start();
            }
            else
                MessageBox.Show("请先设置归档文件存放路径(全文路径)。", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private static List<object[]> GetFileLinkByObjId(object objId) => SQLiteHelper.ExecuteColumnsQuery($"SELECT fi_link, fi_file_id FROM files_info WHERE fi_obj_id='{objId}'", 2);

        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="rootFolder">目标文件夹</param>
        /// <param name="list">待复制文件路径列表</param>
        private void CopyFile(string rootFolder, List<object[]> list, bool showProBar)
        {
            for(int i = 0; i < list.Count; i++)
            {
                string filePath = GetValue(list[i][0]);
                if(!string.IsNullOrEmpty(filePath))
                {
                    if(File.Exists(filePath))
                    {
                        //进行归档操作【文件复制】
                        string destFile = rootFolder + "\\" + Path.GetFileName(filePath);
                        if(!File.Exists(destFile))
                            File.Create(destFile).Close();
                        File.Copy(filePath, destFile, true);

                        //已归档的文件进行记录
                        string fileId = GetValue(list[i][1]);
                        SQLiteHelper.ExecuteNonQuery($"UPDATE backup_files_info SET bfi_state_gd=1 WHERE bfi_id='{fileId}'");
                    }
                }
            }
        }

        private int GetCount(object objId) => SQLiteHelper.ExecuteCountQuery($"SELECT COUNT(fi_id) FROM files_info WHERE fi_obj_id='{objId}' AND fi_link IS NOT NULL");
        private string GetValue(object v) => v == null ? string.Empty : v.ToString();

        private int GetTotalFileAmountBySpiId(object objId)
        {
            int count = 0;
            count += GetCount(objId);
            List<object[]> list = SQLiteHelper.ExecuteColumnsQuery($"SELECT pi_id FROM project_info WHERE pi_obj_id='{objId}'", 1);
            for(int i = 0; i < list.Count; i++)
            {
                count += GetCount(list[i][0]);
                List<object[]> list3 = SQLiteHelper.ExecuteColumnsQuery($"SELECT ti_id FROM topic_info WHERE ti_obj_id='{list[i][0]}'", 1);
                for(int j = 0; j < list3.Count; j++)
                {
                    count += GetCount(list3[j][0]);
                    List<object[]> list5 = SQLiteHelper.ExecuteColumnsQuery($"SELECT si_id FROM subject_info WHERE si_obj_id='{list3[j][0]}'", 1);
                    for(int k = 0; k < list5.Count; k++)
                        count += GetCount(list5[k][0]);
                }
                List<object[]> list4 = SQLiteHelper.ExecuteColumnsQuery($"SELECT si_id FROM subject_info WHERE si_obj_id='{list[i][0]}'", 1);
                for(int j = 0; j < list4.Count; j++)
                    count += GetCount(list4[j][0]);
            }
            List<object[]> list2 = SQLiteHelper.ExecuteColumnsQuery($"SELECT ti_id FROM topic_info WHERE ti_obj_id='{objId}'", 1);
            for(int i = 0; i < list2.Count; i++)
            {
                count += GetCount(list2[i][0]);
                List<object[]> list4 = SQLiteHelper.ExecuteColumnsQuery($"SELECT si_id FROM subject_info WHERE si_obj_id='{list2[i][0]}'", 1);
                for(int j = 0; j < list4.Count; j++)
                    count += GetCount(list4[j][0]);
            }
            return count;
        }

        private void lbl_ExportPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                txt_ExportPath.Text = dialog.SelectedPath;
            }
        }

        private void Frm_Export_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!btn_Export.Enabled)
            {
                MessageBox.Show("请等待导出完成。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                e.Cancel = true;
            }
        }
    }
}
