using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class Campaign
    {
        public int CampaignId { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage="First name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string CampaignName { get; set; }

        [DisplayName("Start date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public double CampaignStartDate { get; set; }

        [DisplayName("End date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public double CampaignEndDate { get; set; }

        [RegularExpression(@"^\d+$", ErrorMessage = "Please enter correct amount")]
        public string CampaignStatus { get; set; }
        public double CampaignExpectedRevenue { get; set; }
        public double CampaignActualCost { get; set; }
        public double CampaignBudgetedCost { get; set; }
        public double CampaignExpectedResponse { get; set; }
    }
}