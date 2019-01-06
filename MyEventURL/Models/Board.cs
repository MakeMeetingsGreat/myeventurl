using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyEventURL
{
    public class Board
    {
        public int BoardID { get; set; }
        public DateTime Created { get; set; }
        public string Events { get; set; }
        public string View { get; set; }
        public string Email { get; set; }
        public string BoardName { get; set; }
        public bool TeamCalendar { get; set; }
        public bool Private { get; set; }

        public Board()
        {
            Created = DateTime.UtcNow;
        }
    }
}