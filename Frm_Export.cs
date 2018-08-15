using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_Export : Form
    {
        public Frm_Export()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载待移交列表
        /// </summary>
        private void LoadDataList()
        {
            DataTable _table = new DataTable();
            _table.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("id"),
                new DataColumn("code"),
                new DataColumn("name"),
                new DataColumn("date"),
                new DataColumn("state"),
            });

            //项目
            DataTable proTable = SQLiteHelper.ExecuteQuery("SELECT pi_id id, pi_code code, pi_name name, hr_lastupdate date, hr_isupdate state FROM project_info " +
                $"LEFT JOIN handover_record ON pi_id=hr_obj_id WHERE pi_obj_id='{UserHelper.GetUser().SpecialId}'");
            for(int i = 0; i < proTable.Rows.Count; i++)
            {
                DataRow _proRow = proTable.Rows[i];
                _table.ImportRow(_proRow);
                //项目-课题
                DataTable proTopTable = SQLiteHelper.ExecuteQuery($"SELECT ti_id id, ti_code code, ti_name name, hr_lastupdate date, hr_isupdate state FROM topic_info " +
                    $"LEFT JOIN handover_record ON ti_id=hr_obj_id WHERE ti_obj_id='{_proRow[0]}'");
                for(int j = 0; j < proTopTable.Rows.Count; j++)
                {
                    DataRow _proTopRow = proTopTable.Rows[j];
                    _table.ImportRow(_proTopRow);
                    //项目-课题-子课题
                    DataTable proTopSubTable = SQLiteHelper.ExecuteQuery($"SELECT si_id id, si_code code, si_name name, hr_lastupdate date, hr_isupdate state FROM subject_info " +
                        $"LEFT JOIN handover_record ON si_id=hr_obj_id WHERE si_obj_id='{_proTopRow[0]}'");
                    for(int k = 0; k < proTopSubTable.Rows.Count; k++)
                    {
                        DataRow _proTopSubRow = proTopSubTable.Rows[k];
                        _table.ImportRow(_proTopSubRow);
                    }
                }
            }

            //课题
            DataTable topTable = SQLiteHelper.ExecuteQuery($"SELECT ti_id id, ti_code code, ti_name name, hr_lastupdate date, hr_isupdate state FROM topic_info " +
                $"LEFT JOIN handover_record ON ti_id=hr_obj_id WHERE ti_obj_id='{UserHelper.GetUser().SpecialId}'");
            for(int j = 0; j < topTable.Rows.Count; j++)
            {
                DataRow _topRow = topTable.Rows[j];
                _table.ImportRow(_topRow);
                //课题-子课题
                DataTable topSubTable = SQLiteHelper.ExecuteQuery($"SELECT si_id id, si_code code, si_name name, hr_lastupdate date, hr_isupdate state FROM subject_info " +
                    $"LEFT JOIN handover_record ON si_id=hr_obj_id WHERE si_obj_id='{_topRow[0]}'");
                for(int k = 0; k < topSubTable.Rows.Count; k++)
                {
                    DataRow _topSubRow = topSubTable.Rows[k];
                    _table.ImportRow(_topSubRow);
                }
            }

            lsv_DataList.Items.Clear();
            foreach(DataRow row in _table.Rows)
            {
                ListViewItem item = lsv_DataList.Items.Add(GetValue(row["code"]));
                item.SubItems.AddRange(new ListViewItem.ListViewSubItem[]
                {
                    new ListViewItem.ListViewSubItem(){ Text = GetValue(row["name"])},
                    new ListViewItem.ListViewSubItem(){ Text = GetValue(row["date"])},
                    new ListViewItem.ListViewSubItem(){ Text = row["date"] == null ? string.Empty : GetStateValue(row["state"]) },
                });
                item.Tag = row["id"];
            }
        }

        private string GetStateValue(object state)
        {
            string sta = GetValue(state);
            if(!string.IsNullOrEmpty(sta))
            {
                int index = Convert.ToInt32(sta);
                if(index == 1)
                    return "√";
                else if(index == 0)
                    return "×";
            }
            return string.Empty;
        }

        /// <summary>
        /// 移交
        /// </summary>
        private void Btn_Export_Click(object sender, EventArgs e)
        {
            int amount = lsv_DataList.CheckedItems.Count;
            if(amount > 0)
            {
                string targetPath = txt_ExportPath.Text;
                if(!string.IsNullOrEmpty(targetPath))
                {
                    pic_Wait.Visible = true;
                    btn_Export.Enabled = false;

                    for(int i = 0; i < amount; i++)
                    {
                        string code = lsv_DataList.CheckedItems[i].Text;
                        string _targetPath = targetPath + "\\" + code;
                        if(!Directory.Exists(_targetPath))
                            Directory.CreateDirectory(_targetPath);
                        string rootFolder = pro_GuiDang.Tag + "\\" + UserHelper.GetUser().SpecialName;
                        string[] directories = Directory.GetDirectories(rootFolder, code, SearchOption.AllDirectories);
                        if(directories.Length > 0)
                        {
                            DirectoryInfo directory = new DirectoryInfo(directories[0]);
                            FileInfo[] files = directory.GetFiles();
                            foreach(FileInfo file in files)
                            {
                                string targetFilePath = _targetPath + "\\" + file.Name;
                                if(!File.Exists(targetFilePath))
                                    File.Create(targetFilePath).Close();
                                File.Copy(file.FullName, targetFilePath, true);
                            }
                        }

                        object id = lsv_DataList.CheckedItems[i].Tag;
                        object historyId = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT hr_id FROM handover_record WHERE hr_obj_id='{id}'");
                        if(historyId == null)
                            SQLiteHelper.ExecuteNonQuery($"INSERT INTO handover_record (hr_id, hr_obj_id, hr_lastupdate) " +
                                $"VALUES('{Guid.NewGuid().ToString()}', '{id}', '{DateTime.Now.ToString("s")}'); ");
                        else
                            SQLiteHelper.ExecuteNonQuery($"UPDATE handover_record SET hr_lastupdate='{DateTime.Now.ToString("s")}', hr_isupdate=0 WHERE hr_id = '{historyId}'");
                    }

                    pic_Wait.Visible = false;
                    btn_Export.Enabled = true;
                    if(MessageBox.Show("移交完毕，是否现在打开文件夹？", "温馨提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                        WinFormOpenHelper.OpenWinForm(0, "open", null, null, targetPath, ShowWindowCommands.SW_NORMAL);
                    LoadDataList();
                }
                else
                    MessageBox.Show("请指定移交路径。", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
                MessageBox.Show("请至少选择一条待移交的数据。", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                UpdateGuiDangPro(pro_GuiDang.Value++);
            }
        }

        /// <summary>
        /// 更新进度信息
        /// </summary>
        /// <param name="value">当前进度</param>
        private void UpdateGuiDangPro(int value)
        {
            double _value = Convert.ToDouble(value + 1);
            double max = Convert.ToDouble(pro_GuiDang.Maximum);
            if(max >= value)
            {
                string showTip = $"当前归档进度[{value + 1}/{max}]（{(_value / max).ToString("p")}）：";
                lbl_GuiDangPro.Text = showTip;
                lbl_GuiDangPro.Update();
            }
        }

        private int GetCount(object objId) => SQLiteHelper.ExecuteCountQuery($"SELECT COUNT(fi_id) FROM files_info WHERE fi_obj_id='{objId}' AND fi_link IS NOT NULL");
        private string GetValue(object v) => v == null ? string.Empty : v.ToString();

        /// <summary>
        /// 获取指定专项下所包含的文件总数
        /// </summary>
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

        /// <summary>
        /// 归档
        /// </summary>
        private void Btn_GuiDang_Click(object sender, EventArgs e)
        {
            int needGDFileAmount = GetTotalFileAmountBySpiId(UserHelper.GetUser().SpecialId);
            pro_GuiDang.Value = pro_GuiDang.Minimum = 0;
            pro_GuiDang.Maximum = needGDFileAmount;

            object KEY = "SAVE_PATH";
            object value = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT dd_name FROM data_dictionary WHERE dd_code='{KEY}'");
            if(value != null)
            {
                pro_GuiDang.Tag = value;
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

                gro_GuiDang.Text += "[归档完毕]";
                gro_YiJiao.Enabled = true;
                LoadDataList();
                gro_GuiDang.Enabled = false;
            }
            else
                MessageBox.Show("请先设置归档文件存放路径(全文路径)。", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach(ListViewItem item in lsv_DataList.Items)
            {
                item.Checked = checkBox1.Checked;
            }
        }
    }
}
