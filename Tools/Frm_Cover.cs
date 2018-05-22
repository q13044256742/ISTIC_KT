using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_Cover : Form
    {
        /// <summary>
        /// 案卷名称
        /// </summary>
        public string objectName;
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
        public Frm_Cover()
        {
            InitializeComponent();
        }

        private void Frm_Cover_Load(object sender, System.EventArgs e)
        {
            lbl_Name.Text = objectName;
            lbl_Unit.Text = unitName;
            lbl_BZD.Text = bzDate;
            lbl_BGD.Text = bgDate;
            lbl_GCH.Text = gcCode;
            lbl_Secret.Text = secret;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(pal_Show.Width, pal_Show.Height, PixelFormat.Format24bppRgb);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            pal_Show.DrawToBitmap(bitmap, new Rectangle(new Point(0, 0), bitmap.Size));

            e.Graphics.DrawImage(bitmap, 0f, 0f);
        }

        private void btn_Print_Click(object sender, System.EventArgs e)
        {
            try
            {
                if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_PrintSetup_Click(object sender, System.EventArgs e)
        {
            try
            {
                pageSetupDialog1.ShowDialog();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
