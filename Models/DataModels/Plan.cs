using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.Models.DataModels
{
    public class Plan
    {
        public int Id { get; set; }

        [Display(Name ="User")]
        public string ApplicationUserId { get; set; }
        [Display(Name = "User")]
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Plan")]
        public string PlanName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End")]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Site")]
        public int? SiteId { get; set; }
        [Display(Name = "Site")]
        [ForeignKey("SiteId")]
        public Site Site { get; set; }

        public List<Job> Jobs { get; set; }
    }

    public class Job
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string TimeStarted { get; set; }

        public string TimeEnded { get; set; }

        public decimal Hours { get; set; }

    }
}
