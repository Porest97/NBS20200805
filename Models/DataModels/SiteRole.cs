using System.ComponentModel.DataAnnotations;

namespace NBS.Models.DataModels
{
    //Roles, Statuses and Types !

    public class SiteRole
    {
        public int Id { get; set; }

        [Display(Name = "Role")]
        public string SiteRoleName { get; set; }
    }
}