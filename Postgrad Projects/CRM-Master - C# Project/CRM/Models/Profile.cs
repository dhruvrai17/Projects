using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String CompanyName { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }
        public string SkypeId { get; set; }
    }
}