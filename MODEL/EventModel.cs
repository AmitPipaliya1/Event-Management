using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class EventModel
    {
        public int EventId { get; set; }
        public string EventName { get; set; }
        public string Discription { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Image { get; set; }
        public string FLAG { get; set; }
    }
}

//@EventId BIGINT,
//@EventName VARCHAR(200) ,
//@Discription VARCHAR(500),
//@StartDate DATETIME,
//@EndDate DATETIME,
//@Image VARCHAR(MAX),
//@IsActive BIT,
//@IsPublish BIT,
//@FLAG VARCHAR(50)