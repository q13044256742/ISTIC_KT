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
                string rootFolder = value + "\\" + SQLiteHelper.ExecuteOnlyOneQuery($"SELECT spi_name FROM special_info WHERE spi_id='{UserHelper.GetUser().UserSpecialId}'");
                if(!Directory.Exists(rootFolder))
                    Directory.CreateDirectory(rootFolder);
                //专项下的文件
                CopyFile(ref okcount, ref nocount, rootFolder, GetFileLinkByObjId(UserHelper.GetUser().UserSpecialId));
                //专项下的项目
                List<object[]> list2 = SQLiteHelper.ExecuteColumnsQuery($"SELECT pi_id, pi_name FROM project_info WHERE pi_obj_id='{UserHelper.GetUser().UserSpecialId}'", 2);
                for(int i = 0; i < list2.Count; i++)
                {
                    string _rootFolder = rootFolder + "\\" + list2[i][1];
                    if(!Directory.Exists(_rootFolder))
                        Directory.CreateDirectory(_rootFolder);
                    //项目下的文件
                    CopyFile(ref okcount, ref nocount, _rootFolder, GetFileLinkByObjId(list2[i][0]));

                    //项目下的课题
                    List<object[]> list5 = SQLiteHelper.ExecuteColumnsQuery($"SELECT ti_id, ti_name FROM topic_info WHERE ti_obj_id='{list2[i][0]}'", 2);
                    for(int j = 0; j < list5.Count; j++)
                    {
                        string _rootFolder2 = _rootFolder + "\\" + list5[j][1];
                        if(!Directory.Exists(_rootFolder2))
                            Directory.CreateDirectory(_rootFolder2);
                        //课题下的文件
                        CopyFile(ref okcount, ref nocount, _rootFolder2, GetFileLinkByObjId(list5[j][0]));

                        //课题下的子课题
                        List<object[]> list6 = SQLiteHelper.ExecuteColumnsQuery($"SELECT si_id, si_name FROM subject_info WHERE si_obj_id='{list5[j][0]}'", 2);
                        for(int k = 0; k < list6.Count; k++)
                        {
                            string _rootFolder3 = _rootFolder2 + "\\" + list6[k][1];
                            if(!Directory.Exists(_rootFolder3))
                                Directory.CreateDirectory(_rootFolder3);
                            CopyFile(ref okcount, ref nocount, _rootFolder3, GetFileLinkByObjId(list6[k][0]));
                        }
                    }
                    //项目下的子课题
                    List<object[]> list7 = SQLiteHelper.ExecuteColumnsQuery($"SELECT si_id, si_name FROM subject_info WHERE si_obj_id='{list2[i][0]}'", 2);
                    for(int j = 0; j < list7.Count; j++)
                    {
                        string _rootFolder2 = _rootFolder + "\\" + list7[j][1];
                        if(!Directory.Exists(_rootFolder2))
                            Directory.CreateDirectory(_rootFolder2);
                        CopyFile(ref okcount, ref nocount, _rootFolder2, GetFileLinkByObjId(list7[j][0]));
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
                    CopyFile(ref okcount, ref nocount, _rootFolder, GetFileLinkByObjId(list4[i][0]));

                    //课题下的子课题
                    List<object[]> list6 = SQLiteHelper.ExecuteColumnsQuery($"SELECT si_id, si_name FROM subject_info WHERE si_obj_id='{list4[i][0]}'", 2);
                    for(int k = 0; k < list6.Count; k++)
                    {
                        string _rootFolder3 = _rootFolder + "\\" + list6[k][1];
                        if(!Directory.Exists(_rootFolder3))
                            Directory.CreateDirectory(_rootFolder3);
                        CopyFile(ref okcount, ref nocount, _rootFolder3, GetFileLinkByObjId(list6[k][0]));
                    }
                }
                MessageBox.Show($"数据已完成备份至指定路径，共计{count}个文件，成功{okcount}个，失败{nocount}个。", "操作成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                
                /* ----合成文件清单----*/
                string filePath = value + "\\重大专项项目（课题）档案交接清单";
                MicrosoftWordHelper.WriteDocument(ref filePath, list);
                Close();
            }
            else
                MessageBox.Show("尚未指定文件存放路径。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private static List<object[]> GetFileLinkByObjId(object objId) => SQLiteHelper.ExecuteColumnsQuery($"SELECT fi_link FROM files_info WHERE fi_obj_id='{objId}'", 1);

        /// <summary>
        /// 复制文件
        /// </summary>
        /// <param name="rootFolder">目标文件夹</param>
        /// <param name="list">待复制文件路径列表</param>
        private void CopyFile(ref int okcount, ref int nocount, string rootFolder, List<object[]> list)
        {
            for(int i = 0; i < list.Count; i++)
            {
                string filePath = GetValue(list[i][0]);
                if(!string.IsNullOrEmpty(filePath))
                {
                    if(File.Exists(filePath))
                    {
                        string destFile = rootFolder + "\\" + Path.GetFileName(filePath);
                        if(!File.Exists(destFile))
                            File.Create(destFile).Close();
                        File.Copy(filePath, destFile, true);
                        okcount++;
                    }
                    else
                        nocount++;
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
    }
}
