using System.ComponentModel.DataAnnotations;

namespace NBS.Models.DataModels
{
    public class SiteType
    {
        public int Id { get; set; }

        [Display(Name = "Type")]
        public string SiteTypeName { get; set; }
    }
}