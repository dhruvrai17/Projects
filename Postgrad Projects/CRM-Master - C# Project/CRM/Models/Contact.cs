using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class Contact
    {
        public int ContactId { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name should not exceed 50 characters")]
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter proper phone number.")]
        [Display(Name = "phone")]
        public string ContactPhone { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string ContactEmail { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string ContactReportsTo { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string ContactVendorName { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string ContactDepartment { get; set; }

        public string ContactFax { get; set; }

        [DisplayName("date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public String ContactDOB { get; set; }

        public string ContactSkypeId { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string ContactAssistant { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please enter proper phone number.")]
        [Display(Name = "phone")]
        public string ContactAssistantPhone { get; set; }

        public string ContactFacebook { get; set; }
        public string ContactTwitter { get; set; }
        public string ContactAddress { get; set; }

        [Required]
        [Range(1,120, ErrorMessage="Age must be between 1 and 120")]
        public int ContactAge { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string ContactHobbies { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string ContactFavouriteFood { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string ContactFavouriteSport { get; set; }
    }
}