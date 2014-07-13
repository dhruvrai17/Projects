using CRM.Models;
using CRM.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.UnityFramework
{
    public class UnitOfWork : IDisposable
    {
        private CommonRepository<Lead> LeadRepository;
        private CommonRepository<Contact> ContactRepository;
        private CommonRepository<Campaign> CampaignRepository;
        private CommonRepository<Activity> ActivityRepository;
        private CommonRepository<Potential> PotentialRepository;

        CrmDb context = new CrmDb();

         public CommonRepository<Lead> leadRepository
        {
            get
            {
                if (this.LeadRepository == null)
                this.LeadRepository = new CommonRepository<Lead>(context);
                return LeadRepository;
            }
        }
 
        public CommonRepository<Contact> contactRepository
        {
            get
            {
            if (this.ContactRepository == null)
                this.ContactRepository = new CommonRepository<Contact>(context);
            return ContactRepository;
            }
        }

        public CommonRepository<Campaign> campaignRepository
        {
            get
            {
                if (this.CampaignRepository == null)
                    this.CampaignRepository = new CommonRepository<Campaign>(context);
                return CampaignRepository;
            } 
        }

        public CommonRepository<Activity> activityRepository
        {
            get
            {
                if (this.ActivityRepository == null)
                    this.ActivityRepository = new CommonRepository<Activity>(context);
                return ActivityRepository;
            }
        }

        public CommonRepository<Potential> potentialRepository
        {
            get
            {
                if (this.PotentialRepository == null)
                    this.PotentialRepository = new CommonRepository<Potential>(context);
                return PotentialRepository;
            }
        }

    public void Save()
    {
        context.SaveChanges();
    }
    private bool disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        this.disposed = true;
    }
 
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    }
}