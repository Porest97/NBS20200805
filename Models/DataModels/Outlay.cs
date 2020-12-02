using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.Models.DataModels
{
    public class Outlay
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Skapad")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateTimePosted { get; set; }

        [Display(Name = "Ändrad")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DateTimeChanged { get; set; }

        [Display(Name = "Anställd")]
        public string ApplicationUserId { get; set; }
        [Display(Name = "Anställd")]
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser Employee { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("StatusId")]
        public Status Status { get; set; }


        public Outlay()
        {
            DateTimePosted = DateTime.Now;
            DateTimeChanged = DateTime.Now;
        }


        [Display(Name = "Datum & Tid")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime OutlayDateTime { get; set; }

        [Display(Name = "Beskrivning")]
        public string OutlayDescription { get; set; }    
                
        [Display(Name = "Belopp")]
        public decimal Amount { get; set; }
        
    }
}
