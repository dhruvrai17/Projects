using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class Lead
    {
        public int LeadId { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LeadName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LeadTitle { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LeadSource { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LeadIndustry { get; set; }
        public double LeadAnnualRevenue { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LeadCompanyName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string LeadEmail { get; set; }
        public string LeadFax { get; set; }

        [Url]
        public string LeadWebsite { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string LeadStatus { get; set; }
        public int LeadNoOfEmployees { get; set; }
        public string LeadSkypeId { get; set; }
        public string LeadFacebook { get; set; }
        public string LeadTwitter { get; set; }
        public string LeadAddress { get; set; }
    }
}