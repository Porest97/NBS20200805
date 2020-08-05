using System.ComponentModel.DataAnnotations;

namespace NBS.Models.DataModels
{
    public class OfferStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string OfferStatusName { get; set; }
    }
}
