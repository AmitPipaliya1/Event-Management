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
    public class EventController : ApiController
    {
        //---------------------- EVENT API ----------------------
        [HttpPost]
        [Route("api/Event/AddEvent")]
        public SerializeResponse<EventModel> AddEvent([FromBody] EventModel EventOBJ)
        {
            try
            {  
                Event newevent = new Event();
                return newevent.EventMethod(EventOBJ);
            }
            catch (Exception ex)
            {
                InsertLog.WriteErrrorLog("UserController => CreateUser " + ex.Message + ex.StackTrace);
                throw;
            }
        }
    }
}
