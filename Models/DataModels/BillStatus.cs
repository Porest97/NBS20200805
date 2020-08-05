using System.ComponentModel.DataAnnotations;

namespace NBS.Models.DataModels
{
    public class BillStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string BillStatusName { get; set; }

    }
}
