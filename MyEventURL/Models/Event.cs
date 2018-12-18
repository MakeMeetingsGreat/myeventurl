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
        [Display(Name = "Time Zone")]
        public string Timezone { get; set; }
        [Display(Name = "Subject")]
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Location { get; set; }
        public string Organizer { get; set; }
        [Required(ErrorMessage = "Please sign in")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Event Reminder")]
        public bool? Reminder { get; set; }
        public string Format { get; set; }
        [RegularExpression("^" + @"^https:\/\/sway\.office\.com\/[\s\S]*", ErrorMessage = "Please enter a valid Sway URL")]
        [Display(Name = "Sway URL")]
        public string sway { get; set; }
        [Display(Name = "Mask Email")]
        public bool? NoReply { get; set; }
        [RegularExpression("^"+ @"^https:\/\/forms\.office\.com\/Pages\/ResponsePage\.aspx[\s\S]*", ErrorMessage = "Please enter a valid Forms URL")]
        [Display(Name = "Forms URL")]
        public string Forms { get; set; }
        public DateTime? Created { get; set; }
        [Display(Name = "Background")]
        public string Style { get; set; }
        [Display(Name = "Private Event")]
        public bool? Private { get; set; }
        [Display(Name = "Use Icon")]
        public bool? Icon { get; set; }
        public int? Views { get; set; }
        public int? Engaged { get; set; }

        public Event()
        {
            Views = 0;
            Engaged = 0;
            Created = DateTime.UtcNow;
        }

    }
}