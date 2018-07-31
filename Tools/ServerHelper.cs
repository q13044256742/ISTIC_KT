using System;
using System.IO;
using System.Windows.Forms;

namespace 数据采集档案管理系统___课题版
{
    class ServerHelper
    {
        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="IPaddress">服务器IP地址</param>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns>连接是否成功</returns>
        public static bool GetConnectState(ref object IPAddress)
        {
            bool Flag = false;
            string key = "00001";
            object[] obj = SQLiteHelper.ExecuteRowsQuery($"SELECT pri_code, pri_key, pri_value FROM private_info WHERE pri_id='{key}'");
            if(obj != null)
            {
                IPAddress = obj[0];
                object userName = obj[1];
                object passWord = obj[2];
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                try
                {
                    proc.StartInfo.FileName = "CMD.EXE";
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.RedirectStandardInput = true;
                    proc.StartInfo.RedirectStandardOutput = true;
                    proc.StartInfo.RedirectStandardError = true;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.Start();
                    string dosLine = @"NET USE \\" + IPAddress + " " + passWord + @" /USER:" + userName;
                    proc.StandardInput.WriteLine(dosLine);
                    proc.StandardInput.WriteLine("EXIT");
                    while(!proc.HasExited)
                        proc.WaitForExit(1000);
                    string errormsg = proc.StandardError.ReadToEnd();
                    proc.StandardError.Close();
                    if(string.IsNullOrEmpty(errormsg))
                        Flag = true;
                    else
                        throw new Exception(errormsg);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    proc.Close();
                    proc.Dispose();
                }
            }
            return Flag;
        }

        /// <summary>  
        /// 从远程服务器下载文件到本地  
        /// </summary>  
        /// <param name="src">下载到本地后的文件路径，包含文件的扩展名</param>  
        /// <param name="dst">远程服务器路径（共享文件夹路径）</param>  
        /// <param name="fileName">远程服务器（共享文件夹）中的文件名称，包含扩展名</param>
        public static void DownloadFile(string src, string dst, string fileName)
        {
            if(!Directory.Exists(dst))
                Directory.CreateDirectory(dst);
            dst = dst + fileName;
            FileStream inFileStream = new FileStream(dst, FileMode.Open);    //远程服务器文件  此处假定远程服务器共享文件夹下确实包含本文件，否则程序报错  
            FileStream outFileStream = new FileStream(src, FileMode.OpenOrCreate);   //从远程服务器下载到本地的文件  
            byte[] buf = new byte[inFileStream.Length];
            int byteCount;
            while((byteCount = inFileStream.Read(buf, 0, buf.Length)) > 0)
                outFileStream.Write(buf, 0, byteCount);
            inFileStream.Flush();
            inFileStream.Close();
            outFileStream.Flush();
            outFileStream.Close();
        }

        /// <summary>  
        /// 将本地文件上传到远程服务器共享目录  
        /// </summary>  
        /// <param name="src">本地文件的绝对路径，包含扩展名</param>  
        /// <param name="dst">远程服务器共享文件路径，不包含文件扩展名</param>  
        /// <param name="fileName">上传到远程服务器后的文件扩展名</param>  
        public static void UploadFile(string src, string dst, string fileName)
        {
            FileStream inFileStream = new FileStream(src, FileMode.Open, FileAccess.Read);    //此处假定本地文件存在，不然程序会报错     
            if(!Directory.Exists(dst))        //判断上传到的远程服务器路径是否存在  
                Directory.CreateDirectory(dst);
            dst = dst + "\\" + fileName;            //上传到远程服务器共享文件夹后文件的绝对路径  
            FileStream outFileStream = new FileStream(dst, FileMode.OpenOrCreate, FileAccess.Write);
            byte[] buf = new byte[inFileStream.Length];
            int byteCount;
            while((byteCount = inFileStream.Read(buf, 0, buf.Length)) > 0)
                outFileStream.Write(buf, 0, byteCount);
            inFileStream.Flush();
            inFileStream.Close();
            outFileStream.Flush();
            outFileStream.Close();
        }
    }
}
