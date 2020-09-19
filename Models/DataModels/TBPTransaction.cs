using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.Models.DataModels
{
    public class TBPTransaction
    {
        public int Id { get; set; }

        [Display(Name = "Datum/Tid")]
        public DateTime TransactionDate { get; set; }

        [Display(Name = "Konto")]
        public int SallaryAccountId { get; set; }
        [Display(Name = "Konto")]
        [ForeignKey("SallaryAccountId")]
        public SallaryAccount SallaryAccount { get; set; }

        [Display(Name = "Beskrivning")]
        public string Description { get; set; }

        [Display(Name = "Tim")]
        public decimal Hours { get; set; }

        [Display(Name = "Pris")]
        public decimal Price { get; set; }

        [Display(Name = "Belopp")]
        public decimal TransactionAmount { get; set; }       

    }
}
