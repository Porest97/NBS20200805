using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.Models.DataModels
{
    public class Transaction
    {
        public int Id { get; set; }

        [Display(Name = "Date&Time")]        
        public DateTime TransactionDate { get; set; }

        [Display(Name = "Account")]
        public int SallaryAccountId { get; set; }
        [Display(Name = "Account")]
        [ForeignKey("SallaryAccountId")]
        public SallaryAccount SallaryAccount { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Amount")]
        public decimal TransactionAmount { get; set; }
    }
}
