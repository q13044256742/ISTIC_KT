﻿using System;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_AddFile : Form
    {
        private DataGridView view;
        private object key;
        private object fileId;
        public object parentId;
        public Frm_AddFile(DataGridView view, object key, object fileId)
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            this.view = view;
            this.key = key;
            if(fileId != null)
            {
                Text = "编辑文件";
                this.fileId = fileId;
            }
        }

        private void Frm_AddFile_Load(object sender, EventArgs e)
        {
            //阶段
            cbo_stage.DataSource = DictionaryHelper.GetTableByCode("dic_file_jd");
            cbo_stage.DisplayMember = "dd_name";
            cbo_stage.ValueMember = "dd_id";
            //类别
            LoadCategorByStage(cbo_stage.SelectedValue);
            //默认焦点
            cbo_stage.Focus();
            //编辑状态加载信息
            LoadFileInfo(fileId);
        }

        private void LoadFileInfo(object fileId)
        {
            DataRow row = SQLiteHelper.ExecuteSingleRowQuery($"SELECT * FROM files_info WHERE fi_id='{fileId}'");
            if(row != null)
            {
                cbo_stage.SelectedValue = row["fi_stage"];
                Cbo_stage_SelectionChangeCommitted(null, null);
                cbo_categor.SelectedValue = row["fi_categor"];
                txt_fileCode.Text = GetValue(row["fi_code"]);
                txt_fileName.Text = GetValue(row["fi_name"]);
                txt_user.Text = GetValue(row["fi_user"]);
                SetFileRadio(pal_type, row["fi_type"]);
                string _page = GetValue(row["fi_pages"]);
                if(!string.IsNullOrEmpty(_page))
                    num_page.Value = Convert.ToInt32(_page);
                string _count = GetValue(row["fi_count"]);
                if(!string.IsNullOrEmpty(_count))
                    num_count.Value = Convert.ToInt32(_count);
                txt_Date.Text = GetDateValue(row["fi_create_date"], "yyyy-MM-dd");
                txt_unit.Text = GetValue(row["fi_unit"]);
                LoadFileLinkList(GetValue(row["fi_file_id"]));
                txt_Remark.Text = GetValue(row["fi_remark"]);
            }
        }

        private string GetDateValue(object v1, string v2)
        {
            if(DateTime.TryParse(GetValue(v1), out DateTime result))
                return result.ToString(v2);
            return string.Empty;
        }

        private void LoadFileLinkList(string ids)
        {
            if(!string.IsNullOrEmpty(ids))
            {
                string[] _ids = ids.Split(',');
                for(int i = 0; i < _ids.Length; i++)
                {
                    if(!string.IsNullOrEmpty(_ids[i]))
                    {
                        object filePath = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT bfi_path||'\\'||bfi_name FROM backup_files_info WHERE bfi_id='{_ids[i]}'");
                        AddFileToList(GetValue(filePath), _ids[i]);
                    }
                }
            }
        }

        private void SetFileCheckBox(Panel panel, object id)
        {
            foreach(CheckBox item in panel.Controls)
            {
                if(panel.Tag.Equals(id))
                    item.Checked = true;
                else if(item.Tag.Equals(id))
                {
                    item.Checked = true;
                    return;
                }
            }
        }

        /// <summary>
        /// 选中指定ID的单选框
        /// </summary>
        private void SetFileRadio(Panel panel, object id)
        {
            foreach(RadioButton item in panel.Controls)
            {
                if(item.Tag.Equals(id))
                {
                    item.Checked = true;
                    break;
                }
            }
        }

        /// <summary>
        /// 获取选定单选框的ID
        /// </summary>
        private object GetFileRadio(Panel panel)
        {
            object result = null;
            foreach(Control item in panel.Controls)
            {
                if(item is RadioButton)
                {
                    if((item as RadioButton).Checked)
                    {
                        result = item.Tag;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 获取选定复选框的ID
        /// </summary>
        private object GetFileCheckBox(Panel panel)
        {
            int index = 0;
            object id = null;
            foreach(Control item in panel.Controls)
            {
                if(item is CheckBox)
                {
                    CheckBox cb = item as CheckBox;
                    if(cb.Checked)
                    {
                        index++;
                        id = cb.Tag;
                    }
                }
            }
            return index > 1 ? panel.Tag : id;
        }

        /// <summary>
        /// 根据阶段加载类别
        /// </summary>
        private void LoadCategorByStage(object stageValue)
        {
            string querySql = $"SELECT dd_id, dd_name||' '||extend_3 AS dd_name FROM data_dictionary WHERE dd_pId='{stageValue}' ORDER BY dd_sort";
            cbo_categor.DataSource = SQLiteHelper.ExecuteQuery(querySql);
            cbo_categor.DisplayMember = "dd_name";
            cbo_categor.ValueMember = "dd_id";
        }

        /// <summary>
        /// 根据类别加载文件名称
        /// </summary>
        private void LoadFileNameByCategor(ComboBox comboBox)
        {
            string _tempKey = comboBox.Text.Split(' ')[0];
            if(string.IsNullOrEmpty(_tempKey))
            {
                string _tempKeyObj = GetValue(((DataRowView)comboBox.Items[comboBox.SelectedIndex]).Row.ItemArray[1]);
                if(!string.IsNullOrEmpty(_tempKeyObj))
                    _tempKey = _tempKeyObj.Split(' ')[0];
            }
            object key = _tempKey;
            object value = comboBox.SelectedValue;

            object[] fileName = SQLiteHelper.ExecuteSingleColumnQuery($"SELECT fi_name FROM files_info WHERE fi_categor='{value}' AND fi_obj_id='{parentId}'");
            txt_fileName.Items.Clear();
            txt_fileName.Items.AddRange(fileName);
            txt_fileName.Text = GetValue(SQLiteHelper.ExecuteOnlyOneQuery($"SELECT dd_note FROM data_dictionary WHERE dd_id='{value}'"));

            int amount = SQLiteHelper.ExecuteCountQuery($"SELECT COUNT(fi_id) FROM files_info WHERE fi_categor='{value}' AND fi_obj_id='{parentId}'");

            int _amount = comboBox.Items.Count;
            if(comboBox.SelectedIndex == _amount - 1)
            {
                string tempKey = ((DataRowView)comboBox.Items[0]).Row.ItemArray[1].ToString();
                string _key = GetValue(tempKey).Substring(0, 1) + _amount.ToString().PadLeft(2, '0');
                txt_fileCode.Text = _key + "-" + (amount + 1).ToString().PadLeft(2, '0');
            }
            else
                txt_fileCode.Text = key + "-" + (amount + 1).ToString().PadLeft(2, '0');
        }

        /// <summary>
        /// 阶段下拉切换事件
        /// </summary>
        private void Cbo_stage_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadCategorByStage(cbo_stage.SelectedValue);
            Cbo_categor_SelectedIndexChanged(sender, e);
        }

        private string GetValue(object obj)
        {
            return obj == null ? string.Empty : obj.ToString();
        }
        
        /// <summary>
        /// 文件类别下拉事件
        /// </summary>
        private void Cbo_categor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbo_categor.SelectedIndex != -1)
            {
                int index = cbo_categor.SelectedIndex;
                int maxIndex = cbo_categor.Items.Count;
                LoadFileNameByCategor(cbo_categor);

                if(index == maxIndex - 1)//其他
                {
                    cbo_categor.Tag = cbo_categor.SelectedValue;
                    cbo_categor.DropDownStyle = ComboBoxStyle.DropDown;

                    string value = txt_fileCode.Text.Split('-')[0] + "-";
                    cbo_categor.Text = value;
                    cbo_categor.SelectionStart = value.Length;
                }
                else
                {
                    cbo_categor.DropDownStyle = ComboBoxStyle.DropDownList;
                }
            }
        }

        //private ExeToWinForm form;

        /// <summary>
        /// 打开文件
        /// </summary>
        private void Btn_OpenFile_Click(object sender, EventArgs e)
        {
           
        }

        private bool NotExist(string fullPath)
        {
            foreach(ListViewItem item in lsv_LinkList.Items)
                if(fullPath.Equals(item.SubItems[1].Text))
                    return false;
            return true;
        }

        private void AddFileToList(string fullPath, string fid)
        {
            string id = (lsv_LinkList.Items.Count + 1).ToString();
            ListViewItem item = lsv_LinkList.Items.Add(id);
            item.SubItems.AddRange(new ListViewItem.ListViewSubItem[]
            {
                new ListViewItem.ListViewSubItem(){ Text = fullPath },
            });
            item.Tag = fid;
        }

        /// <summary>
        /// 添加信息到指定表格
        /// </summary>
        private object SaveFileInfo(DataGridViewRow row, bool isAdd)
        {
            bool isOtherType = cbo_categor.SelectedIndex == -1;

            object primaryKey = Guid.NewGuid().ToString();
            row.Cells[key + "id"].Value = row.Index + 1;
            row.Cells[key + "stage"].Value = cbo_stage.SelectedValue;
            SetCategorByStage(cbo_stage.SelectedValue, row, key);
            row.Cells[key + "categor"].Value = cbo_categor.SelectedValue ?? cbo_categor.Tag;
            object categorName = isOtherType ? cbo_categor.Text.Split('-')[1].Trim() : null;
            row.Cells[key + "name"].Value = txt_fileName.Text;
            row.Cells[key + "code"].Value = txt_fileCode.Text;
            row.Cells[key + "user"].Value = txt_user.Text;
            row.Cells[key + "type"].Value = GetFileRadio(pal_type);
            row.Cells[key + "pages"].Value = num_page.Value;
            row.Cells[key + "count"].Value = num_count.Value;
            row.Cells[key + "date"].Value = txt_Date.Text;
            row.Cells[key + "unit"].Value = txt_unit.Text;
            row.Cells[key + "carrier"].Value = GetCarrierValue();
            row.Cells[key + "link"].Value = GetFullStringBySplit(GetLinkList(2), "；", string.Empty);
            row.Cells[key + "link"].Tag = GetFullStringBySplit(GetLinkList(1), ";", "'");
            if(isAdd)
            {
                object stage = row.Cells[key + "stage"].Value;
                object categor = row.Cells[key + "categor"].Value;
                object code = row.Cells[key + "code"].Value;
                object name = row.Cells[key + "name"].Value;
                object user = row.Cells[key + "user"].Value;
                object type = row.Cells[key + "type"].Value;
                object pages = row.Cells[key + "pages"].Value;
                object count = row.Cells[key + "count"].Value;
                object date = row.Cells[key + "date"].Value;
                object unit = row.Cells[key + "unit"].Value;
                object carrier = row.Cells[key + "carrier"].Value;
                object link = row.Cells[key + "link"].Value;
                string fileId = GetFullStringBySplit(GetLinkList(1), ",", "'");
                object remark = txt_Remark.Text;

                if(isOtherType)
                {
                    categor = Guid.NewGuid().ToString();
                    object pid = cbo_stage.SelectedValue;
                    string value = txt_fileCode.Text.Split('-')[0];
                    int sort = cbo_categor.Items.Count - 1;

                    string _insertSql = "INSERT INTO data_dictionary (dd_id, dd_name, dd_note, dd_pId, dd_sort, extend_3, extend_4) " +
                        $"VALUES('{categor}', '{value}', '{name}', '{pid}', '{sort}', '{categorName}', '{1}');";
                    SQLiteHelper.ExecuteNonQuery(_insertSql);
                }

                string insertSql = "INSERT INTO files_info (" +
                "fi_id, fi_code, fi_stage, fi_categor, fi_code, fi_name, fi_user, fi_type, fi_pages, fi_count, fi_create_date, fi_unit, fi_carrier, fi_link, fi_file_id, fi_obj_id, fi_sort, fi_remark) " +
                $"VALUES( '{primaryKey}', '{code}', '{stage}', '{categor}', '{code}', '{name}', '{user}', '{type}', '{pages}', '{count}', '{date}', '{unit}', '{carrier}', '{link}', '{GetFullStringBySplit(GetLinkList(1), ",", string.Empty)}', '{parentId}', '{row.Index}', '{remark}');";
                //将备份表中的文件标记为已选取
                if(!string.IsNullOrEmpty(fileId))
                    insertSql += $"UPDATE backup_files_info SET bfi_state=1 WHERE bfi_id IN ({fileId});";
                SQLiteHelper.ExecuteNonQuery(insertSql);

                row.Cells[key + "id"].Tag = primaryKey;
            }
            else
            {
                primaryKey = row.Cells[key + "id"].Tag;
                object stage = row.Cells[key + "stage"].Value;
                object categor = row.Cells[key + "categor"].Value;
                object code = row.Cells[key + "code"].Value;
                object name = row.Cells[key + "name"].Value;
                object user = row.Cells[key + "user"].Value;
                object type = row.Cells[key + "type"].Value;
                object pages = row.Cells[key + "pages"].Value;
                object count = row.Cells[key + "count"].Value;
                object date = row.Cells[key + "date"].Value;
                object unit = row.Cells[key + "unit"].Value;
                object carrier = row.Cells[key + "carrier"].Value;
                object link = row.Cells[key + "link"].Value;
                string fileId = GetFullStringBySplit(GetLinkList(1), ",", "'");
                object remark = txt_Remark.Text;

                string oldFileId = GetValue(SQLiteHelper.ExecuteOnlyOneQuery($"SELECT fi_file_id FROM files_info WHERE fi_id='{primaryKey}';"));
                string updateSql = $"UPDATE backup_files_info SET bfi_state=0 WHERE bfi_id IN ({GetFullStringBySplit(oldFileId, ",", "'")});";
                updateSql += "UPDATE files_info SET " +
                   $"fi_stage = '{stage}', " +
                   $"fi_categor = '{categor}', " +
                   $"fi_code = '{code}', " +
                   $"fi_name = '{name}', " +
                   $"fi_user = '{user}', " +
                   $"fi_type = '{type}', " +
                   $"fi_pages = '{pages}', " +
                   $"fi_count = '{count}', " +
                   $"fi_create_date = '{date}', " +
                   $"fi_unit = '{unit}', " +
                   $"fi_carrier = '{carrier}', " +
                   $"fi_link = '{link}', " +
                   $"fi_remark = '{remark}', " +
                   $"fi_file_id = '{GetFullStringBySplit(GetLinkList(1), ",", string.Empty)}' " +
                   $"WHERE fi_id = '{primaryKey}';";
                if(!string.IsNullOrEmpty(fileId))
                    updateSql += $"UPDATE backup_files_info SET bfi_state=1 WHERE bfi_id IN ({fileId});";
                SQLiteHelper.ExecuteNonQuery(updateSql);
                MessageBox.Show("数据已保存。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            SQLiteHelper.ExecuteNonQuery($"UPDATE handover_record SET hr_isupdate=1 WHERE hr_obj_id='{parentId}'");
            return primaryKey;
        }

        /// <summary>
        /// 获取载体类型
        /// </summary>
        private object GetCarrierValue()
        {
            bool isPaper = num_count.Value != 0;
            bool isElect = lsv_LinkList.Items.Count != 0;
            if(isPaper && isElect)
                return "e7bce5d4-38b7-4d74-8aa2-c580b880aabb";
            else if(isPaper && !isElect)
                return "e7bce5d4-38b7-4d74-8aa2-c580b880aaba";
            else if(!isPaper && isElect)
                return "6ffdf849-31fa-4401-a640-c371cd994daf";
            return null;
        }

        /// <summary>
        /// 将用,切割后的字符串用指定间隔符和引号重新组合
        /// </summary>
        public string GetFullStringBySplit(string _str, string flag, string param)
        {
            string result = string.Empty;
            string[] strs = _str.Split(',');
            for(int i = 0; i < strs.Length; i++)
            {
                result += $"{param}{strs[i]}{param}{flag}";
            }
            return result.Length > 0 ? result.Substring(0, result.Length - 1) : string.Empty;
        }

        /// <summary>
        /// 将字符串数组转换成指定分隔符组合成的字符串
        /// </summary>
        /// <param name="_str">字符串数组</param>
        /// <param name="flag">分隔符</param>
        /// <param name="param">引号类型</param>
        private string GetFullStringBySplit(string[] _str, string flag, string param)
        {
            string str = string.Empty;
            for(int i = 0; i < _str.Length; i++)
                str += $"{param}{_str[i]}{param}{flag}";
            return string.IsNullOrEmpty(str) ? string.Empty : str.Substring(0, str.Length - 1);
        }

        /// <summary>
        /// 获取文件链接主键
        /// </summary>
        /// <param name="type"><para>1：ID</para><para>2：链接地址</para></param>
        private string[] GetLinkList(int type)
        {
            string[] result = new string[lsv_LinkList.Items.Count];
            for(int i = 0; i < result.Length; i++)
            {
                if(type == 1)
                    result[i] = GetValue(lsv_LinkList.Items[i].Tag);
                else if(type == 2)
                    result[i] = GetValue(lsv_LinkList.Items[i].SubItems[1].Text);
            }
            return result;
        }

        /// <summary>
        /// 保存(更新)
        /// </summary>
        private void Btn_Save_Add_Click(object sender, EventArgs e)
        {
            if(CheckDatas())
            {
                if(Text.Contains("新增"))
                {
                    fileId = SaveFileInfo(view.Rows[view.Rows.Add()], true);
                    ResetControl();
                }
                else if(Text.Contains("编辑"))
                    UpdateFileInfo();
                //WindowState = FormWindowState.Normal;
                //if(form != null)
                //{
                //    form.Stop();
                //    form = null;
                //}
            }
            else
                MessageBox.Show("检查数据是否完整。", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private bool CheckDatas()
        {
            errorProvider1.Clear();
            bool result = true;
            //文件类别
            if(cbo_categor.SelectedIndex == -1 || cbo_categor.SelectedIndex == cbo_categor.Items.Count - 1)
            {
                string value = cbo_categor.Text.Trim();
                if(string.IsNullOrEmpty(value) || value.StartsWith("-") || value.EndsWith("-") || !value.Contains("-"))
                {
                    errorProvider1.SetError(cbo_categor, "提示：请输入文件类别名称。");
                    result = false;
                }
            }
            //页数
            NumericUpDown pagesCell = num_page;
            if(pagesCell.Value == 0)
            {
                errorProvider1.SetError(pagesCell, "提示：页数不能为0。");
                result = false;
            }
            //文件名
            string nameValue = txt_fileName.Text.Trim();
            if(string.IsNullOrEmpty(nameValue))
            {
                errorProvider1.SetError(txt_fileName, "提示：文件名不能为空。");
                result = false;
            }
            else if(Text.Contains("新增"))
            {
                int _count = SQLiteHelper.ExecuteCountQuery($"SELECT COUNT(fi_id) FROM files_info WHERE fi_name='{nameValue}' AND fi_obj_id='{parentId}'");
                if(_count > 0)
                {
                    errorProvider1.SetError(txt_fileName, "提示：文件名已存在，请重新输入。");
                    result = false;
                }
            }
            //编号
            if(string.IsNullOrEmpty(txt_fileCode.Text.Trim()))
            {
                errorProvider1.SetError(txt_fileCode, "提示：编号不能为空。");
                result = false;
            }
            //文件类型
            int count = 0;
            foreach(RadioButton item in pal_type.Controls)
                if(item.Checked)
                { count++; break; }
            if(count == 0)
            {
                errorProvider1.SetError(pal_type, "提示：文件类型不能为空。");
                result = false;
            }
            //存放单位
            if(string.IsNullOrEmpty(txt_unit.Text.Trim()))
            {
                errorProvider1.SetError(txt_unit, "提示：存放单位不能为空。");
                result = false;
            }

            string dateString = txt_Date.Text;
            if(!string.IsNullOrEmpty(dateString))
            {
                bool flag = DateTime.TryParse(GetValue(dateString), out DateTime date);
                if(!flag)
                {
                    errorProvider1.SetError(txt_Date, "提示：请输入格式为 yyyy-MM-dd 的有效日期。");
                    result = false;
                }
            }

            return result;
        }

        /// <summary>
        /// 更新文件
        /// </summary>
        private void UpdateFileInfo()
        {
            foreach(DataGridViewRow row in view.Rows)
            {
                if(fileId.Equals(row.Cells[key + "id"].Tag))
                {
                    SaveFileInfo(row, false);
                    break;
                }
            }
        }

        /// <summary>
        /// 根据阶段设置相应的文件类别
        /// </summary>
        /// <param name="jdId">阶段ID</param>
        public void SetCategorByStage(object jdId, DataGridViewRow dataGridViewRow, object key)
        {
            DataGridViewComboBoxCell categorCell = dataGridViewRow.Cells[key + "categor"] as DataGridViewComboBoxCell;
            string querySql = $"SELECT dd_id, dd_name||' '||extend_3 as dd_name FROM data_dictionary WHERE dd_pId='{jdId}' ORDER BY dd_sort";
            categorCell.DataSource = SQLiteHelper.ExecuteQuery(querySql);
            categorCell.DisplayMember = "dd_name";
            categorCell.ValueMember = "dd_id";
        }
        
        /// <summary>
        /// 重置控件
        /// </summary>
        private void ResetControl()
        {
            foreach(Control item in Controls)
            {
                if(!(item is Label))
                {
                    if(item is TextBox || item is DateTimePicker)
                        item.ResetText();
                    else if(item is NumericUpDown)
                        (item as NumericUpDown).Value = 0;
                    else if(item is DateTimePicker)
                        (item as DateTimePicker).Value = DateTime.Now;
                    else if(item is ComboBox)
                    {
                        if(item.Name.Equals("txt_fileName"))
                        {
                            ComboBox cbo = item as ComboBox;
                            cbo.Items.Clear();
                            cbo.Text = null;
                        }
                        else if(!item.Name.Equals("cbo_stage"))
                        {
                            (item as ComboBox).SelectedIndex = 0;
                        }
                    }
                    else if(item is Panel)
                    {
                        foreach(Control con in item.Controls)
                        {
                            if(con is RadioButton)
                                (con as RadioButton).Checked = false;
                            else if(con is CheckBox)
                                (con as CheckBox).Checked = false;
                        }
                    }
                    else if(item is ListView)
                    {
                        (item as ListView).Items.Clear();
                    }
                }
            }
            txt_unit.Text = UserHelper.GetUser().UserUnitName;
        }

        private void Frm_AddFile_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.Enter)
            {
                Btn_Save_Add_Click(null, null);
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            ResetControl();
            if(Text.Contains("编辑"))
                LoadFileInfo(fileId);
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            if(fileId == null)
            {
                if(MessageBox.Show("尚未保存当前数据，是否确认退出？", "确认提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
                    Close();
            }
            else
                Close();
        }

        private void txt_fileName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            object fileName = txt_fileName.SelectedItem;
            if(fileName != null)
            {
                Hide();
                DataRow row = SQLiteHelper.ExecuteSingleRowQuery($"SELECT fi_id FROM files_info WHERE fi_name='{fileName}' AND fi_obj_id='{parentId}'");
                new Frm_AddFile(view, key, row["fi_id"]).ShowDialog();
            }
        }

        private void Frm_AddFile_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!btn_Save.Enabled)
                if(MessageBox.Show("确定要强制退出吗?", "确认提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.Cancel)
                    e.Cancel = true;
        }

        /// <summary>
        /// 移除指定挂接文件
        /// </summary>
        private void lsv_LinkList_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                int count = lsv_LinkList.SelectedItems.Count;
                if(count > 0)
                {
                    if(MessageBox.Show("是否删除选中项？", "确认提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        for(int i = 0; i < count; i++)
                            lsv_LinkList.SelectedItems[0].Remove();
                }
            }
        }

        private void lbl_OpenFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            object[] rootId = SQLiteHelper.ExecuteSingleColumnQuery($"SELECT bfi_id FROM backup_files_info WHERE bfi_code = '-1'");
            if(rootId.Length > 0)
            {
                Frm_AddFile_FileSelect frm = new Frm_AddFile_FileSelect(rootId);
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    string[] fullPath = frm.SelectedFileName;
                    for(int i = 0; i < fullPath.Length; i++)
                    {
                        if(File.Exists(fullPath[i]))
                        {
                            if(NotExist(fullPath[i]))
                                AddFileToList(fullPath[i], frm.SelectedFileId[i]);
                            else
                                MessageBox.Show($"{Path.GetFileName(fullPath[i])}文件已存在，不可重复添加。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                            MessageBox.Show($"服务器不存在文件{Path.GetFileName(fullPath[i])}。", "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            else
                MessageBox.Show("当前专项尚未导入数据。", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void lsv_LinkList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lsv_LinkList.SelectedItems.Count;
            if(index > 0 && MessageBox.Show("是否打开文件？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ListViewItem item = lsv_LinkList.SelectedItems[0];
                string filePath = item.SubItems[1].Text;
                if(!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    WinFormOpenHelper.OpenWinForm(Handle.ToInt32(), "open", filePath, null, null, ShowWindowCommands.SW_NORMAL);
                }
            }
        }

    }
}
