using System;
using System.IO;
using System.Text;

namespace 数据采集档案管理系统___课题版
{
    public class GetFilePageCount
    {
        private static GetFilePageCount _getFilePageCount;

        private GetFilePageCount() { }

        public static GetFilePageCount GetFilePageCountInstince()
        {
            if(_getFilePageCount == null)
                _getFilePageCount = new GetFilePageCount();
            return _getFilePageCount;
        }

        private int BytesLastIndexOf(Byte[] buffer, int length, string Search)
        {
            if(buffer == null)
                return -1;
            if(buffer.Length <= 0)
                return -1;
            byte[] SearchBytes = Encoding.Default.GetBytes(Search.ToUpper());
            for(int i = length - SearchBytes.Length; i >= 0; i--)
            {
                bool bFound = true;
                for(int j = 0; j < SearchBytes.Length; j++)
                {
                    if(ByteUpper(buffer[i + j]) != SearchBytes[j])
                    {
                        bFound = false;
                        break;
                    }
                }
                if(bFound)
                    return i;
            }
            return -1;
        }
        private byte ByteUpper(byte byteValue)
        {
            char charValue = Convert.ToChar(byteValue);
            if(charValue < 'a' || charValue > 'z')
                return byteValue;
            else
                return Convert.ToByte(byteValue - 32);
        }
       
        /// <summary>
        /// 获取pdf文件的页数
        /// </summary>
        public int GetPDFPageCount(string filePath)
        {
            byte[] buffer = File.ReadAllBytes(filePath);
            int length = buffer.Length;
            if(buffer == null)
                return -1;
            if(buffer.Length <= 0)
                return -1;
            try
            {
                //Sample
                //      29 0 obj
                //      <</Count 9
                //      Type /Pages
                int i = 0;
                int nPos = BytesLastIndexOf(buffer, length, "/Type/Pages");
                if(nPos == -1)
                    return -1;
                string pageCount = null;
                for(i = nPos; i < length - 10; i++)
                {
                    if(buffer[i] == '/' && buffer[i + 1] == 'C' && buffer[i + 2] == 'o' && buffer[i + 3] == 'u' && buffer[i + 4] == 'n' && buffer[i + 5] == 't')
                    {
                        int j = i + 3;
                        while(buffer[j] != '/' && buffer[j] != '>')
                            j++;
                        pageCount = Encoding.Default.GetString(buffer, i, j - i);
                        break;
                    }
                }
                if(pageCount == null)
                    return -1;
                int n = pageCount.IndexOf("Count");
                if(n > 0)
                {
                    pageCount = pageCount.Substring(n + 5).Trim();
                    for(i = pageCount.Length - 1; i >= 0; i--)
                    {
                        if(pageCount[i] >= '0' && pageCount[i] <= '9')
                        {
                            return int.Parse(pageCount.Substring(0, i + 1));
                        }
                    }
                }
                return -1;
            }
            catch(Exception)
            {
                return -1;
            }
        }

        /// <summary>
        /// 获取Word文件页数【格式为doc,docx】
        /// </summary>
        public int GetWordPageCount(object filePath)
        {
            Microsoft.Office.Interop.Word.Application myWordApp = new Microsoft.Office.Interop.Word.ApplicationClass();
            object oMissing = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word.Document myWordDoc = myWordApp.Documents.Open(
                ref filePath, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing);
            int pages = myWordDoc.ComputeStatistics(Microsoft.Office.Interop.Word.WdStatistic.wdStatisticPages, ref oMissing);
            myWordDoc.Close(ref oMissing, ref oMissing, ref oMissing);
            myWordApp.Quit(ref oMissing, ref oMissing, ref oMissing);
            return pages;
        }
    }
}
