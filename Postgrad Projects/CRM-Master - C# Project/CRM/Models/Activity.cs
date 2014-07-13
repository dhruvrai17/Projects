using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public int UserId { get; set; }

        public int ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        public int LeadId { get; set; }
        public virtual Lead Lead { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string ActivitySubject { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string ActivityPurpose { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string ActivityStatus { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string ActivityDescription { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string ActivitySendReminderEmail { get; set; }
    }
}