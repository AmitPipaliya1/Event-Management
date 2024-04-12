using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LIBRARY
{
    public static  class Connection
    {
        public static string ConnectionString() 
        {
            string strcon = "data source=DESKTOP-OUFA455\\SQLEXPRESS; database=EventManagement; integrated security=SSPI";
            return strcon;
        }
    }
}