using System.ComponentModel.DataAnnotations;

namespace NBS.Models.DataModels
{
    public class IncidentStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string IncidentStatusName { get; set; }
    }
}