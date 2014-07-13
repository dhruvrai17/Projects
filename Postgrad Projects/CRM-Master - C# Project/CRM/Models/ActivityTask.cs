using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class ActivityTask : Activity
    {
        public string ActivityTaskContact { get; set; }
        public double ActivityTaskDueDate { get; set; }
    }
}