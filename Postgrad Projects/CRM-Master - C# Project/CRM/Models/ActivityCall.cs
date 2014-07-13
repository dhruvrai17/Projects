using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class ActivityCall : Activity
    {
        public string ActivityCallType { get; set; }
        public string ActivityCallDetails { get; set; }
        public string ActivityCallDescription { get; set; }
        public string ActivityCallTo { get; set; }
        public string ActivityCallFrom { get; set; }
        public string ActivityCallRelatedTo { get; set; }
    }
}