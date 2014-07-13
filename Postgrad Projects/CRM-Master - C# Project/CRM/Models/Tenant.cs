using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class Tenant
    {
        public int TenantId { get; set; }
        public string TenantUsername { get; set; }
        public string TenantPassword { get; set; }
        public string TenantName { get; set; }
        public string TenantCompany { get; set; }
        public string TenantEmail { get; set; }
        public string TenantTwitter { get; set; }
        public string TenantFacebook { get; set; }
        public string TenantSkype { get; set; }
        public bool Owner { get; set; }
    }
}