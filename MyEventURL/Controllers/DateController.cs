using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace MyEventURL.Controllers
{
    public class DateController : ApiController
    {
        // GET: api/Notes
        public DateTime GetDate(string CheckDate = null)
        {          
            if (CheckDate != null) return DateTime.Parse(CheckDate);
            return DateTime.UtcNow;
            
        }

    }
}
