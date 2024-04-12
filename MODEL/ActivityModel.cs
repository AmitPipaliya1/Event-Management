using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class ActivityModel
    {
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string Discription { get; set; }
        public int Price { get; set; }
        public int EventId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string FLAG { get; set; }
    }
}

//@ActivityId BIGINT,
//@ActivityName VARCHAR(200),
//@Discription VARCHAR(500),
//@Price BIGINT,
//@EventId BIGINT,
//@StartDate DATETIME,
//@EndDate DATETIME,
//@FLAG varchar(50)