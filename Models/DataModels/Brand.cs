using System.ComponentModel.DataAnnotations;

namespace NBS.Models.DataModels
{
    public class Brand
    {
        public int Id { get; set; }

        [Display(Name ="Brand")]
        public string BrandName { get; set; }
    }
}