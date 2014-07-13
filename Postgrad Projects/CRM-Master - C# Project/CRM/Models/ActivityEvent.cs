using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class ActivityEvent : Activity
    {
        public string ActivityEventSubject { get; set; }
        public double ActivityEventStartDate { get; set; }
        public double ActivityEventEndDate { get; set; }
        public string ActivityEventVenue { get; set; }
        public string ActivityEventContact { get; set; }
    }
}