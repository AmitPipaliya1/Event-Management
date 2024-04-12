using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LIBRARY;
using MODEL;
using BL;

namespace Event_Management.Controllers
{
    public class UserController : ApiController
    {
        //---------------------- USER REGISTRATION AND LOGIN API ----------------------
        [HttpPost]
        [Route("api/User/CreateUser")]
        public SerializeResponse<UserModel> CreateUser([FromBody] UserModel userobj)
        {
            try
            {
                User user = new User();
                return user.UserMethod(userobj);
            }
            catch (Exception ex)
            {
                InsertLog.WriteErrrorLog("UserController => CreateUser " + ex.Message + ex.StackTrace);
                throw;
            }
        }
    }
}
