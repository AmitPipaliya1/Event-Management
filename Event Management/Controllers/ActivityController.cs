using BL;
using LIBRARY;
using MODEL;
using System;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using System.Runtime.Remoting;

namespace Event_Management.Controllers
{
    public class ActivityController : ApiController
    {

        /// <summary>
        /// Name : Amit Pipaliya
        /// Date : 18-04-24
        /// This API Use for --> Add New Activity --> Show Activity ---> Add Price 
        /// </summary>
        [HttpPost]
        [Route("api/Activity/AddActivity")]
        public HttpResponseMessage AddActivity(ActivityModel ActivityObj)
        {
            InsertLog.WriteErrrorLog("Activity Controller => AddActivity ==> Started");
            SerializeResponse<ActivityModel> Objres= new SerializeResponse<ActivityModel>();
            try
            {      
                   if(ActivityObj != null)
                   {
                    Activity activity = new Activity();
                    Objres = activity.ActivityMethod(ActivityObj);
                   }
                  else
                  {
                    Objres.Message = "Entity Can't Be Null";
                    Objres.ID = 400;
                  }
                   
            }
            catch (Exception ex)
            {
                InsertLog.WriteErrrorLog("Activity Controller => AddActivity " + ex.Message + ex.StackTrace);
                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, Objres);
        }

    }
}
