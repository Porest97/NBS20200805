using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.Models.DataModels
{
    public class TimBanksPost
    {
        public int Id { get; set; }


        [Display(Name = "Kund")]
        public string Customer { get; set; }

        [Display(Name = "Incident")]
        public string Incident { get; set; }

        [Display(Name = "Startad")]
        public DateTime? Started { get; set; }

        [Display(Name = "Avslutad")]
        public DateTime? Ended { get; set; }

        [Display(Name = "Tid")]
        public decimal Hours { get; set; }

        [Display(Name = "Tim. Pris")]
        public decimal Price { get; set; }

        [Display(Name = "Totalt")]
        public decimal Total { get; set; }

        [Display(Name = "Utlägg")]
        public decimal Outlay { get; set; }

        [Display(Name = "Ansälld")]
        public int? PersonId { get; set; }
        [Display(Name = "Anställd")]
        [ForeignKey("PersonId")]
        public Person Employee { get; set; }

        [Display(Name = "Anteckningar")]
        public string Notes { get; set; }

        [Display(Name = "WL#")]
        public string WLNumber { get; set; }

        [Display(Name = "Status")]
        public int? TBPStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("TBPStatusId")]
        public TBPStatus TBPStatus { get; set; }

    }

    public class TBPStatus
    {
        public int Id { get; set; }
        [Display(Name = "Status")]
        public string TBPStatusName { get; set; }
    }
}
