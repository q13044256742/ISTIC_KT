﻿using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_Print : Form
    {
        /// <summary>
        /// 项目/课题ID
        /// </summary>
        private object objId;
        /// <summary>
        /// 项目/课题名称
        /// </summary>
        private string objName;
        /// <summary>
        /// 盒号ID
        /// </summary>
        private object boxId;
        /// <summary>
        /// 档号
        /// </summary>
        private object docNumber;
        /// <summary>
        /// 馆藏号
        /// </summary>
        private string gcCode;

        public Frm_Print(object objId, object boxId, object docNumber, string objName, string gcCode)
        {
            InitializeComponent();
            this.objId = objId;
            this.boxId = boxId;
            this.docNumber = docNumber;
            this.objName = objName;
            this.gcCode = gcCode;
        }

        private string GetValue(object value) => value == null ? string.Empty : value.ToString();

        private void lbl_BKB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            object _fileAmount = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT pb_files_id FROM files_box_info WHERE pb_id='{boxId}'");
            string[] _files = GetValue(_fileAmount).Split(',');
            int fileAmount = 0;
            int filePages = 0;
            for(int i = 0; i < _files.Length; i++)
            {
                if(!string.IsNullOrEmpty(_files[i]))
                {
                    fileAmount++;
                    object _page = SQLiteHelper.ExecuteOnlyOneQuery($"SELECT fi_pages FROM files_info WHERE fi_id='{_files[i]}'");
                    if(!string.IsNullOrEmpty(GetValue(_page)))
                        filePages += Convert.ToInt32(_page);
                }
            }
            Frm_FileBackUpTable table = new Frm_FileBackUpTable()
            {
                fileAmount = fileAmount,
                filePages = filePages,
                docNumber = docNumber,
                user = UserHelper.GetUser().RealName
            };
            table.Show();
        }

        private void lbl_FM_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frm_Cover cover = new Frm_Cover()
            {
                objectName = objName,
                unitName = UserHelper.GetUser().UserUnitName,
                bzDate = DateTime.Now.ToString("yyyy-MM-dd"),
                bgDate = DateTime.Now.ToString("yyyy-MM-dd"),
                gcCode = gcCode
            };
            cover.Show();
        }

        private void lbl_WJ_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string files = GetValue(SQLiteHelper.ExecuteOnlyOneQuery($"SELECT pb_files_id FROM files_box_info WHERE pb_id='{boxId}'"));
            string[] fids = files.Split(',');
            DataTable table = new DataTable();
            table.Columns.AddRange(new DataColumn[]
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
                        table.ImportRow(row);
                }
            }
            Frm_BoxList boxList = new Frm_BoxList()
            {
                proCode = GetValue(docNumber),
                code = GetValue(docNumber),
                name = objName,
                gcCode = gcCode,
                dataTable = table
            };
            boxList.Show();
        }
    }
}
