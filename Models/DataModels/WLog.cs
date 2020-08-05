using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBS.Models.DataModels
{
    public class WLog
    {
        public int Id { get; set; }

        [Display(Name = "WL #")]
        public string WLNumber { get; set; }

        [Display(Name = "Hours")]
        public decimal Hours { get; set; }

        [Display(Name = "DateTimeFrom")]
        public DateTime? DateTimeFrom { get; set; }

        [Display(Name = "DateTimeTo")]
        public DateTime? DateTimeTo { get; set; }

        [Display(Name = "Subject")]
        public string Subject { get; set; }

        //WLogStatus !
        [Display(Name = "WL Status")]
        public int? WLogStatusId { get; set; }
        [Display(Name = "WL Status")]
        [ForeignKey("WLogStatusId")]
        public WLogStatus WLogStatus { get; set; }

        [Display(Name = "Incident")]
        public int? IncidentId { get; set; }
        [Display(Name = "Incident")]
        [ForeignKey("IncidentId")]
        public Incident Incident { get; set; }

        [Display(Name = "Employee")]
        public int? PersonId { get; set; }
        [Display(Name = "Employee")]
        [ForeignKey("PersonId")]
        public Person Employee { get; set; }

    }
}