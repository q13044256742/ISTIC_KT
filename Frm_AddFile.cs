using System;
using System.Data;
using System.IO;
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
            //类型
            cbo_type.DataSource = DictionaryHelper.GetTableByCode("dic_file_type");
            cbo_type.DisplayMember = "dd_name";
            cbo_type.ValueMember = "dd_id";
            //密级
            cbo_secret.DataSource = DictionaryHelper.GetTableByCode("dic_file_mj");
            cbo_secret.DisplayMember = "dd_name";
            cbo_secret.ValueMember = "dd_id";
            //载体
            cbo_carrier.DataSource = DictionaryHelper.GetTableByCode("dic_file_zt");
            cbo_carrier.DisplayMember = "dd_name";
            cbo_carrier.ValueMember = "dd_id";
            //格式
            cbo_format.DataSource = DictionaryHelper.GetTableByCode("dic_file_format");
            cbo_format.DisplayMember = "dd_name";
            cbo_format.ValueMember = "dd_id";
            //形态
            cbo_form.DataSource = DictionaryHelper.GetTableByCode("dic_file_state");
            cbo_form.DisplayMember = "dd_name";
            cbo_form.ValueMember = "dd_id";
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
                cbo_categor.SelectedValue = row["fi_categor"];
                txt_fileName.Text = GetValue(row["fi_name"]);
                txt_user.Text = GetValue(row["fi_user"]);
                cbo_type.SelectedValue = row["fi_type"];
                cbo_secret.SelectedValue = row["fi_secret"];
                num_page.Value = Convert.ToInt32(row["fi_pages"]);
                num_amount.Value = Convert.ToInt32(row["fi_number"]);
                dtp_date.Value = Convert.ToDateTime(row["fi_create_date"]);
                txt_unit.Text = GetValue(row["fi_unit"]);
                cbo_carrier.SelectedValue = row["fi_carrier"];
                cbo_format.SelectedValue = row["fi_format"];
                cbo_form.SelectedValue = row["fi_form"];
                txt_link.Text = GetValue(row["fi_link"]);
            }
        }

        /// <summary>
        /// 根据阶段加载类别
        /// </summary>
        private void LoadCategorByStage(object stageValue)
        {
            string querySql = $"SELECT dd_id, dd_name FROM data_dictionary WHERE dd_pId='{stageValue}' ORDER BY dd_sort";
            cbo_categor.DataSource = SQLiteHelper.ExecuteQuery(querySql);
            cbo_categor.DisplayMember = "dd_name";
            cbo_categor.ValueMember = "dd_id";
        }

        /// <summary>
        /// 根据类别加载文件名称
        /// </summary>
        private void LoadFileNameByCategor(object categorValue)
        {
            string value = GetValue(SQLiteHelper.ExecuteOnlyOneQuery($"SELECT dd_note FROM data_dictionary WHERE dd_id='{categorValue}'"));
            txt_fileName.Text = value;
        }

        /// <summary>
        /// 阶段下拉切换事件
        /// </summary>
        private void Cbo_stage_SelectionChangeCommitted(object sender, System.EventArgs e)
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
                LoadFileNameByCategor(cbo_categor.SelectedValue);
        }
        
        /// <summary>
        /// 打开文件
        /// </summary>
        private void Btn_OpenFile_Click(object sender, EventArgs e)
        {
            object rootId = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT bfi_id FROM backup_files_info WHERE bfi_name = '{UserHelper.GetUser().RealName}' AND bfi_code = '-1'");
            if(rootId != null)
            {
                Frm_AddFile_FileSelect frm = new Frm_AddFile_FileSelect(rootId);
                if(frm.ShowDialog() == DialogResult.OK)
                {
                    string fullPath = frm.SelectedFileName;
                    if(File.Exists(fullPath))
                    {
                        string savePath = Application.StartupPath + @"\TempBackupFolder\";
                        if(!Directory.Exists(savePath))
                            Directory.CreateDirectory(savePath);
                        string filePath = savePath + new FileInfo(fullPath).Name;
                        File.Copy(fullPath, filePath, true);
                        txt_link.Text = fullPath;
                        if(MessageBox.Show("已从服务器拷贝文件到本地，是否现在打开？", "操作确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            WindowState = FormWindowState.Maximized;
                            pal_ShowData.Visible = true;
                            pal_ShowData.Controls.Clear();

                            new ExeToWinForm(pal_ShowData, string.Empty).Start(fullPath);
                        }
                    }
                    else
                        MessageBox.Show("服务器不存在此文件。", "打开失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
                MessageBox.Show("当前专项尚未导入数据。", "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        /// <summary>
        /// 添加信息到指定表格
        /// </summary>
        private object SaveFileInfo(DataGridViewRow row, bool isAdd)
        {
            object primaryKey = Guid.NewGuid().ToString();
            row.Cells[key + "id"].Value = row.Index + 1;
            row.Cells[key + "stage"].Value = cbo_stage.SelectedValue;
            SetCategorByStage(cbo_stage.SelectedValue, row, key);
            row.Cells[key + "categor"].Value = cbo_categor.SelectedValue;
            row.Cells[key + "name"].Value = txt_fileName.Text;
            row.Cells[key + "user"].Value = txt_user.Text;
            row.Cells[key + "type"].Value = cbo_type.SelectedValue;
            row.Cells[key + "secret"].Value = cbo_secret.SelectedValue;
            row.Cells[key + "pages"].Value = num_page.Value;
            row.Cells[key + "number"].Value = num_amount.Value;
            row.Cells[key + "date"].Value = dtp_date.Value.ToString("yyyyMMdd");
            row.Cells[key + "unit"].Value = txt_unit.Text;
            row.Cells[key + "carrier"].Value = cbo_carrier.SelectedValue;
            row.Cells[key + "format"].Value = cbo_format.SelectedValue;
            row.Cells[key + "form"].Value = cbo_form.SelectedValue;
            row.Cells[key + "link"].Value = txt_link.Text;
            if(isAdd)
            {
                object stage = row.Cells[key + "stage"].Value;
                object categor = row.Cells[key + "categor"].Value;
                object name = row.Cells[key + "name"].Value;
                object user = row.Cells[key + "user"].Value;
                object type = row.Cells[key + "type"].Value;
                object secret = row.Cells[key + "secret"].Value;
                object pages = row.Cells[key + "pages"].Value;
                object number = row.Cells[key + "number"].Value;
                DateTime date = DateTime.Now;
                string _date = GetValue(row.Cells[key + "date"].Value);
                if(!string.IsNullOrEmpty(_date))
                {
                    if(_date.Length == 6)
                        _date = _date.Substring(0, 4) + "-" + _date.Substring(4, 2) + "-01";
                    if(_date.Length == 8)
                        _date = _date.Substring(0, 4) + "-" + _date.Substring(4, 2) + "-" + _date.Substring(6, 2);
                    DateTime.TryParse(_date, out date);
                }
                object unit = row.Cells[key + "unit"].Value;
                object carrier = row.Cells[key + "carrier"].Value;
                object format = row.Cells[key + "format"].Value;
                object form = row.Cells[key + "form"].Value;
                object link = row.Cells[key + "link"].Value;

                string insertSql = "INSERT INTO files_info (" +
                "fi_id, fi_code, fi_stage, fi_categor, fi_name, fi_user, fi_type, fi_secret, fi_pages, fi_number, fi_create_date, fi_unit, fi_carrier, fi_format, fi_form, fi_link, fi_obj_id) " +
                $"VALUES( '{primaryKey}', '', '{stage}', '{categor}', '{name}', '{user}', '{type}', '{secret}', '{pages}', '{number}', '{date.ToString("s")}', '{unit}', '{carrier}', '{format}', '{form}', '{link}','{parentId}')";
                SQLiteHelper.ExecuteNonQuery(insertSql);

                row.Cells[key + "id"].Tag = primaryKey;


            }
            else
            {
                primaryKey = row.Cells[key + "id"].Tag;
                object stage = row.Cells[key + "stage"].Value;
                object categor = row.Cells[key + "categor"].Value;
                object name = row.Cells[key + "name"].Value;
                object user = row.Cells[key + "user"].Value;
                object type = row.Cells[key + "type"].Value;
                object secret = row.Cells[key + "secret"].Value;
                object pages = row.Cells[key + "pages"].Value;
                object number = row.Cells[key + "number"].Value;
                DateTime date = DateTime.Now;
                string _date = GetValue(row.Cells[key + "date"].Value);
                if(!string.IsNullOrEmpty(_date))
                {
                    if(_date.Length == 6)
                        _date = _date.Substring(0, 4) + "-" + _date.Substring(4, 2) + "-01";
                    if(_date.Length == 8)
                        _date = _date.Substring(0, 4) + "-" + _date.Substring(4, 2) + "-" + _date.Substring(6, 2);
                    DateTime.TryParse(_date, out date);
                }
                object unit = row.Cells[key + "unit"].Value;
                object carrier = row.Cells[key + "carrier"].Value;
                object format = row.Cells[key + "format"].Value;
                object form = row.Cells[key + "form"].Value;
                object link = row.Cells[key + "link"].Value;

                string updateSql = "UPDATE files_info SET " +
                    $"fi_stage = '{stage}', " +
                    $"fi_categor = '{categor}', " +
                    $"fi_name = '{name}', " +
                    $"fi_user = '{user}', " +
                    $"fi_type = '{type}', " +
                    $"fi_secret = '{secret}', " +
                    $"fi_pages = '{pages}', " +
                    $"fi_number = '{number}', " +
                    $"fi_create_date = '{date.ToString("s")}', " +
                    $"fi_unit = '{unit}', " +
                    $"fi_carrier = '{carrier}', " +
                    $"fi_format = '{format}', " +
                    $"fi_form = '{form}', " +
                    $"fi_link = '{link}' " +
                    $"WHERE fi_id = '{primaryKey}'";
                SQLiteHelper.ExecuteNonQuery(updateSql);
                MessageBox.Show("数据已保存。");
            }
            return primaryKey;
        }
        
        /// <summary>
        /// 保存(更新)
        /// </summary>
        private void Btn_Save_Add_Click(object sender, EventArgs e)
        {
            string nameValue = txt_fileName.Text.Trim();
            if(string.IsNullOrEmpty(nameValue))
                MessageBox.Show("文件名不可为空。", "保存失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if(Text.Contains("新增"))
                {
                    fileId = SaveFileInfo(view.Rows[view.Rows.Add()], true);
                    ResetControl();
                }
                else if(Text.Contains("编辑"))
                    UpdateFileInfo();
                WindowState = FormWindowState.Normal;
            }
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
            string querySql = $"SELECT dd_id, dd_name FROM data_dictionary WHERE dd_pId='{jdId}' ORDER BY dd_sort";
            categorCell.DataSource = SQLiteHelper.ExecuteQuery(querySql);
            categorCell.DisplayMember = "dd_name";
            categorCell.ValueMember = "dd_id";
            categorCell.Style = new DataGridViewCellStyle() { Font = new System.Drawing.Font("宋体", 10.5f), NullValue = categorCell.Items[0] };
        }
        
        /// <summary>
        /// 重置控件
        /// </summary>
        private void ResetControl()
        {
            foreach(Control item in gro_BasicInfo.Controls)
            {
                if(!(item is Label))
                {
                    if(item is TextBox || item is DateTimePicker)
                        item.ResetText();
                    else if(item is NumericUpDown)
                        (item as NumericUpDown).Value = 0;
                    else if(item is ComboBox)
                    {
                        if(!item.Name.Equals("cbo_stage"))
                            (item as ComboBox).SelectedIndex = 0;
                    }
                }
            }
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
    }
}
