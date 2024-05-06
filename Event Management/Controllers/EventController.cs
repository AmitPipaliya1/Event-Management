using BL;
using LIBRARY;
using MODEL;
using System;
using System.Net.Http;
using System.Net;
using System.Web.Http;

namespace Event_Management.Controllers
{
    public class EventController : ApiController
    {
        /// <summary>
        /// Name : Amit Pipaliya
        /// Date : 18-04-24
        /// This API Use for --> Add New Event --> Show Event ---> Publish Event 
        /// </summary>
        [HttpPost]
        [Route("api/Event/AddEvent")]
        public HttpResponseMessage AddEvent(EventModel EventObj)
        {
            InsertLog.WriteErrrorLog("Event Controller ==> AddEvent ==> Started");
            SerializeResponse<EventModel> Objres = new SerializeResponse<EventModel>();
            try
            {
                if (EventObj != null)
                {
                    Event newevent = new Event();
                    Objres = newevent.EventMethod(EventObj);
                }
                else
                {
                    Objres.Message = "Entity Can't Be Null";
                    Objres.ID = 400;
                }
            }
            catch (Exception ex)
            {
                InsertLog.WriteErrrorLog("Event Controller => AddEvent " + ex.Message + ex.StackTrace);
                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, Objres);
        }
    }
}
