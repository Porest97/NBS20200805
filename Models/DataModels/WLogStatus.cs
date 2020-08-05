using System.ComponentModel.DataAnnotations;

namespace NBS.Models.DataModels
{
    //Statuses !
    public class WLogStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string WLogStatusName { get; set; }
    }
}