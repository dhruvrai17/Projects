using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRM.Models
{
    public class CrmDb : DbContext
    {
        /*public CrmDb() : base("name=DefaultConnection")
        {

        }*/
        public DbSet <Profile> Profiles { get; set; }
        public DbSet <Tenant> Tenants { get; set; }
        public DbSet <Lead> Leads { get; set; }
        public DbSet <Contact> Contacts { get; set; }
        public DbSet <Potential> Potentials { get; set; }
        public DbSet <Campaign> Campaigns { get; set; }
        public DbSet <Activity> Activities { get; set; }
    }
}