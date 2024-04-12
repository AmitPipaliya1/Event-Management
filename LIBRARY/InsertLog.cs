using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace LIBRARY
{
    public class InsertLog
    {
      

        public static void WriteErrrorLog(string exception)
        {
            try
            {
                //if (!exception.ToString().ToLower().Contains("password") && !exception.ToString().ToLower().Contains("user_id"))
                //{
                    string path = AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLog\\ErrorLog_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
                    if (!Directory.Exists(path.Substring(0, path.LastIndexOf('\\'))))
                    {
                        Directory.CreateDirectory(path.Substring(0, path.LastIndexOf('\\')));
                    }
                    if (!File.Exists(path))
                    {
                        File.Create(path).Close();
                    }
                    TextWriter tw = new StreamWriter(path, true);
                    tw.WriteLine("------------------------------------------" + DateTime.Now.ToString() + "------------------------------------------");
                    tw.WriteLine(exception);
                    tw.Close();
               // }
            }
            catch (Exception ex)
            {
               InsertLog.WriteErrrorLog( ex.ToString()+"=="+ex.StackTrace.ToString());
            }
        }
    }
}
