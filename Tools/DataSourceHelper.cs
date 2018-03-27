using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    class DataSourceHelper
    {
        public static DataTable GetDataTable(string fileName)
        {
            DataTable dataTable = new DataTable();
            string filePath = Application.StartupPath + "/temp/" + fileName + ".txt";
            if (File.Exists(filePath))
            {
                string[] fs = File.ReadAllLines(filePath, Encoding.UTF8);
                for (int i = 0; i < fs.Length; i++)
                {
                    string[] data = fs[i].Split(',');
                    if (i == 0)
                        for (int j = 0; j < data.Length; j++)
                            dataTable.Columns.Add(new DataColumn(data[j].Replace("[", string.Empty).Replace("]", string.Empty).Replace("\"", string.Empty).Trim()));
                    else
                    {
                        DataRow dataRow = dataTable.NewRow();
                        for (int j = 0; j < data.Length; j++)
                            dataRow[j] = data[j].Replace("[", string.Empty).Replace("]", string.Empty).Replace("\"", string.Empty).Trim();
                        dataTable.Rows.Add(dataRow);
                    }
                }
            }
            return dataTable;
        }
    }
}
