using System.Configuration;

namespace LIBRARY
{
    public static class Connection
    {
        public static string ConnectionString()
        {
            string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            return strcon;
        }
    }
}