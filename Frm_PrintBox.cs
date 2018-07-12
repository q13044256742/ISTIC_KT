﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 数据采集档案管理系统___课题版.Properties;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_PrintBox : Form
    {
        /// <summary>
        /// 文件总份数
        /// </summary>
        public int fileAmount;
        /// <summary>
        /// 文件总页数
        /// </summary>
        public int filePages;
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
        /// 编制日期
        /// </summary>
        public string bzDate;
        /// <summary>
        /// 保管日期
        /// </summary>
        public string bgDate;
        /// <summary>
        /// 密级
        /// </summary>
        public string secret;
        /// <summary>
        /// 馆藏号
        /// </summary>
        public string gcCode;
        /// <summary>
        /// 项目编号
        /// </summary>
        public string proCode;
        /// <summary>
        /// 项目名称
        /// </summary>
        public string proName;
        /// <summary>
        /// 盒列表
        /// </summary>
        public DataTable boxTable;
        public Frm_PrintBox()
        {
            InitializeComponent();
            InitialFrom();
        }

        private void InitialFrom()
        {
            view.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", 12, FontStyle.Bold);
            cbo_BJ.SelectedIndex = 0;
        }

        private void Frm_PrintBox_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < boxTable.Rows.Count; i++)
            {
                int index = view.Rows.Add();
                view.Rows[index].Cells["print"].Tag = boxTable.Rows[i]["pb_id"];
                view.Rows[index].Cells["id"].Value = boxTable.Rows[i]["pb_box_number"];
                view.Rows[index].Cells["fmbj"].Value = "20mm";
            }
        }

        private void Chk_PrintAll_CheckedChanged(object sender, EventArgs e)
        {
            bool flag = chk_PrintAll.Checked;
            foreach(DataGridViewRow row in view.Rows)
            {
                row.Cells["print"].Value = flag;
            }
        }

        private void Chk_BKB_CheckedChanged(object sender, EventArgs e)
        {
            bool flag = chk_BKB.Checked;
            foreach(DataGridViewRow row in view.Rows)
            {
                row.Cells["bkb"].Value = flag;
            }
        }

        private void Chk_JNML_CheckedChanged(object sender, EventArgs e)
        {
            bool flag = chk_JNML.Checked;
            foreach(DataGridViewRow row in view.Rows)
            {
                row.Cells["jnml"].Value = flag;
            }
        }

        private void Chk_FMBJ_CheckedChanged(object sender, EventArgs e)
        {
            bool flag = chk_FMBJ.Checked;
            foreach(DataGridViewRow row in view.Rows)
            {
                row.Cells["fm"].Value = flag;
                row.Cells["fmbj"].Value = flag ? cbo_BJ.SelectedItem : "20mm";
            }
        }

        private void Cbo_BJ_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool flag = chk_FMBJ.Checked;
            if(flag)
            {
                foreach(DataGridViewRow row in view.Rows)
                {
                    row.Cells["fmbj"].Value = cbo_BJ.SelectedItem;
                }
            }
        }

        private void Btn_StartPrint_Click(object sender, EventArgs e)
        {
            List<object> boxIds = new List<object>();
            foreach(DataGridViewRow row in view.Rows)
            {
                if(true.Equals(row.Cells["print"].Value))
                {
                    boxIds.Add(row.Cells["print"].Tag);
                }
            }
            if(boxIds.Count > 0)
            {
                PrintDocument(boxIds.ToArray());
            }
            else
                MessageBox.Show("请先至少选择一盒进行打印。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void PrintDocument(object[] ids)
        {
            foreach(object id in ids)
            {
                foreach(DataGridViewRow row in view.Rows)
                {
                    if(id.Equals(row.Cells["print"].Tag))
                    {
                        bool printBkb = GetBooleanValue(row.Cells["bkb"].Value);
                        if(printBkb)
                        {
                            SetCurrentState(row.Cells["id"].Value, "备考表");
                            PrintBKB(id);
                        }
                        bool printFm = GetBooleanValue(row.Cells["fm"].Value);
                        if(printFm)
                        {
                            SetCurrentState(row.Cells["id"].Value, "封面&脊背");
                            object bj = row.Cells["fmbj"].Value;
                            PrintFM(id, bj);
                        }
                        bool printJnml = GetBooleanValue(row.Cells["jnml"].Value);
                        if(printJnml)
                        {
                            SetCurrentState(row.Cells["id"].Value, "卷内文件目录");
                            PrintJNML(id);
                        }
                    }
                }
                tip.Text = "提示：打印完毕。";
            }
        }

        private bool GetBooleanValue(object value)
        {
            return value == null ? false : string.IsNullOrEmpty(value.ToString()) ? false : (bool)value;
        }

        private void SetCurrentState(object value, string type)
        {
            tip.Text = $"提示：正在打印盒{value}{type}";
        }

        /// <summary>
        /// 打印卷内文件目录
        /// </summary>
        private void PrintJNML(object boxId)
        {
            string jnmlString = Resources.jnml;

            jnmlString = jnmlString.Replace("id=\"xmmc\">", $"id=\"xmmc\">{proName}");
            jnmlString = jnmlString.Replace("id=\"xmbh\">", $"id=\"xmbh\">{proCode}");
            jnmlString = jnmlString.Replace("id=\"ajbh\">", $"id=\"ajbh\">{objectCode}");
            jnmlString = jnmlString.Replace("id=\"gch\">", $"id=\"gch\">{gcCode}");

            string files = GetValue(SQLiteHelper.ExecuteOnlyOneQuery($"SELECT pb_files_id FROM files_box_info WHERE pb_id='{boxId}'"));
            string[] fids = files.Split(',');
            DataTable dataTable = new DataTable();
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("fi_code"),
                new DataColumn("fi_name"),
                new DataColumn("fi_pages"),
                new DataColumn("fi_count"),
                new DataColumn("fi_remark"),
            });
            for(int i = 0; i < fids.Length; i++)
            {
                if(!string.IsNullOrEmpty(fids[i]))
                {
                    DataRow row = SQLiteHelper.ExecuteSingleRowQuery($"SELECT fi_code, fi_name, fi_pages, fi_count, fi_remark FROM files_info WHERE fi_id='{fids[i]}'");
                    if(row != null)
                        dataTable.ImportRow(row);
                }
            }
            if(dataTable != null)
            {
                for(int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string newRr = "<tr>" +
                        $"<td>{i + 1}</td>" +
                        $"<td>{dataTable.Rows[i]["fi_code"]}</td>" +
                        $"<td>{dataTable.Rows[i]["fi_name"]}</td>" +
                        $"<td>{dataTable.Rows[i]["fi_pages"]}</td>" +
                        $"<td>{dataTable.Rows[i]["fi_count"]}</td>" +
                        $"<td>{dataTable.Rows[i]["fi_remark"]}</td>" +
                        $"</tr>";
                    jnmlString = jnmlString.Replace("</tbody>", $"{newRr}</tbody>");
                }
            }
            web.DocumentText = jnmlString.ToString();
        }

        private string GetValue(object value) => value == null ? string.Empty : value.ToString();

        /// <summary>
        /// 打印封面
        /// </summary>
        private void PrintFM(object id, object bj)
        {
            string fmString = Resources.fm;
            fmString = fmString.Replace("20mm", $"{bj}");
            fmString = fmString.Replace("id=\"ajmc\"", $"id=\"ajmc\" value=\"{objectName}\"");
            fmString = fmString.Replace("id=\"bzdw\"", $"id=\"bzdw\" value=\"{unitName}\"");
            fmString = fmString.Replace("id=\"bzrq\"", $"id=\"bzrq\" value=\"{bzDate}\"");
            fmString = fmString.Replace("id=\"bgrq\"", $"id=\"bgrq\" value=\"{bgDate}\"");
            fmString = fmString.Replace("id=\"mj\"", $"id=\"mj\" value=\"{secret}\"");
            fmString = fmString.Replace("id=\"gch\">", $"id=\"dh\">{gcCode}");
            web.DocumentText = fmString.ToString();
        }
        /// <summary>
        /// 打印卷内备考表
        /// </summary>
        private void PrintBKB(object id)
        {
            StringBuilder bkbString = new StringBuilder(Resources.bkb);
            string fa = MicrosoftWordHelper.GetZN(fileAmount);
            string fp = MicrosoftWordHelper.GetZN(filePages);

            bkbString = bkbString.Replace("name=\"count\"", $"name=\"count\" value=\"{fa}\"");
            bkbString = bkbString.Replace("name=\"pages\"", $"name=\"pages\" value=\"{fp}\"");
            bkbString = bkbString.Replace("id=\"dh\">", $"id=\"dh\">{objectCode}");
            bkbString = bkbString.Replace("id=\"ljr\">", $"id=\"dh\">{UserHelper.GetUser().RealName}");
            bkbString = bkbString.Replace("id=\"ljrq\">", $"id=\"dh\">{DateTime.Now.ToString("yyyy 年 MM 月 dd 日")}");
            web.DocumentText = bkbString.ToString();
        }

        private void Web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            web.ShowPrintPreviewDialog();
        }
    }
}
