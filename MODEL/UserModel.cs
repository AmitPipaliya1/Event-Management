using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class UserModel
    {
        public int UserId { get; set; } 
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string FLAG { get; set; } 
    }
}

//@UserId BIGINT,
//@Name VARCHAR(100),
//@EmailId VARCHAR(320),
//@Password Varchar(100),
//@MobileNo VARCHAR(10),
//@Address text,
//@FLAG VARCHAR(50)