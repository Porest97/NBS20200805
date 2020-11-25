using NBS.ImageUpload.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.Models.DataModels
{
    public class SiteSurvey
    {
        public int Id { get; set; }

        [Display(Name = "#")]
        public string SiteSurveyNumber { get; set; }

        [Display(Name = "Beskrivning")]
        public string Description { get; set; }

        [Display(Name = "Planerad")]
        public DateTime? Scheduled { get; set; }

        [Display(Name = "Startad")]
        public DateTime? Started { get; set; }

        [Display(Name = "Avslutad")]
        public DateTime? Ended { get; set; }


        [Display(Name = "Skapad")]
        public DateTime Created { get; set; }

        [Display(Name = "Skapare")]
        public string ApplicationUserId { get; set; }
        [Display(Name = "Skapare")]
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser Creator { get; set; }

        

        [Display(Name = "INC#")]
        public int? IncidentId { get; set; }
        [Display(Name = "INC#")]
        [ForeignKey("IncidentId")]
        public Incident Incident { get; set; }


        [Display(Name = "Plan 1")]
        public string FloorOneDescription { get; set; }

        [Display(Name = "#P1-1")]        
        public int? ImageModelId { get; set; }
        [Display(Name = "#P1-1")]
        [ForeignKey("ImageModelId")]        
        public ImageModel ImageModel1 { get; set; }

        [Display(Name = "#P1-2")]
        public int? ImageModelId1 { get; set; }
        [Display(Name = "#P1-2")]
        [ForeignKey("ImageModelId1")]
        public ImageModel ImageModel2 { get; set; }

        [Display(Name = "#P1-3")]
        public int? ImageModelId2 { get; set; }
        [Display(Name = "#p1-3")]
        [ForeignKey("ImageModelId2")]
        public ImageModel ImageModel3 { get; set; }

        [Display(Name = "#P1-4")]
        public int? ImageModelId3 { get; set; }
        [Display(Name = "#P1-4")]
        [ForeignKey("ImageModelId3")]
        public ImageModel ImageModel4 { get; set; }

        [Display(Name = "#P1-5")]
        public int? ImageModelId4 { get; set; }
        [Display(Name = "#P1-5")]
        [ForeignKey("ImageModelId4")]
        public ImageModel ImageModel5 { get; set; }


        [Display(Name = "Plan 2")]
        public string FloorTwoDescription { get; set; }

        [Display(Name = "#P2-1")]
        public int? ImageModelId5 { get; set; }
        [Display(Name = "#P2-1")]
        [ForeignKey("ImageModelId5")]
        public ImageModel ImageModel6 { get; set; }

        [Display(Name = "#P2-2")]
        public int? ImageModelId6 { get; set; }
        [Display(Name = "#P2-2")]
        [ForeignKey("ImageModelId6")]
        public ImageModel ImageModel7 { get; set; }

        [Display(Name = "#P2-3")]
        public int? ImageModelId7 { get; set; }
        [Display(Name = "#P2-3")]
        [ForeignKey("ImageModelId7")]
        public ImageModel ImageModel8 { get; set; }

        [Display(Name = "#P2-4")]
        public int? ImageModelId8 { get; set; }
        [Display(Name = "#P2-4")]
        [ForeignKey("ImageModelId8")]
        public ImageModel ImageModel9 { get; set; }

        [Display(Name = "#P2-5")]
        public int? ImageModelId9 { get; set; }
        [Display(Name = "#P2-5")]
        [ForeignKey("ImageModelId9")]
        public ImageModel ImageModel10 { get; set; }

        [Display(Name = "Plan 3")]
        public string FloorThreeDescription { get; set; }
        [Display(Name = "#P3-1")]
        public int? ImageModelId10 { get; set; }
        [Display(Name = "#P3-1")]
        [ForeignKey("ImageModelId10")]
        public ImageModel ImageModel11 { get; set; }

        [Display(Name = "#P3-2")]
        public int? ImageModelId11 { get; set; }
        [Display(Name = "#P3-2")]
        [ForeignKey("ImageModelId11")]
        public ImageModel ImageModel12 { get; set; }

        [Display(Name = "#P3-3")]
        public int? ImageModelId12 { get; set; }
        [Display(Name = "#P3-3")]
        [ForeignKey("ImageModelId12")]
        public ImageModel ImageModel13 { get; set; }

        [Display(Name = "#P3-4")]
        public int? ImageModelId13 { get; set; }
        [Display(Name = "#P3-4")]
        [ForeignKey("ImageModelId13")]
        public ImageModel ImageModel14 { get; set; }

        [Display(Name = "#P3-5")]
        public int? ImageModelId14 { get; set; }
        [Display(Name = "#P3-5")]
        [ForeignKey("ImageModelId14")]
        public ImageModel ImageModel15 { get; set; }

        [Display(Name = "Plan 4")]
        public string FloorFourDescription { get; set; }
        [Display(Name = "#P4-1")]
        public int? ImageModelId15 { get; set; }
        [Display(Name = "#P4-1")]
        [ForeignKey("ImageModelId15")]
        public ImageModel ImageModel16 { get; set; }

        [Display(Name = "#P4-2")]
        public int? ImageModelId16 { get; set; }
        [Display(Name = "#P4-2")]
        [ForeignKey("ImageModelId16")]
        public ImageModel ImageModel17 { get; set; }

        [Display(Name = "#P4-3")]
        public int? ImageModelId17 { get; set; }
        [Display(Name = "#P4-3")]
        [ForeignKey("ImageModelId17")]
        public ImageModel ImageModel18 { get; set; }

        [Display(Name = "#P4-4")]
        public int? ImageModelId18 { get; set; }
        [Display(Name = "#P4-4")]
        [ForeignKey("ImageModelId18")]
        public ImageModel ImageModel19 { get; set; }

        [Display(Name = "#P4-5")]
        public int? ImageModelId19 { get; set; }
        [Display(Name = "#P4-5")]
        [ForeignKey("ImageModelId19")]
        public ImageModel ImageModel20 { get; set; }


        [Display(Name = "Plan 5")]
        public string FloorFiveDescription { get; set; }
        [Display(Name = "#P5-1")]
        public int? ImageModelId20 { get; set; }
        [Display(Name = "#P5-1")]
        [ForeignKey("ImageModelId20")]
        public ImageModel ImageModel21 { get; set; }

        [Display(Name = "#P5-2")]
        public int? ImageModelId21 { get; set; }
        [Display(Name = "#P5-2")]
        [ForeignKey("ImageModelId21")]
        public ImageModel ImageModel22 { get; set; }

        [Display(Name = "#P5-3")]
        public int? ImageModelId22 { get; set; }
        [Display(Name = "#P5-3")]
        [ForeignKey("ImageModelId22")]
        public ImageModel ImageModel23 { get; set; }

        [Display(Name = "#P5-4")]
        public int? ImageModelId23 { get; set; }
        [Display(Name = "#P5-4")]
        [ForeignKey("ImageModelId23")]
        public ImageModel ImageModel24 { get; set; }

        [Display(Name = "#P5-5")]
        public int? ImageModelId24 { get; set; }
        [Display(Name = "#P5-5")]
        [ForeignKey("ImageModelId24")]
        public ImageModel ImageModel25 { get; set; }


        [Display(Name = "Status")]
        public int? SiteSurveyStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("SiteSurveyStatusId")]
        public SiteSurveyStatus SiteSurveyStatus { get; set; }

    }

    public class SiteSurveyStatus
    {
        public int Id { get; set; }

        public string SiteSurveyStatusName { get; set; }
    }
}
