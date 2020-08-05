using System.ComponentModel.DataAnnotations;

namespace NBS.Models.DataModels
{
    public class NABLogStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string NABLogStatusName { get; set; }
    }
}