using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBS.Models.DataModels
{
    public class Incident
    {
        public int Id { get; set; }

        // Incident settings
        [Display(Name = "Prio.")]
        public int? IncidentPriorityId { get; set; }
        [Display(Name = "Priority")]
        [ForeignKey("IncidentPriorityId")]
        public IncidentPriority IncidentPriority { get; set; }

        [Display(Name = "Status")]
        public int? IncidentStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("IncidentStatusId")]
        public IncidentStatus IncidentStatus { get; set; }

        [Display(Name = "Type")]
        public int? IncidentTypeId { get; set; }
        [Display(Name = "Type")]
        [ForeignKey("IncidentTypeId")]
        public IncidentType IncidentType { get; set; }

        //Incident orgin

        [Display(Name = "INC#")]
        public string IncidentNumber { get; set; }

        [Display(Name = "Created")]
        public DateTime? Created { get; set; }

        [Display(Name = "Creator")]
        public int? PersonId { get; set; }
        [Display(Name = "Creator")]
        [ForeignKey("PersonId")]
        public Person Creator { get; set; }

        //Incident Location
        [Display(Name = "Site")]
        public int? SiteId { get; set; }
        [Display(Name = "Site")]
        [ForeignKey("SiteId")]
        public Site Site { get; set; }

        //Incident Handling
        [Display(Name = "Received")]
        public DateTime? Received { get; set; }

        [Display(Name = "Receiver")]
        public int? PersonId1 { get; set; }
        [Display(Name = "Receiver")]
        [ForeignKey("PersonId1")]
        public Person Receiver { get; set; }

        // Scheduling and assignment
        [Display(Name = "FE Scheduled")]
        public DateTime? FEScheduled { get; set; }

        [Display(Name = "FE Assigned")]
        public int? PersonId2 { get; set; }
        [Display(Name = "FE Assigned")]
        [ForeignKey("PersonId2")]
        public Person FEAssigned { get; set; }

        //Incident Description
        [Display(Name = "Description")]
        public string Description { get; set; }

        //Incident Logg
        [Display(Name = "FE Enters Site")]
        public DateTime? FEEntersSite { get; set; }

        [Display(Name = "FE Exits Site")]
        public DateTime? FEEExitsSite { get; set; }

        [Display(Name = "Logg")]
        public string Logg { get; set; }

        //Incident Resolution
        [Display(Name = "Resolved")]
        public DateTime? IssueResolved { get; set; }


        [Display(Name = "Resolution")]
        public string Resolution { get; set; }

        // PO (Purchase Order)

        [Display(Name = "PO #")]
        public int? PurchaseOrderId { get; set; }
        [Display(Name = "PO #")]
        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder PurchaseOrder { get; set; }

        // Concatinations 

        [Display(Name = "Inc# and Description")]
        public string NumberDescription { get { return string.Format("{0} {1} ", IncidentNumber, Description); } }

        //Reporting to accounting
        //When Status = Resolved then build an IncidentReport !

        //Incident
        [Display(Name = "Mtrl List")]
        public int? MtrlListId { get; set; }
        [Display(Name = "Mtrl List")]
        [ForeignKey("MtrlListId")]
        public MtrlList MtrlList { get; set; }
    }
}