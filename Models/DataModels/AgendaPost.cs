using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.Models.DataModels
{
    public class AgendaPost
    {
        public int Id { get; set; }

        [Display(Name = "Veckodag & Datum")]
        [DisplayFormat(DataFormatString = "{0:ddddddd yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateAndTime { get; set; }

        [Display(Name = "Anställd")]
        public string ApplicationUserId { get; set; }
        [Display(Name = "Anställd")]
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser Creator { get; set; }

        [Display(Name ="Beskrivning")]
        public string Description { get; set; }
    }
}
