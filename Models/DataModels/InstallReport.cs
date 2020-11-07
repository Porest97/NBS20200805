using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.Models.DataModels
{
    public class InstallReport
    {
        public int Id { get; set; }

        [Display(Name ="Rapport")]
        public string InstallReportName { get; set; }

        [Display(Name = "Beskrivning")]
        public string InstallReportDescription { get; set; }

        [Display(Name = "Författare")]
        public int? PersonId { get; set; }
        [Display(Name = "Författare")]
        [ForeignKey("PersonId")]
        public Person Author { get; set; }

        [Display(Name = "Site")]
        public int? SiteId { get; set; }
        [Display(Name = "Site")]
        [ForeignKey("SiteId")]
        public Site Site { get; set; }

        [Display(Name = "#1")]
        public int? AssetId { get; set; }
        [Display(Name = "#1")]
        [ForeignKey("AssetId")]
        public Asset Asset1 { get; set; }

        [Display(Name = "#2")]
        public int? AssetId1 { get; set; }
        [Display(Name = "#2")]
        [ForeignKey("AssetId1")]
        public Asset Asset2 { get; set; }

        [Display(Name = "#3")]
        public int? AssetId2 { get; set; }
        [Display(Name = "#3")]
        [ForeignKey("AssetId2")]
        public Asset Asset3 { get; set; }

        [Display(Name = "#4")]
        public int? AssetId3 { get; set; }
        [Display(Name = "#4")]
        [ForeignKey("AssetId3")]
        public Asset Asset4 { get; set; }

        [Display(Name = "#5")]
        public int? AssetId4 { get; set; }
        [Display(Name = "#5")]
        [ForeignKey("AssetId4")]
        public Asset Asset5 { get; set; }

        [Display(Name = "#6")]
        public int? AssetId5 { get; set; }
        [Display(Name = "#6")]
        [ForeignKey("AssetId5")]
        public Asset Asset6 { get; set; }

        [Display(Name = "#7")]
        public int? AssetId6 { get; set; }
        [Display(Name = "#7")]
        [ForeignKey("AssetId6")]
        public Asset Asset7 { get; set; }

        [Display(Name = "#8")]
        public int? AssetId7 { get; set; }
        [Display(Name = "#8")]
        [ForeignKey("AssetId7")]
        public Asset Asset8 { get; set; }

        [Display(Name = "#9")]
        public int? AssetId8 { get; set; }
        [Display(Name = "#9")]
        [ForeignKey("AssetId8")]
        public Asset Asset9 { get; set; }

        [Display(Name = "#10")]
        public int? AssetId9 { get; set; }
        [Display(Name = "#10")]
        [ForeignKey("AssetId9")]
        public Asset Asset10 { get; set; }

        [Display(Name = "#11")]
        public int? AssetId10 { get; set; }
        [Display(Name = "#11")]
        [ForeignKey("AssetId10")]
        public Asset Asset11 { get; set; }

        [Display(Name = "#12")]
        public int? AssetId11 { get; set; }
        [Display(Name = "#12")]
        [ForeignKey("AssetId11")]
        public Asset Asset12 { get; set; }

        [Display(Name = "#13")]
        public int? AssetId12 { get; set; }
        [Display(Name = "#13")]
        [ForeignKey("AssetId12")]
        public Asset Asset13 { get; set; }

        [Display(Name = "#14")]
        public int? AssetId13 { get; set; }
        [Display(Name = "#14")]
        [ForeignKey("AssetId13")]
        public Asset Asset14 { get; set; }

        [Display(Name = "#15")]
        public int? AssetId14 { get; set; }
        [Display(Name = "#15")]
        [ForeignKey("AssetId14")]
        public Asset Asset15 { get; set; }

        [Display(Name = "Summering")]
        public string InstallReportConclusions { get; set; }

    }
}
