using BL;
using LIBRARY;
using Microsoft.Ajax.Utilities;
using MODEL;
using System;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting;
using System.Web.Http;

namespace Event_Management.Controllers
{
    public class AdminController : ApiController
    {
        // This API Use for Admin Login 
        [HttpPost]
        [Route("api/Admin/AdminLogin")]
        public HttpResponseMessage AdminLogin(AdminModel AdminObj)
        {
            SerializeResponse<AdminModel> Objres = new SerializeResponse<AdminModel>();
            try{
                if (AdminObj != null)
                {
                  Admin admin = new Admin();
                  Objres = admin.AdminMethod(AdminObj);                   
                }
                else
                {
                    Objres.Message = "Entity Can't Be Null";
                    Objres.ID = 400;
                }
            }
            catch(Exception ex) {
                InsertLog.WriteErrrorLog("Admin Controller => Admin " + ex.Message + ex.StackTrace);
                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK,Objres);
        }
    }
}
