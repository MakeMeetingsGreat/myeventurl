using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEventURL.Models
{
    public class EngagementInfo
    {
        public int EngagementInfoID { get; set; }
        public DateTime Created { get; set; }
        public string ApplicationID { get; set; }
        public string ItemID { get; set; }
        public string UserID { get; set; }
        public string ActionID { get; set; }

    }
}