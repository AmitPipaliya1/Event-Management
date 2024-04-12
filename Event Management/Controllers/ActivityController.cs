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
    public class ActivityController : ApiController
    {
        //---------------------- Activity API ----------------------
        [HttpPost]
        [Route("api/Activity/AddActivity")]
        public SerializeResponse<ActivityModel> AddActivity([FromBody] ActivityModel AdminObj)
        {
            try
            {
                Activity activity = new Activity();
                return activity.ActivityMethod(AdminObj);
            }
            catch (Exception ex)
            {
                InsertLog.WriteErrrorLog("UserController => CreateUser " + ex.Message + ex.StackTrace);
                throw;
            }
        }
    }
}
