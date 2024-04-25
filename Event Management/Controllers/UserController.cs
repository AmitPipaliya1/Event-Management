using BL;
using LIBRARY;
using MODEL;
using System;
using System.Net.Http;
using System.Net;
using System.Web.Http;

namespace Event_Management.Controllers
{
    public class UserController : ApiController
    {
        // This API Use for --> User Registration  --> User Login   
        [HttpPost]
        [Route("api/User/CreateUser")]
        public HttpResponseMessage CreateUser(UserModel UserObj)
        {
            InsertLog.WriteErrrorLog("User Controller ==> Create User ==> Started");
            SerializeResponse<UserModel> Objres = new SerializeResponse<UserModel>();
            try
            {
                if (UserObj != null)
                {
                    User newuser = new User();
                    Objres = newuser.UserMethod(UserObj);
                }
                else
                {
                    Objres.Message = "Entity Can't Be Null";
                    Objres.ID = 400;
                }
            }
            catch (Exception ex)
            {
                InsertLog.WriteErrrorLog("User Controller ==> Create User ==> End " + ex.Message + ex.StackTrace);
                throw;
            }
            return Request.CreateResponse(HttpStatusCode.OK, Objres);
        }
    }
}
