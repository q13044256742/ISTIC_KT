using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_Export : Form
    {
        private List<DataRow> list;

        public Frm_Export()
        {
            InitializeComponent();
            list = new List<DataRow>();
            LoadTopicList();
        }

        private void LoadTopicList()
        {
            object specialId = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT pi_id FROM project_info WHERE pi_obj_id='{UserHelper.GetUser().UserSpecialId}'");
            if(specialId != null)
            {
                DataTable table = SQLiteHelper.ExecuteQuery($"SELECT ti_id, ti_name FROM topic_info WHERE ti_obj_id='{specialId}'");
                cbo_TopicId.DataSource = table;
                cbo_TopicId.DisplayMember = "ti_name";
                cbo_TopicId.ValueMember = "ti_id";
            }
        }

        private void Frm_Export_Load(object sender, EventArgs e)
        {
            LoadFileInfo(UserHelper.GetUser().UserSpecialId);
            List<object[]> projectIds = SQLiteHelper.ExecuteColumnsQuery($"SELECT pi_id FROM project_info WHERE pi_obj_id='{UserHelper.GetUser().UserSpecialId}'", 1);
            for(int i = 0; i < projectIds.Count; i++)
            {
                LoadFileInfo(projectIds[i][0]);
                List<object[]> pro_top_ids = SQLiteHelper.ExecuteColumnsQuery($"SELECT ti_id FROM topic_info WHERE ti_obj_id='{projectIds[i][0]}'", 1);
                for(int j = 0; j < pro_top_ids.Count; j++)
                {
                    LoadFileInfo(pro_top_ids[j][0]);
                    List<object[]> pro_top_sub_ids = SQLiteHelper.ExecuteColumnsQuery($"SELECT si_id FROM subject_info WHERE si_obj_id='{pro_top_ids[j][0]}'", 1);
                    for(int k = 0; k < pro_top_sub_ids.Count; k++)
                        LoadFileInfo(pro_top_sub_ids[k][0]);
                }
            }
            List<object[]> topicIds = SQLiteHelper.ExecuteColumnsQuery($"SELECT ti_id FROM topic_info WHERE ti_obj_id='{UserHelper.GetUser().UserSpecialId}'", 1);
            for(int i = 0; i < topicIds.Count; i++)
            {
                LoadFileInfo(topicIds[i][0]);
                List<object[]> pro_top_sub_ids = SQLiteHelper.ExecuteColumnsQuery($"SELECT si_id FROM subject_info WHERE si_obj_id='{topicIds[i][0]}'", 1);
                for(int k = 0; k < pro_top_sub_ids.Count; k++)
                    LoadFileInfo(pro_top_sub_ids[k][0]);
            }

            pro_Show.Maximum = list.Count;
        }

        private void LoadFileInfo(object pid)
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
                /* ----复制文件----*/
                pro_Show.Maximum = GetTotalFileAmountBySpiId(UserHelper.GetUser().UserSpecialId);
                int count = pro_Show.Maximum, okcount = 0, nocount = 0;
                string rootFolder = value + "\\" + UserHelper.GetUser().SpecialName;
                if(!Directory.Exists(rootFolder))
                    Directory.CreateDirectory(rootFolder);
               
                //专项下的项目
                List<object[]> list2 = SQLiteHelper.ExecuteColumnsQuery($"SELECT pi_id, pi_name FROM project_info WHERE pi_obj_id='{UserHelper.GetUser().UserSpecialId}'", 2);
                for(int i = 0; i < list2.Count; i++)
                {
                    string _rootFolder = rootFolder + "\\" + list2[i][1];
                    if(!Directory.Exists(_rootFolder))
                        Directory.CreateDirectory(_rootFolder);
                    //项目下的文件
                    CopyFile(ref okcount, ref nocount, _rootFolder, GetFileLinkByObjId(list2[i][0]), true);

                    //项目下的课题
                    List<object[]> list5 = SQLiteHelper.ExecuteColumnsQuery($"SELECT ti_id, ti_name FROM topic_info WHERE ti_obj_id='{list2[i][0]}'", 2);
                    for(int j = 0; j < list5.Count; j++)
                    {
                        string _rootFolder2 = _rootFolder + "\\" + list5[j][1];
                        if(!Directory.Exists(_rootFolder2))
                            Directory.CreateDirectory(_rootFolder2);
                        //课题下的文件
                        CopyFile(ref okcount, ref nocount, _rootFolder2, GetFileLinkByObjId(list5[j][0]), true);

                        //课题下的子课题
                        List<object[]> list6 = SQLiteHelper.ExecuteColumnsQuery($"SELECT si_id, si_name FROM subject_info WHERE si_obj_id='{list5[j][0]}'", 2);
                        for(int k = 0; k < list6.Count; k++)
                        {
                            string _rootFolder3 = _rootFolder2 + "\\" + list6[k][1];
                            if(!Directory.Exists(_rootFolder3))
                                Directory.CreateDirectory(_rootFolder3);
                            CopyFile(ref okcount, ref nocount, _rootFolder3, GetFileLinkByObjId(list6[k][0]), true);
                        }
                    }
                    //项目下的子课题
                    List<object[]> list7 = SQLiteHelper.ExecuteColumnsQuery($"SELECT si_id, si_name FROM subject_info WHERE si_obj_id='{list2[i][0]}'", 2);
                    for(int j = 0; j < list7.Count; j++)
                    {
                        string _rootFolder2 = _rootFolder + "\\" + list7[j][1];
                        if(!Directory.Exists(_rootFolder2))
                            Directory.CreateDirectory(_rootFolder2);
                        CopyFile(ref okcount, ref nocount, _rootFolder2, GetFileLinkByObjId(list7[j][0]), true);
                    }
                }
                //专项下的课题
                List<object[]> list4 = SQLiteHelper.ExecuteColumnsQuery($"SELECT ti_id, ti_name FROM topic_info WHERE ti_obj_id='{UserHelper.GetUser().UserSpecialId}'", 2);
                for(int i = 0; i < list4.Count; i++)
                {
                    string _rootFolder = rootFolder + "\\" + list4[i][1];
                    if(!Directory.Exists(_rootFolder))
                        Directory.CreateDirectory(_rootFolder);
                    //课题下的文件
                    CopyFile(ref okcount, ref nocount, _rootFolder, GetFileLinkByObjId(list4[i][0]), true);

                    //课题下的子课题
                    List<object[]> list6 = SQLiteHelper.ExecuteColumnsQuery($"SELECT si_id, si_name FROM subject_info WHERE si_obj_id='{list4[i][0]}'", 2);
                    for(int k = 0; k < list6.Count; k++)
                    {
                        string _rootFolder3 = _rootFolder + "\\" + list6[k][1];
                        if(!Directory.Exists(_rootFolder3))
                            Directory.CreateDirectory(_rootFolder3);
                        CopyFile(ref okcount, ref nocount, _rootFolder3, GetFileLinkByObjId(list6[k][0]), true);
                    }
                }

                /* --------归档-------- */
                int _oc = 0, _nc = 0;
                string exportPath = txt_ExportPath.Text;
                object topicId = cbo_TopicId.SelectedValue;
                if(!string.IsNullOrEmpty(exportPath) && topicId != null)
                {
                    object[] topic = SQLiteHelper.ExecuteRowsQuery($"SELECT ti_id, ti_name FROM topic_info WHERE ti_id='{topicId}'");
                    string _tf = exportPath + "\\" + topic[1];
                    if(!Directory.Exists(_tf)) Directory.CreateDirectory(_tf);
                    CopyFile(ref _oc, ref _nc, _tf, GetFileLinkByObjId(topic[0]), false);

                    //课题下的子课题
                    List<object[]> _list = SQLiteHelper.ExecuteColumnsQuery($"SELECT si_id, si_name FROM subject_info WHERE si_obj_id='{topic[0]}'", 2);
                    for(int k = 0; k < _list.Count; k++)
                    {
                        string _tfs = _tf + "\\" + _list[k][1];
                        if(!Directory.Exists(_tfs)) Directory.CreateDirectory(_tfs);
                        CopyFile(ref _oc, ref _nc, _tfs, GetFileLinkByObjId(_list[k][0]), false);
                    }
                    string filePath = exportPath + "\\课题档案交接清单";
                    MicrosoftWordHelper.WriteDocument(ref filePath, list);

                }
                else
                    MessageBox.Show("尚未指定导出课题或导出路径。", "导出失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                MessageBox.Show($"数据归档情况：成功{okcount}，失败{nocount}。\r\n数据移交情况：成功{_oc}，失败{_nc}。", "操作完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Close();
            }
            else
                MessageBox.Show("请先指定归档文件存放路径。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private static List<object[]> GetFileLinkByObjId(object objId) => SQLiteHelper.ExecuteColumnsQuery($"SELECT fi_link, fi_file_id FROM files_info WHERE fi_obj_id='{objId}'", 2);

        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="rootFolder">目标文件夹</param>
        /// <param name="list">待复制文件路径列表</param>
        private void CopyFile(ref int okcount, ref int nocount, string rootFolder, List<object[]> list, bool showProBar)
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
                        okcount++;

                        //已归档的文件进行记录
                        string fileId = GetValue(list[i][1]);
                        SQLiteHelper.ExecuteNonQuery($"UPDATE backup_files_info SET bfi_state_gd=1 WHERE bfi_id='{fileId}'");
                    }
                    else
                        nocount++;
                    if(showProBar)
                        pro_Show.Value++;
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

        private static void LoadDocumnet(string filePath)
        {
            Microsoft.Office.Interop.Word.Application _app = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document _doc = null;
            try
            {
                object unknow = Type.Missing;
                _app.Visible = true;
                object file = filePath;
                _doc = _app.Documents.Open(ref file,
                    ref unknow, ref unknow, ref unknow, ref unknow,
                    ref unknow, ref unknow, ref unknow, ref unknow,
                    ref unknow, ref unknow, ref unknow, ref unknow,
                    ref unknow, ref unknow, ref unknow);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbl_ExportPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                txt_ExportPath.Text = dialog.SelectedPath;
            }
        }
    }
}
