using System.ComponentModel.DataAnnotations;

namespace NBS.Models.DataModels
{
    public class MtrlList
    {
        public int Id { get; set; }

        [Display(Name = "Mtrl. List")]
        public string Description { get; set; }

        [Display(Name = "#1")]
        public string Item1 { get; set; }

        [Display(Name = "#2")]
        public string Item2 { get; set; }

        [Display(Name = "#3")]
        public string Item3 { get; set; }

        [Display(Name = "#4")]
        public string Item4 { get; set; }

        [Display(Name = "#5")]
        public string Item5 { get; set; }

        [Display(Name = "#6")]
        public string Item6 { get; set; }

        [Display(Name = "#7")]
        public string Item7 { get; set; }

        [Display(Name = "#8")]
        public string Item8 { get; set; }

        [Display(Name = "#9")]
        public string Item9 { get; set; }

        [Display(Name = "#10")]
        public string Item10 { get; set; }
    }
}