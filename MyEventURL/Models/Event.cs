using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;



namespace MyEventURL
{
    public class Event
    {
        public int EventId { get; set;}
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Timezone { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Organizer { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public int Reminder { get; set; }
        public string Format { get; set; }
        public int Views { get; set; }
        public int Engaged { get; set; }
        public string sway { get; set; }
        public bool search { get; set; }
        public bool? NoReply { get; set; }
        public string Forms { get; set; }
        public DateTime? Created { get; set; }

        //TBD Deleted
        
        public int Facebook { get; set; }
        public bool AllDay { get; set; }
        public string Recurring { get; set; }
        public string SocialCommentsEngine { get; set; }
        public string TwitterDataWidget { get; set; }
        public string YammerNetwork { get; set; }
        public string SummaryEngine { get; set; }
        public string youtube { get; set; }
        public string storify { get; set; }
        public string surveymonkey { get; set; }
        


        public Event()
        {
            Views = 0;
            Engaged = 0;
            Facebook = 0;
            Format = "MM/DD/YYYY";
            NoReply = false;
            Forms = "";
            Created = DateTime.UtcNow;
        }

    }
}