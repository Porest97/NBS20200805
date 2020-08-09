using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.Models.DataModels
{
    public class TimeLog
    {
        public int Id { get; set; }

        [Display(Name = "Creator")]
        public string ApplicationUserId { get; set; }
        [Display(Name = "Creator")]
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser Creator { get; set; }

        [Display(Name = "INC #")]
        public int? IncidentId { get; set; }
        [Display(Name = "INC #")]
        [ForeignKey("IncidentId")]
        public Incident Incident { get; set; }

        [Display(Name = "Started")]
        public DateTime? DateTimeStarted { get; set; }

        [Display(Name = "Ended")]
        public DateTime? DateTimeEnded { get; set; }

        [Display(Name = "Log notes")]
        public string LogNotes { get; set; }

        //Billing !
        [Display(Name = "Hours")]
        public decimal Hours { get; set; }

        [Display(Name = "Price. Hour")]
        public decimal PriceHour { get; set; }


        // This MFK have to be altered at a later state :P !
        [Display(Name = "Outlay")]
        public decimal MtrCost { get; set; }

        [Display(Name = "Total")]
        public decimal TotalCost { get; set; }

        //WorkLog in DWorkins system !
        [Display(Name = "WL #")]
        public int? WLogId { get; set; }
        [Display(Name = "WL #")]
        [ForeignKey("WLogId")]
        public WLog WLog { get; set; }

        //NABLog Status !
        [Display(Name = "Status")]
        public int? TimeLogStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("TimeLogStatusId")]
        public TimeLogStatus TimeLogStatus { get; set; }

        [Display(Name = "Employee")]
        public int? PersonId { get; set; }
        [Display(Name = "Employee")]
        [ForeignKey("PersonId")]
        public Person Employee { get; set; }

        
        public bool IsSelected { get; set; }

    }
}
