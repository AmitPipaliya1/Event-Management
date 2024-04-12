using BL;
using LIBRARY;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Event_Management.Controllers
{
    public class AdminController : ApiController
    {
        //---------------------- Admin LOGIN API ----------------------
        [HttpPost]
        [Route("api/Admin/AdminLogin")]
        public SerializeResponse<AdminModel> AdminLogin([FromBody] AdminModel AdminObj)
        {
            try
            {
                Admin admin = new Admin();
                return admin.AdminMethod(AdminObj);
            }
            catch (Exception ex)
            {
                InsertLog.WriteErrrorLog("UserController => CreateUser " + ex.Message + ex.StackTrace);
                throw;
            }
        }
    }
}
