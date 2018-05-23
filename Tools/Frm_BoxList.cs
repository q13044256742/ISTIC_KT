using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    public partial class Frm_BoxList : Form
    {
        public string proCode;
        public string name;
        public string code;
        public string gcCode;
        public DataTable dataTable;
        public Frm_BoxList()
        {
            InitializeComponent();
        }

        private void Frm_BoxList_Load(object sender, System.EventArgs e)
        {
            lbl_proCode.Text = proCode;
            lbl_Name.Text = name;
            lbl_Code.Text = code;
            lbl_GC.Text = gcCode;

            lsv_DataList.Clear();
            lsv_DataList.Columns.AddRange(new ColumnHeader[]
            {
                    new ColumnHeader{ Name = "id", Text="序号", Width = 50, TextAlign = HorizontalAlignment.Center},
                    new ColumnHeader{ Name = "code", Text="文件编号", Width = 100},
                    new ColumnHeader{ Name = "name", Text = "文件名称", Width = 280},
                    new ColumnHeader{ Name = "pages", Text = "页数", Width = 60, TextAlign = HorizontalAlignment.Center},
                    new ColumnHeader{ Name = "count", Text = "份数", Width = 60, TextAlign = HorizontalAlignment.Center},
                    new ColumnHeader{ Name = "remark", Text = "备注", Width = 120}
            });
            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                ListViewItem item = lsv_DataList.Items.Add((i + 1).ToString().PadLeft(2, '0'));
                item.SubItems.AddRange(new ListViewItem.ListViewSubItem[]
                {
                    new ListViewItem.ListViewSubItem(){ Text = GetValue(dataTable.Rows[i]["fi_code"]) },
                    new ListViewItem.ListViewSubItem(){ Text = GetValue(dataTable.Rows[i]["fi_name"]) },
                    new ListViewItem.ListViewSubItem(){ Text = GetValue(dataTable.Rows[i]["fi_pages"]) },
                    new ListViewItem.ListViewSubItem(){ Text = GetValue(dataTable.Rows[i]["fi_count"]) },
                    new ListViewItem.ListViewSubItem(){ Text = GetValue(dataTable.Rows[i]["fi_remark"]) }
                });
            }
        }
        private string GetValue(object value) => value == null ? string.Empty : value.ToString();

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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(pal_Show.Width, pal_Show.Height, PixelFormat.Format24bppRgb);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            pal_Show.DrawToBitmap(bitmap, new Rectangle(new Point(0, 0), bitmap.Size));

            e.Graphics.DrawImage(bitmap, 0f, 0f);
        }

        private void btn_Print_Click(object sender, EventArgs e)
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
    }
}
