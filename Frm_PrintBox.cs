using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using 数据采集档案管理系统___课题版.Properties;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_PrintBox : Form
    {
        /// <summary>
        /// 案卷名称
        /// </summary>
        public string objectName;
        /// <summary>
        /// 案卷编号
        /// </summary>
        public object objectCode;
        /// <summary>
        /// 编制单位
        /// </summary>
        public string unitName;
        /// <summary>
        /// 盒列表
        /// </summary>
        public DataTable boxTable;
        /// <summary>
        /// 所属对象父级名称
        /// </summary>
        public object parentObjectName;
        /// <summary>
        /// 其他密切相关文档
        /// </summary>
        public DataTable otherDoc;
        public string ljPeople;
        public object ljDate;
        public string jcPeople;
        public string jcDate;
        /// <summary>
        /// 父窗体
        /// </summary>
        private Form parentForm;
        /// <summary>
        /// 对象ID
        /// </summary>
        private object objectId;
        public Frm_PrintBox(object objectId, Form parentForm)
        {
            this.objectId = objectId;
            this.parentForm = parentForm;
            InitializeComponent();
            InitialFrom();
        }

        private void InitialFrom()
        {
            view.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", 12, FontStyle.Bold);
            toolStripComboBox1.SelectedIndex = 0;
        }

        private void Frm_PrintBox_Load(object sender, EventArgs e)
        {
            DataTable table = SQLiteHelper.ExecuteQuery($"SELECT * FROM files_box_info WHERE pb_obj_id='{objectId}' ORDER BY pb_box_number");
            foreach(DataRow row in table.Rows)
            {
                int index = view.Rows.Add();
                view.Rows[index].Tag = row["pt_id"];
                view.Rows[index].Cells["print"].Tag = row["pb_id"];
                view.Rows[index].Cells["amount"].Value = GetFilePageCount(row["pb_id"], 1);
                view.Rows[index].Cells["id"].Value = row["pb_box_number"];
                view.Rows[index].Cells["id"].Tag = row["pb_gc_id"];
                view.Rows[index].Cells["fmbj"].Value = "20mm";
            }
        }

        private void Btn_StartPrint_Click(object sender, EventArgs e)
        {
            List<object> boxIds = new List<object>();
            foreach(DataGridViewRow row in view.Rows)
            {
                object boxId = row.Cells["print"].Tag;
                foreach(DataGridViewCell cell in row.Cells)
                {
                    if(true.Equals(cell.Value))
                    {
                        boxIds.Add(boxId);
                        break;
                    }
                }
            }
            if(boxIds.Count > 0)
            {
                PrintDocument(boxIds.ToArray());
            }
            else
                MessageBox.Show("请先至少选择一盒进行打印。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void PrintDocument(object[] boxIds)
        {
            foreach(object boxId in boxIds)
            {
                foreach(DataGridViewRow row in view.Rows)
                {
                    if(boxId.Equals(row.Cells["print"].Tag))
                    {
                        object ptId = row.Tag;
                        bool printBkb = GetBooleanValue(row.Cells["bkb"].Value);
                        if(printBkb)
                        {
                            int boxNumber = (int)row.Cells["id"].Value;
                            PrintBKB(boxId, ptId, boxNumber);
                        }
                        bool printFm = GetBooleanValue(row.Cells["fm"].Value);
                        if(printFm)
                        {
                            object bj = row.Cells["fmbj"].Value;
                            object GCNumber = row.Cells["id"].Tag;
                            PrintFM(boxId, ptId, bj, GCNumber, row.Index);
                        }
                        bool printJnml = GetBooleanValue(row.Cells["jnml"].Value);
                        if(printJnml)
                        {
                            object GCNumber = row.Cells["id"].Tag;
                            PrintJNML(boxId, ptId, GCNumber);
                        }
                    }
                }
            }
        }

        private bool GetBooleanValue(object value) => value == null ? false : string.IsNullOrEmpty(value.ToString()) ? false : (bool)value;

        /// <summary>
        /// 打印卷内文件目录
        /// </summary>
        private void PrintJNML(object boxId, object ptId, object GCNumber)
        {
            object docCode = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT pt_code FROM files_tag_info WHERE pt_id='{ptId}'");
            string jnmlString = GetFileList(boxId, docCode, GCNumber);
            new WebBrowser() { DocumentText = jnmlString, ScriptErrorsSuppressed = false }.DocumentCompleted += Web_DocumentCompleted;
        }

        private object GetDateValue(object date, string format)
        {
            if(date != null)
            {
                if(DateTime.TryParse(GetValue(date), out DateTime result))
                {
                    if(result.Date != new DateTime(1900, 01, 01) &&
                       result.Date != new DateTime(0001, 01, 01))
                        return result.ToString(format);
                }
                else
                    return date;
            }
            return null;
        }

        private int GetIntValue(object value)
        {
            if(value == null)
                return 0;
            else
            {
                if(int.TryParse(GetValue(value), out int result))
                    return result;
                else
                    return 0;
            }
        }

        private string GetValue(object value) => value == null ? string.Empty : value.ToString();

        /// <summary>
        /// 获取文件数/页数
        /// </summary>
        /// <param name="boxId">盒ID</param>
        /// <param name="type">获取类型
        /// <para>1：文件数</para>
        /// <para>2：页数</para>
        /// </param>
        private int GetFilePageCount(object boxId, int type)
        {
            if(type == 1)
            {
                return SQLiteHelper.ExecuteCountQuery($"SELECT COUNT(fi_id) FROM files_info WHERE fi_box_id='{boxId}'");
            }
            else
            {
                return SQLiteHelper.ExecuteCountQuery($"SELECT SUM(fi_pages) FROM files_info WHERE fi_box_id='{boxId}'");
            }
        }

        /// <summary>
        /// 打印封面
        /// </summary>
        private void PrintFM(object boxId, object ptId, object bj, object GCNumber, int rowIndex)
        {
            object styleType = view.Rows[rowIndex].Cells["jnml"].Tag;
            int style = GetIntValue(styleType, 0);
            string fmString = style == 0 ? Resources.fm : Resources.fm2;
            object fontObject = view.Rows[rowIndex].Cells["font"].Tag;
            if(fontObject != null)
            {
                Font font = (Font)fontObject;
                fmString = fmString.Replace("FangSong", $"{font.FontFamily.Name}");
                fmString = fmString.Replace("18pt", $"{font.Size}pt");
            }
            object docCode = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT pt_code FROM files_tag_info WHERE pt_id='{ptId}';");
            fmString = GetCoverHtmlString(boxId, fmString, bj, GCNumber, docCode);

            new WebBrowser() { DocumentText = fmString, ScriptErrorsSuppressed = false }.DocumentCompleted += Web_DocumentCompleted;
        }

        /// <summary>
        /// 打印卷内备考表
        /// </summary>
        private void PrintBKB(object boxId, object ptId, int boxNumber)
        {
            object docCode = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT pt_code FROM files_tag_info WHERE pt_id='{ptId}'");
            string bkbString = GetBackupTable(boxId, docCode, boxNumber);

            new WebBrowser() { DocumentText = bkbString, ScriptErrorsSuppressed = false }.DocumentCompleted += Web_DocumentCompleted;
        }

        /// <summary>
        /// 打印文档
        /// </summary>
        private void Web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            (sender as WebBrowser).Print();
            (sender as WebBrowser).Dispose();
        }

        /// <summary>
        /// 字体设置|预览
        /// </summary>
        private void View_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = view.Columns[e.ColumnIndex].Name;
            if("font".Equals(columnName))
            {
                object fontObject = view.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;
                if(fontObject != null)
                {
                    Font font = (Font)fontObject;
                    fontDialog.Font = (Font)font;
                }
                if(fontDialog.ShowDialog() == DialogResult.OK)
                {
                    view.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag = fontDialog.Font;
                }
            }
            else if("print".Equals(columnName))
            {
                bool state = (bool)view.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue;
                foreach(DataGridViewCell cell in view.Rows[e.RowIndex].Cells)
                {
                    if(cell is DataGridViewCheckBoxCell)
                    {
                        (cell as DataGridViewCheckBoxCell).Value = state;
                    }
                }
            }
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        private void Preview_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser browser = sender as WebBrowser;
            browser.Parent = parentForm;
            if(browser.ReadyState == WebBrowserReadyState.Complete)
            {
                browser.ShowPrintPreviewDialog();
                browser.Dispose();
            }
        }

        /// <summary>
        /// 获取完整的封面HTML模板页
        /// </summary>
        /// <param name="bj">边距mm数</param>
        private string GetCoverHtmlString(object boxId, string fmString, object bj, object GCNumber, object docCode)
        {
            fmString = fmString.Replace("20mm", $"{bj}").Replace("40mm", $"{bj}");
            if(string.IsNullOrEmpty(GetValue(parentObjectName)))
                fmString = fmString.Replace("id=\"ajmc\">", $"id=\"ajmc\">{objectName}&nbsp;");
            else
            {
                fmString = fmString.Replace("id=\"ajmc\">", $"id=\"ajmc\">{parentObjectName}&nbsp;");
                fmString = fmString.Replace("id=\"ktmc\">", $"id=\"ktmc\">{objectName}&nbsp;");
            }
            fmString = fmString.Replace("id=\"bzdw\">", $"id=\"bzdw\">{unitName}&nbsp;");
            fmString = fmString.Replace("id=\"dh\">", $"id=\"dh\">{docCode}&nbsp;");
            fmString = fmString.Replace("id=\"bzrq\">", $"id=\"bzrq\">{GetDateValue(ljDate, "yyyy-MM-dd")}&nbsp;");
            fmString = fmString.Replace("id=\"bgqx\">", $"id=\"bgqx\">永久");
            fmString = fmString.Replace("id=\"gch\">", $"id=\"gch\">{GCNumber}");
            return fmString;
        }

        private void view_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right && e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                字体设置SToolStripMenuItem.Visible = false;
                脊背设置BToolStripMenuItem.Visible = false;
                string name = view.Columns[e.ColumnIndex].Name;
                if("fm".Equals(name) || "bkb".Equals(name) || "jnml".Equals(name))
                {
                    view.ClearSelection();
                    view.CurrentCell = view.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    contextMenuStrip1.Tag = view;
                    contextMenuStrip1.Show(MousePosition);
                }
                if("fm".Equals(name))
                {
                    字体设置SToolStripMenuItem.Visible = true;
                    脊背设置BToolStripMenuItem.Visible = true;
                }
            }
        }

        private string GetBackupTable(object boxId, object docCode, int boxNumber)
        {
            string bkbString = Resources.bkb;
            string fa = MicrosoftWordHelper.GetZN(GetFilePageCount(boxId, 1));
            string fp = MicrosoftWordHelper.GetZN(GetFilePageCount(boxId, 2));
            string hh = MicrosoftWordHelper.GetZN(boxNumber);

            bkbString = bkbString.Replace("name=\"count\"", $"name=\"count\" value=\"{fa}\"");
            bkbString = bkbString.Replace("name=\"pages\"", $"name=\"pages\" value=\"{fp}\"");
            bkbString = bkbString.Replace("name=\"number\"", $"name=\"number\" value=\"{hh}\"");
            string newTr = string.Empty;
            if(otherDoc.Rows.Count > 0)
                foreach(DataRow row in otherDoc.Rows)
                    newTr += $"<tr><td>{row["od_name"]}</td>" +
                        $"<td>{row["od_code"]}</td>" +
                        $"<td>{row["od_carrier"]}</td>" +
                        $"<td>{row["od_intro"]}</td></tr>";
            else
                newTr = "<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>" +
                    "<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>";
            bkbString = bkbString.Replace("</tbody>", $"{newTr}</tbody>");

            bkbString = bkbString.Replace("id=\"dh\">", $"id=\"dh\">{docCode}");
            bkbString = bkbString.Replace("id=\"ljr\">", $"id=\"dh\">{ljPeople}");
            bkbString = bkbString.Replace("id=\"ljrq\">", $"id=\"dh\">{GetDateValue(ljDate, "yyyy-MM-dd")}");
            bkbString = bkbString.Replace("id=\"jcr\">", $"id=\"jcr\">{jcPeople}");
            bkbString = bkbString.Replace("id=\"jcrq\">", $"id=\"jcrq\">{GetDateValue(jcDate, "yyyy-MM-dd")}");
            return bkbString;
        }

        private string GetFileList(object boxId, object docCode, object GCNumber)
        {
            string jnmlString = Resources.jnml;
            jnmlString = jnmlString.Replace("id=\"ajbh\">", $"id=\"ajbh\">{docCode}");
            jnmlString = jnmlString.Replace("id=\"gch\">", $"id=\"gch\">{GCNumber}");

            DataTable dataTable = new DataTable();
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("fi_code"),
                new DataColumn("fi_user"),
                new DataColumn("fi_name"),
                new DataColumn("fi_pages"),
                new DataColumn("fi_create_date"),
                new DataColumn("fi_remark"),
            });
            DataTable table = SQLiteHelper.ExecuteQuery($"SELECT fi_code, fi_user, fi_name, fi_pages, fi_create_date, fi_remark FROM files_info WHERE fi_box_id='{boxId}' ORDER BY fi_box_sort");
            foreach(DataRow row in table.Rows)
                dataTable.ImportRow(row);
            int fileCount = dataTable.Rows.Count, pageCount = 0;
            int i = 0;
            foreach(DataRow dataRow in dataTable.Rows)
            {
                string newRr = "<tr>" +
                    $"<td>{++i}</td>" +
                    $"<td>{dataRow["fi_code"]}&nbsp;</td>" +
                    $"<td>{dataRow["fi_user"]}&nbsp;</td>" +
                    $"<td style='text-align: left;'>{dataRow["fi_name"]}&nbsp;</td>" +
                    $"<td>{GetDateValue(dataRow["fi_create_date"], "yyyy-MM-dd")}&nbsp;</td>" +
                    $"<td>{dataRow["fi_pages"]}&nbsp;</td>" +
                    $"<td>{dataRow["fi_remark"]}&nbsp;</td>" +
                    $"</tr>";
                jnmlString = jnmlString.Replace("</tbody>", $"{newRr}</tbody>");
                pageCount += GetIntValue(dataRow["fi_pages"]);
            }
            jnmlString = jnmlString.Replace("id=\"fileCount\">", $"id=\"fileCount\">{fileCount}");
            jnmlString = jnmlString.Replace("id=\"pageCount\">", $"id=\"pageCount\">{pageCount}");
            return jnmlString;
        }

        private void 打印预览PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = view.CurrentCell;
            object ptId = cell.OwningRow.Tag;
            object boxId = cell.OwningRow.Cells["print"].Tag;
            object GCNumber = cell.OwningRow.Cells["id"].Tag;
            string HTML_STRING = string.Empty;
            if("fm".Equals(cell.OwningColumn.Name))
            {
                object styleType = cell.OwningRow.Cells["jnml"].Tag;
                int style = GetIntValue(styleType, 0);
                HTML_STRING = style == 0 ? Resources.fm : Resources.fm2;
                object fontObject = cell.OwningRow.Cells["font"].Tag;
                if(fontObject != null)
                {
                    Font font = (Font)fontObject;
                    HTML_STRING = HTML_STRING.Replace("id=\"ajmc\"", $"style=\"font-family:{font.FontFamily.Name}; \" id=\"ajmc\"");
                    HTML_STRING = HTML_STRING.Replace($"style=\"font-family:{font.FontFamily.Name}; \" id=\"ajmc\"", $"style=\"font-family:{font.FontFamily.Name}; font-size:{font.Size}pt; \" id=\"ajmc\"");
                }
                object fontObject2 = cell.OwningRow.Cells["fmbj"].Tag;
                if(fontObject2 != null)
                {
                    Font font = (Font)fontObject2;
                    HTML_STRING = HTML_STRING.Replace("id=\"ktmc\"", $"style=\"font-family:{font.FontFamily.Name}; \" id=\"ktmc\"");
                    HTML_STRING = HTML_STRING.Replace($"style=\"font-family:{font.FontFamily.Name}; \" id=\"ktmc\"", $"style=\"font-family:{font.FontFamily.Name}; font-size:{font.Size}pt; \" id=\"ktmc\"");
                }
                object bj = cell.OwningRow.Cells["fmbj"].Value;
                object docCode = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT pt_code FROM files_tag_info WHERE pt_id='{ptId}'");
                HTML_STRING = GetCoverHtmlString(boxId, HTML_STRING, bj, GCNumber, docCode);
            }
            else if("bkb".Equals(cell.OwningColumn.Name))
            {
                object docCode = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT pt_code FROM files_tag_info WHERE pt_id='{ptId}'");
                object boxNumber = cell.OwningRow.Cells["id"].Value;
                HTML_STRING = GetBackupTable(boxId, docCode, GetIntValue(boxNumber, 1));
            }
            else if("jnml".Equals(cell.OwningColumn.Name))
            {
                object docCode = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT pt_code FROM files_tag_info WHERE pt_id='{ptId}'");
                HTML_STRING = GetFileList(boxId, docCode, GCNumber);
            }
            new WebBrowser() { DocumentText = HTML_STRING, Size = new Size(500, 500) }.DocumentCompleted += Preview_DocumentCompleted;
        }

        /// <summary>
        /// 将对象转换成其整型
        /// </summary>
        /// <param name="value">object对象</param>
        /// <param name="defaultValue">转换失败时的默认值</param>
        public int GetIntValue(object value, int defaultValue)
        {
            string str = GetValue(value);
            if(!string.IsNullOrEmpty(str))
            {
                if(int.TryParse(str, out int result))
                    return result;
                else
                    return defaultValue;
            }
            return defaultValue;
        }

        private void 案卷名称ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = view.CurrentCell;

            object fontObject = cell.OwningRow.Cells["font"].Tag;
            if(fontObject != null)
            {
                Font font = (Font)fontObject;
                fontDialog.Font = (Font)font;
            }
            if(fontDialog.ShowDialog() == DialogResult.OK)
            {
                cell.OwningRow.Cells["font"].Tag = fontDialog.Font;
            }
        }

        private void 课题名称ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewCell cell = view.CurrentCell;

            object fontObject = cell.OwningRow.Cells["fmbj"].Tag;
            if(fontObject != null)
            {
                Font font = (Font)fontObject;
                fontDialog.Font = (Font)font;
            }
            if(fontDialog.ShowDialog() == DialogResult.OK)
            {
                cell.OwningRow.Cells["fmbj"].Tag = fontDialog.Font;
            }
        }

        private void toolStripComboBox1_DropDownClosed(object sender, EventArgs e)
        {
            ToolStripComboBox comboBox = sender as ToolStripComboBox;
            DataGridViewCell cell = view.CurrentCell;
            cell.OwningRow.Cells["jnml"].Tag = comboBox.SelectedIndex;
            contextMenuStrip1.Hide();
        }
    }
}
