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

            dgv_DataList.Rows.Clear();
            int paperHeight = 800;// printDocument1.PrinterSettings.DefaultPageSettings.PaperSize.Height;
            DataGridView view = dgv_DataList;
            int totalHeight = view.ColumnHeadersHeight;
            int totalTop = view.Top;
            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                int index = view.Rows.Add();
                view.Rows[index].Cells["fb_id"].Value = i + 1;
                view.Rows[index].Cells["fb_code"].Value = dataTable.Rows[i]["fi_code"];
                view.Rows[index].Cells["fb_name"].Value = dataTable.Rows[i]["fi_name"];
                view.Rows[index].Cells["fb_page"].Value = dataTable.Rows[i]["fi_pages"];
                view.Rows[index].Cells["fb_count"].Value = dataTable.Rows[i]["fi_count"];
                view.Rows[index].Cells["fb_remark"].Value = dataTable.Rows[i]["fi_remark"];
                totalHeight += view.Rows[index].Height;
                view.Height = totalHeight;
                if(totalHeight + totalTop >= paperHeight)
                {
                    if(view == dgv_DataList)
                        pal_Show.Height = view.Top + totalHeight;

                    int newViewTop = totalHeight + totalTop + 5;
                    view = GetNewDataGridView(newViewTop);
                    view.Top = newViewTop;
                    view.Left = pal_Show.Left + dgv_DataList.Left;
                    totalHeight = view.ColumnHeadersHeight;
                    totalTop = 0;
                }

            }
            //dgv_DataList.Height = dgv_DataList.ColumnHeadersHeight + totalHeight + 2;
            //pal_Show.Height = dgv_DataList.Top + dgv_DataList.Height;

        }

        private DataGridView GetNewDataGridView(int top)
        {
            DataGridView view = new DataGridView();
            view.Width = dgv_DataList.Width;
            foreach(DataGridViewColumn item in dgv_DataList.Columns)
            {
                view.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    Name = item.Name,
                    HeaderText = item.HeaderText,
                    FillWeight = item.FillWeight,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                });
            }
            view.ColumnHeadersDefaultCellStyle = dgv_DataList.ColumnHeadersDefaultCellStyle;
            view.BorderStyle = BorderStyle.None;
            view.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            view.DefaultCellStyle = dgv_DataList.DefaultCellStyle;
            view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            view.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            view.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            view.BackgroundColor = Color.White;
            view.RowHeadersVisible = false;
            view.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            view.Font = dgv_DataList.Font;
            view.GridColor = Color.Black;
            view.AllowUserToAddRows = false;
            view.AllowUserToDeleteRows = false;
            view.AllowUserToResizeColumns = false;
            view.AllowUserToResizeRows = false;
            view.ReadOnly = true;
            view.MultiSelect = false;
            view.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            view.EnableHeadersVisualStyles = false;
            view.DefaultCellStyle.Padding = new Padding(1, 2, 1, 2);
            pal_All.Controls.Add(view);
            return view;
        }

        private string GetValue(object value) => value == null ? string.Empty : value.ToString();

        private void btn_PrintSetup_Click(object sender, EventArgs e)
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

        /// <summary>
        /// 默认打印图像实例
        /// </summary>
        private Bitmap bitMap;

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if(bitMap != null)
            {
                e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                int left = (e.PageBounds.Width - bitMap.Width) / 16 * 3 - 5;
                e.Graphics.DrawImage(bitMap, left, 0);
            }
        }

        private void Btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                printDocument.DocumentName = lbl_Name.Text;
                foreach(Control item in pal_All.Controls)
                {
                    if(item is Panel)
                    {
                        bitMap = new Bitmap(item.Width, item.Height, PixelFormat.Format32bppArgb);
                        Graphics.FromImage(bitMap).Clear(Color.White);
                        item.DrawToBitmap(bitMap, new Rectangle(new Point(0, 0), bitMap.Size));
                        printDocument.Print();
                    }
                    else if(item is DataGridView)
                    {
                        DataGridView view = item as DataGridView;
                        dgv_DataList.ClearSelection();
                        bitMap = new Bitmap(item.Width, item.Height, PixelFormat.Format32bppArgb);
                        Graphics.FromImage(bitMap).Clear(Color.White);
                        item.DrawToBitmap(bitMap, new Rectangle(new Point(0, 0), bitMap.Size));
                        printDocument.Print();
                    }
                    bitMap = null;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
