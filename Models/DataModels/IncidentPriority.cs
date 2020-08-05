using System.ComponentModel.DataAnnotations;

namespace NBS.Models.DataModels
{
    //Prios, Statuses, Types
    public class IncidentPriority
    {
        public int Id { get; set; }

        [Display(Name = "Prio.")]
        public string IncidentPriorityName { get; set; }
    }
}