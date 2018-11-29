using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEventURL.Models
{
    public class Board
    {
        public int BoardID { get; set; }
        public DateTime Created { get; set; }
        public int[] Events { get; set; }
        public string View { get; set; }
    }
}