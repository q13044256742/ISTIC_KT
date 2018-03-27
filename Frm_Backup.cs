using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_Backup : Form
    {
        public Frm_Backup()
        {
            InitializeComponent();
        }

        private void lbl_SetPath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(fbd_Data.ShowDialog() == DialogResult.OK)
            {
                txt_FilePath.Text = fbd_Data.SelectedPath;
            }
        }

        private void Btn_Start_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = GetTotalFileAmountBySpiId(UserHelper.GetUser().UserSpecialId);
            int count = progressBar1.Maximum, okcount = 0, nocount = 0;
            string rootFolder = txt_FilePath.Text + "\\" + SQLiteHelper.ExecuteOnlyOneQuery($"SELECT spi_name FROM special_info WHERE spi_id='{UserHelper.GetUser().UserSpecialId}'");
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
            MessageBox.Show($"备份完成，共计{count}个文件，成功{okcount}个，失败{nocount}个。", "操作成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Close();
        }

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
                    progressBar1.Value++;
                }
            }
        }

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

        private int GetCount(object objId) => SQLiteHelper.ExecuteCountQuery($"SELECT COUNT(fi_id) FROM files_info WHERE fi_obj_id='{objId}' AND fi_link IS NOT NULL");

        /// <summary>
        /// 根据指定对象ID获取文件链接
        /// </summary>
        /// <param name="objId">指定ID</param>
        private static List<object[]> GetFileLinkByObjId(object objId) => SQLiteHelper.ExecuteColumnsQuery($"SELECT fi_link FROM files_info WHERE fi_obj_id='{objId}'", 1);

        private string GetValue(object v) => v == null ? string.Empty : v.ToString();
    }
}
