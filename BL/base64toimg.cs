using LIBRARY;
using MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class base64toimg
    {
        public static string StringToImage(string path)
        {
            string base64ImageRepresentation = null;
            try
            {
                // create byte array
                byte[] imageArray = System.IO.File.ReadAllBytes(path);
                // convert byte array into base64 string
                base64ImageRepresentation = Convert.ToBase64String(imageArray);
            }
            catch (Exception ex)
            {
                InsertLog.WriteErrrorLog("StringConvert => StringToImage => Exception" + ex.Message + ex.StackTrace);
            }
            return base64ImageRepresentation;
        }
    }
}
