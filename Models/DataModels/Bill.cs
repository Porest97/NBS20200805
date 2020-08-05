using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.Models.DataModels
{
    public class Bill
    {
        public int Id { get; set; }

        //Bill to Company
        [Display(Name = "Bill To:")]
        public int? CompanyId { get; set; }
        [Display(Name = "Bill To:")]
        [ForeignKey("CompanyId")]
        public Company CompanyToBill { get; set; }

        //Bill to Company
        [Display(Name = "Bill From:")]
        public int? CompanyId1 { get; set; }
        [Display(Name = "Bill From:")]
        [ForeignKey("CompanyId1")]
        public Company CompanyBilling { get; set; }

        //Billing Date !
        [Display(Name = "Billing Date")]
        [DataType(DataType.Date)]
        public DateTime? BillingDate { get; set; }


        //DueDate !
        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        [Display(Name = "WorkLog #1")]
        public int? NABLogId { get; set; }
        [Display(Name = "WorkLog #1")]
        [ForeignKey("NABLogId")]
        public NABLog NABLog1 { get; set; }

        [Display(Name = "WorkLog #2")]
        public int? NABLogId1 { get; set; }
        [Display(Name = "WorkLog #2")]
        [ForeignKey("NABLogId1")]
        public NABLog NABLog2 { get; set; }

        [Display(Name = "WorkLog #3")]
        public int? NABLogId2 { get; set; }
        [Display(Name = "WorkLog #3")]
        [ForeignKey("NABLogId2")]
        public NABLog NABLog3 { get; set; }

        [Display(Name = "WorkLog #4")]
        public int? NABLogId3 { get; set; }
        [Display(Name = "WorkLog #4")]
        [ForeignKey("NABLogId3")]
        public NABLog NABLog4 { get; set; }

        [Display(Name = "WorkLog #5")]
        public int? NABLogId4 { get; set; }
        [Display(Name = "WorkLog #5")]
        [ForeignKey("NABLogId4")]
        public NABLog NABLog5 { get; set; }


        //Payment agreement !

        [Display(Name = "Billing Terms")]
        public string BillingTerms { get; set; }

        //Billing !
        [Display(Name = "Hours")]
        public decimal Hours { get; set; }

        [Display(Name = "Price. Hour")]
        public decimal PriceHour { get; set; }

        [Display(Name = "MTR. Cost")]
        public decimal MtrCost { get; set; }

        [Display(Name = "Total")]
        public decimal TotalCost { get; set; }

        //NABLog Status !
        [Display(Name = "Status")]
        public int? BillStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("BillStatusId")]
        public BillStatus BillStatus { get; set; }
    }
}
