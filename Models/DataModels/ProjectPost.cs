using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.Models.DataModels
{
    public class ProjectPost
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Skapad")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? DateTimePosted { get; set; }

        [Display(Name = "Ändrad")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? DateTimeChanged { get; set; }

        public ProjectPost()
        {
            DateTimePosted = DateTime.Now;
            DateTimeChanged = DateTime.Now;
        }

        //Description & TimeEstimate
        [Display(Name = "Beskrivning")]
        public string ProjectPostDescription { get; set; }

        //Planed !
        [Display(Name = "Plan.Start")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime? DateTimePlaned { get; set; }

        //Started & Done !
        [Display(Name = "Startad")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime? DateTimeStarted { get; set; }

        [Display(Name = "Avslutad")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = false)]
        public DateTime? DateTimeDone { get; set; }

        //Price per Hour !
        [Display(Name = "Tim.Pris")]
        public decimal HourPrice { get; set; }

        //Cost calc Estimate !
        [Display(Name = "Est.tim")]
        public decimal TimeEstimate { get; set; }

        [Display(Name = "Est.Tot")]
        public decimal TotalCostEstimate { get; set; }

        //Costs calc Accual !

        [Display(Name = "Tim")]
        public decimal TimeActual { get; set; }

        [Display(Name = "Mtr.Kostnad")]
        public decimal MtrCostActual { get; set; }

        [Display(Name = "Arb.Kostnad")]
        public decimal LabourCostActual { get; set; }

        [Display(Name = "Totalt")]
        public decimal TotalCostActual { get; set; }

        [Display(Name = "Status")]
        public int ProjectPostStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("ProjectPostStatusId")]
        public ProjectPostStatus Status { get; set; }

        // Shift Description, Where You state all details for whats planed in this shift !
        [Display(Name = "Shift Beskrivning")]
        public string ShiftDescription { get; set; }

    }
    public class ProjectPostStatus
    {
        [Key]
        public int Id { get; set; }

        public string ProjectPostStatusName { get; set; }
    }
}
