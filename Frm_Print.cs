using System;
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

        private void Frm_Print_Load(object sender, EventArgs e)
        {
        }


        private string GetValue(object value) => value == null ? string.Empty : value.ToString();

        private void lbl_BKB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //string _filePath = Application.StartupPath + "\\PRINT_FOLDER_TEMP\\";
            //if(!Directory.Exists(_filePath))
            //    Directory.CreateDirectory(_filePath);
            //string filePath = _filePath + "卷内备考表.doc";
            //if(!File.Exists(filePath))
            //    File.Create(filePath).Close();
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
            table.ShowDialog();
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
            cover.ShowDialog();
        }
    }
}
