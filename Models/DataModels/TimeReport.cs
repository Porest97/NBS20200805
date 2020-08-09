using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.Models.DataModels
{
    public class TimeReport
    {
        public int Id { get; set; }
        [Display(Name = "Time report")]
        public string TimeReportName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Created")]
        public DateTime? DateTimeCreated { get; set; }

        [Display(Name = "From")]
        [DataType(DataType.Date)]
        public DateTime? DateTimeFrom { get; set; }

        [Display(Name = "To")]
        [DataType(DataType.Date)]
        public DateTime? DateTimeTo { get; set; }

        [Display(Name = "Creator")]
        public string ApplicationUserId { get; set; }
        [Display(Name = "Creator")]
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser Creator { get; set; }

        [Display(Name = "Employee")]
        public int? PersonId { get; set; }
        [Display(Name = "Employee")]
        [ForeignKey("PersonId")]
        public Person Employee { get; set; }

        ////Adding Logs !
        //public List<WLog> WLogs { get; internal set; }

        //public List<NABLog> NABLogs { get; set; }

        //public List<TimeLog> TimeLogs { get; set; }
    }
}
