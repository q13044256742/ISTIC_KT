using Microsoft.Office.Interop.Word;
using System;
using System.Data;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    class MicrosoftWordExportHelper
    {
        /// <summary>
        /// 档案清单
        /// </summary>
        /// <param name="filePath">Word 所在路径</param>
        /// <param name="table">所需写入的内容</param>
        public static bool WriteDocumentList(string filePath, System.Data.DataTable tableList, object SpeName, object SpeCode, object parentId)
        {
            Microsoft.Office.Interop.Word.Application app = null;
            Document doc = null;
            try
            {
                int rows = tableList.Rows.Count + 2;//表格行数加1是为了标题栏
                int cols = 8;//表格列数
                object oMissing = Missing.Value;
                app = new Microsoft.Office.Interop.Word.Application();//创建word应用程序
                doc = app.Documents.Add();//添加一个word文档

                app.Selection.PageSetup.LeftMargin = 50f;
                app.Selection.PageSetup.RightMargin = 50f;
                app.Selection.PageSetup.PageWidth = 800f;  //页面宽度

                //标题
                app.Selection.Font.Bold = 700;
                app.Selection.Font.Size = 18;
                app.Selection.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                app.Selection.Text = "重大专项项目（课题）档案清单";

                //子标题
                object subLine = WdUnits.wdLine;
                app.Selection.MoveDown(ref subLine, oMissing, oMissing);
                app.Selection.TypeParagraph();//换行
                app.Selection.Font.Bold = 0;
                app.Selection.Font.Size = 12;
                app.Selection.Text = $"项目（课题）名称：{SpeName}\t\t项目（课题）编号：{SpeCode}";

                //换行添加表格
                object line = WdUnits.wdLine;
                app.Selection.MoveDown(ref line, oMissing, oMissing);
                app.Selection.TypeParagraph();//换行
                app.Selection.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                Range range = app.Selection.Range;
                Table table = app.Selection.Tables.Add(range, rows, cols, ref oMissing, ref oMissing);
                //设置表格的字体大小粗细
                table.Range.Font.Size = 11;
                table.Range.Font.Bold = 0;
                table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
                table.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;

                //设置表格标题
                int rowIndex = 1;
                table.Rows[rowIndex].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                table.Rows[rowIndex].Range.Font.Bold = 100;
                table.Rows[rowIndex].Height = 30f;
                table.Cell(rowIndex, 1).Range.Text = "序号";
                table.Cell(rowIndex, 2).Range.Text = "档号";
                table.Cell(rowIndex, 3).Range.Text = "重大专项项目（课题）档案材料名称";
                table.Cell(rowIndex, 4).Range.Text = "文件号";
                table.Cell(rowIndex, 5).Range.Text = "盒号";
                table.Cell(rowIndex, 6).Range.Text = "载体类型";
                table.Cell(rowIndex, 7).Range.Text = "页数";
                table.Cell(rowIndex, 8).Range.Text = "备注";

                table.Columns[1].Width = 45f;
                table.Columns[2].Width = 150f;
                table.Columns[3].Width = 240f;
                table.Columns[4].Width = 50f;
                table.Columns[5].Width = 50f;
                table.Columns[6].Width = 50f;
                table.Columns[7].Width = 45f;

                int rowCount = tableList.Rows.Count;
                int totalPage = 0;
                //循环数据创建数据行
                for(int i = 0; i < rowCount; i++)
                {
                    rowIndex++;
                    DataRow row = tableList.Rows[i];
                    table.Cell(rowIndex, 1).Range.Text = GetValue(i + 1).PadLeft(2, '0');
                    table.Cell(rowIndex, 2).Range.Text = GetValue(SpeCode);
                    table.Cell(rowIndex, 3).Range.Text = GetValue(row["name"]);
                    table.Cell(rowIndex, 4).Range.Text = GetValue(row["categor"]);
                    table.Cell(rowIndex, 5).Range.Text = GetBoxNumber(row["fi_id"], parentId);
                    table.Cell(rowIndex, 6).Range.Text = GetValue(row["carrier"]);
                    table.Cell(rowIndex, 8).Range.Text = GetValue(row["remark"]);
                    string _page = GetValue(row["pages"]);
                    if(!string.IsNullOrEmpty(_page))
                    {
                        table.Cell(rowIndex, 7).Range.Text = _page;
                        totalPage += Convert.ToInt32(_page);
                    }
                }

                rowIndex++;
                table.Rows[rowIndex].Height = 40f;
                table.Rows[rowIndex].Cells[1].VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                table.Rows[rowIndex].Cells[2].VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                table.Cell(rowIndex, 1).Range.Text = "合计";
                table.Cell(rowIndex, 2).Merge(table.Cell(rowIndex, 6));
                table.Cell(rowIndex, 2).Range.Text = $"共 {rowCount} 份文件。";
                table.Cell(rowIndex, 3).Range.Text = $"{totalPage}";

                app.Selection.EndKey(WdUnits.wdStory, oMissing); //将光标移动到文档末尾
                app.Selection.Font.Bold = 0;
                app.Selection.Font.Size = 11;

                //底部署名
                doc.Content.InsertAfter("\n移交单位（盖章）：                                        接收单位（盖章）：\n");
                doc.Content.InsertAfter("移交人：                                                 接收人：\n");
                doc.Content.InsertAfter("交接时间：    年  月  日");
                doc.Content.InsertAfter("\r\n\n说明：1. 本表填写到文件级，针对一个项目（课题）内的具体文件，一份文件为一行。" +
                    "\n      2.未移交档案请在备注中说明原因。");

                //导出到文件
                doc.SaveAs(filePath,
                    oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                    oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                try
                {
                    if(doc != null)
                        doc.Close();//关闭文档
                    if(app != null)
                        app.Quit();//退出应用程序
                }
                catch(Exception exo) { MessageBox.Show(exo.Message); }
            }
        }

        /// <summary>
        /// 根据文件ID获取其所在盒号
        /// </summary>
        private static string GetBoxNumber(object id, object pid)
        {
            System.Collections.Generic.List<object[]> boxIds = SQLiteHelper.ExecuteColumnsQuery($"SELECT pb_box_number, pb_files_id FROM files_box_info WHERE pb_obj_id='{pid}'", 2);
            foreach(object[] item in boxIds)
            {
                string value = GetValue(item[1]).Trim();
                if(!string.IsNullOrEmpty(value))
                {
                    string[] files = value.Split(',');
                    foreach(string file in files)
                        if(id.Equals(file))
                            return GetValue(item[0]);
                }
            }
            return string.Empty;
        }

        public static bool WriteLostDocumentList(string filePath, System.Data.DataTable tableList, object speName, object speCode, object parentId)
        {
            Microsoft.Office.Interop.Word.Application app = null;
            Document doc = null;
            try
            {
                int rows = tableList.Rows.Count + 2;//表格行数加1是为了标题栏
                int cols = 5;//表格列数
                object oMissing = Missing.Value;
                app = new Microsoft.Office.Interop.Word.Application();//创建word应用程序
                doc = app.Documents.Add();//添加一个word文档

                app.Selection.PageSetup.LeftMargin = 50f;
                app.Selection.PageSetup.RightMargin = 50f;
                app.Selection.PageSetup.PageWidth = 800f;  //页面宽度

                //标题
                app.Selection.Font.Bold = 700;
                app.Selection.Font.Size = 18;
                app.Selection.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                app.Selection.Text = "重大专项项目（课题）档案缺失清单";

                //子标题
                object subLine = WdUnits.wdLine;
                app.Selection.MoveDown(ref subLine, oMissing, oMissing);
                app.Selection.TypeParagraph();//换行
                app.Selection.Font.Bold = 0;
                app.Selection.Font.Size = 12;
                app.Selection.Text = $"项目（课题）名称：{speName}\t\t项目（课题）编号：{speCode}";

                //换行添加表格
                object line = WdUnits.wdLine;
                app.Selection.MoveDown(ref line, oMissing, oMissing);
                app.Selection.TypeParagraph();//换行
                app.Selection.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                Range range = app.Selection.Range;
                Table table = app.Selection.Tables.Add(range, rows, cols, ref oMissing, ref oMissing);
                //设置表格的字体大小粗细
                table.Range.Font.Size = 11;
                table.Range.Font.Bold = 0;
                table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
                table.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;

                //设置表格标题
                int rowIndex = 1;
                table.Rows[rowIndex].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                table.Rows[rowIndex].Range.Font.Bold = 100;
                table.Rows[rowIndex].Height = 30f;
                table.Cell(rowIndex, 1).Range.Text = "序号";
                table.Cell(rowIndex, 2).Range.Text = "文件类别";
                table.Cell(rowIndex, 3).Range.Text = "缺失文件名称";
                table.Cell(rowIndex, 4).Range.Text = "备注";

                table.Columns[1].Width = 45f;
                table.Columns[2].Width = 100f;
                table.Columns[3].Width = 250f;
                table.Columns[4].Width = 300f;

                int rowCount = tableList.Rows.Count;
                //循环数据创建数据行
                for(int i = 0; i < rowCount; i++)
                {
                    rowIndex++;
                    DataRow row = tableList.Rows[i];
                    table.Cell(rowIndex, 1).Range.Text = GetValue(i + 1).PadLeft(2, '0');
                    table.Cell(rowIndex, 2).Range.Text = GetValue(row["dd_name"]);
                    table.Cell(rowIndex, 3).Range.Text = GetValue(row["dd_note"]);
                    string queryReasonSql = $"SELECT pfo_remark FROM files_lost_info WHERE pfo_obj_id='{parentId}' AND pfo_categor LIKE '{row["name"]}%'";
                    DataRow _row = SQLiteHelper.ExecuteSingleRowQuery(queryReasonSql);
                    if(_row != null)
                    {
                        table.Cell(rowIndex, 4).Range.Text = GetValue(_row["pfo_remark"]);
                    }
                }

                rowIndex++;
                table.Rows[rowIndex].Height = 40f;
                table.Rows[rowIndex].Cells[1].VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                table.Rows[rowIndex].Cells[2].VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                table.Cell(rowIndex, 1).Range.Text = "合计";
                table.Cell(rowIndex, 2).Merge(table.Cell(rowIndex, 4));
                table.Cell(rowIndex, 2).Range.Text = $"共 {rowCount} 份文件。";

                //导出到文件
                doc.SaveAs(filePath,
                    oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                    oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                try
                {
                    if(doc != null)
                        doc.Close();//关闭文档
                    if(app != null)
                        app.Quit();//退出应用程序
                }
                catch(Exception exo) { MessageBox.Show(exo.Message); }
            }
        }

        /// <summary>
        /// 汇总表
        /// </summary>
        /// <param name="filePath">Word 所在路径</param>
        /// <param name="table">所需写入的内容</param>
        public static bool WriteTotalTable(string filePath, System.Data.DataTable tableList, object SpeName)
        {
            Microsoft.Office.Interop.Word.Application app = null;
            Document doc = null;
            try
            {
                int rows = tableList.Rows.Count + 1;//表格行数加1是为了标题栏
                int cols = 6;//表格列数
                object oMissing = Missing.Value;
                app = new Microsoft.Office.Interop.Word.Application();//创建word应用程序
                doc = app.Documents.Add();//添加一个word文档

                app.Selection.PageSetup.LeftMargin = 50f;
                app.Selection.PageSetup.RightMargin = 50f;
                app.Selection.PageSetup.PageWidth = 800f;  //页面宽度

                //标题
                app.Selection.Font.Bold = 700;
                app.Selection.Font.Size = 18;
                app.Selection.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                app.Selection.Text = "重大专项项目（课题）档案汇总表";

                //子标题
                object subLine = WdUnits.wdLine;
                app.Selection.MoveDown(ref subLine, oMissing, oMissing);
                app.Selection.TypeParagraph();//换行
                app.Selection.Font.Bold = 0;
                app.Selection.Font.Size = 12;
                app.Selection.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                app.Selection.Text = $"重大专项项目（课题）名称：{SpeName}";

                //换行添加表格
                object line = WdUnits.wdLine;
                app.Selection.MoveDown(ref line, oMissing, oMissing);
                app.Selection.TypeParagraph();//换行
                app.Selection.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                Range range = app.Selection.Range;
                Table table = app.Selection.Tables.Add(range, rows, cols, ref oMissing, ref oMissing);
                //设置表格的字体大小粗细
                table.Range.Font.Size = 11;
                table.Range.Font.Bold = 0;
                table.Borders.OutsideLineStyle = WdLineStyle.wdLineStyleSingle;
                table.Borders.InsideLineStyle = WdLineStyle.wdLineStyleSingle;

                //设置表格标题
                int rowIndex = 1;
                table.Rows[rowIndex].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                table.Rows[rowIndex].Range.Font.Bold = 100;
                table.Rows[rowIndex].Height = 30f;
                table.Cell(rowIndex, 1).Range.Text = "序号";
                table.Cell(rowIndex, 2).Range.Text = "档号/项目（课题）编号";
                table.Cell(rowIndex, 3).Range.Text = "重大专项档案材料名称/项目（课题）名称";
                table.Cell(rowIndex, 4).Range.Text = "负责人";
                table.Cell(rowIndex, 5).Range.Text = "件数";
                table.Cell(rowIndex, 6).Range.Text = "备注";

                table.Columns[1].Width = 45f;
                table.Columns[2].Width = 150f;
                table.Columns[3].Width = 220f;
                table.Columns[5].Width = 50f;
                table.Columns[6].Width = 60f;

                int rowCount = tableList.Rows.Count;
                //循环数据创建数据行
                for(int i = 0; i < rowCount; i++)
                {
                    rowIndex++;
                    DataRow row = tableList.Rows[i];
                    table.Cell(rowIndex, 1).Range.Text = GetValue(i + 1).PadLeft(2, '0');
                    table.Cell(rowIndex, 2).Range.Text = GetValue(row["code"]);
                    table.Cell(rowIndex, 3).Range.Text = GetValue(row["name"]);
                    table.Cell(rowIndex, 4).Range.Text = GetValue(row["user"]);
                    table.Cell(rowIndex, 5).Range.Text = GetValue(row["count"]);
                }

                app.Selection.EndKey(WdUnits.wdStory, oMissing); //将光标移动到文档末尾
                app.Selection.Font.Bold = 0;
                app.Selection.Font.Size = 11;

                //底部署名
                doc.Content.InsertAfter("\n移交单位（盖章）：                                        接收单位（盖章）：\n");
                doc.Content.InsertAfter("移交人：                                                 接收人：\n");
                doc.Content.InsertAfter("交接时间：    年  月  日");
                doc.Content.InsertAfter("\r\n\n说明：1. 此表针对下设多个课题（子课题）的项目（课题），由项目（课题）承担单位填写，如没有下设课题（子课题），则不填写。" +
                    "\n      2.本表填写到课题级（子课题级），一行为一课题（子课题）。");

                //导出到文件
                doc.SaveAs(filePath,
                    oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                    oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                try
                {
                    if(doc != null)
                        doc.Close();//关闭文档
                    if(app != null)
                        app.Quit();//退出应用程序
                }
                catch(Exception) { }
            }
        }

        private static string GetBlank(int num)
        {
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < num; i++)
                sb.Append(" ");
            return sb.ToString();
        }

        private static string GetValue(object v) => v == null ? string.Empty : v.ToString();
    }
}
