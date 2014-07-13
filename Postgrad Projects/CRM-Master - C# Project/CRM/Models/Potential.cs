using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class Potential
    {
        public int PotentialId { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string PotentialName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string PotentialType { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string PotentialNextStep { get; set; }

        public int LeadId { get; set; }
        public virtual Lead Lead { get; set; }
        public string PotentialLeadSource { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter proper phone number.")]
        [Display(Name = "phone")]
        public string PotentialContact { get; set; }


        public double PotentialAmount { get; set; }

         [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string potentialProbability { get; set; }
        public double PotentialExpectedRevenue { get; set; }

        public int CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; }
        public string PotentialCampaignSource { get; set; }
    }
}