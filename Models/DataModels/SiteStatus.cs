using System.ComponentModel.DataAnnotations;

namespace NBS.Models.DataModels
{
    public class SiteStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string SiteStatusName { get; set; }
    }
}