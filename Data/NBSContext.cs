using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NBS.ImageUpload.Models;
using NBS.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.Data
{   

    public class NBSContext : IdentityDbContext<ApplicationUser>
    {
        public NBSContext(DbContextOptions<NBSContext> options)
            : base(options)
        { }
        public DbSet<Asset> Asset { get; set; }
        public DbSet<AssetStatus> AssetStatus { get; set; }
        public DbSet<AssetType> AssetType { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyRole> CompanyRole { get; set; }
        public DbSet<CompanyStatus> CompanyStatus { get; set; }
        public DbSet<CompanyType> CompanyType { get; set; }
        public DbSet<Incident> Incident { get; set; }
        public DbSet<IncidentPriority> IncidentPriority { get; set; }
        public DbSet<IncidentStatus> IncidentStatus { get; set; }
        public DbSet<IncidentType> IncidentType { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Offer> Offer { get; set; }
        public DbSet<OfferStatus> OfferStatus { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonAccounts> PersonAccounts { get; set; }
        public DbSet<PersonRole> PersonRole { get; set; }
        public DbSet<PersonStatus> PersonStatus { get; set; }
        public DbSet<PersonType> PersonType { get; set; }

        public DbSet<Plan> Plan { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public DbSet<Site> Site { get; set; }
        public DbSet<SiteRole> SiteRole { get; set; }
        public DbSet<SiteStatus> SiteStatus { get; set; }
        public DbSet<SiteType> SiteType { get; set; }

        public DbSet<TimeLog> TimeLog { get; set; }
        public DbSet<TimeLogStatus> TimeLogStatus { get; set; }

        public DbSet<TimeReport> TimeReport { get; set; }
        public DbSet<TimeReportStatus> TimeReportStatus { get; set; }

        public DbSet<WLog> WLog { get; set; }
        public DbSet<WLogStatus> WLogStatus { get; set; }       
        public DbSet<NABLog> NABLog { get; set; }
        public DbSet<NABLogStatus> NABLogStatus { get; set; }
        public DbSet<MtrlList> MtrlList { get; set; }        
        public DbSet<Bill> Bill { get; set; }
        public DbSet<BillStatus> BillStatus { get; set; }
        //SallaryAccount and Transaction
        public DbSet<SallaryAccount> SallaryAccount { get; set; }
        public DbSet<Transaction> Transaction { get; set; }

        public DbSet<TBPTransaction> TBPTransaction { get; set; }

        public DbSet<AgendaPost> AgendaPost { get; set; }

        public DbSet<TimBanksPost> TimBanksPost { get; set; }

        public DbSet<TBPStatus> TBPStatus { get; set; }

        public DbSet<BillingPost> BillingPost { get; set; }

        public DbSet<BPStatus> BPStatus { get; set; }

        public DbSet<ImageModel> Images { get; set; }

        public DbSet<SupportRequest> SupportRequests { get; set; }

        public DbSet<RequestPrio> RequestPrios { get; set; }

        public DbSet<RequestStatus> RequestStatuses { get; set; }

        public DbSet<RequestType> RequestTypes { get; set; }

        public DbSet<Outlay> Outlays { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }     

        public DbSet<Testing> Testing { get; set; }
        public DbSet<Status> Statuses { get; set; }

        public DbSet<SiteSurvey> SiteSurvey { get; set; }
        
    }
}
