using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.Models.DataModels
{
    public class SupportRequest
    {
        public int Id { get; set; }

        // The clients company name aka Regus e.t.c !
        [Display(Name = "Client company")]
        public string ClientCompany { get; set; }

        
        // The clients personal contact information !
        [Display(Name = "Client name")]
        public string ClientContact { get; set; }

        [Display(Name = "Email")]
        public string ClientEmail { get; set; }

        [Display(Name = "Phone #")]
        public string ClientPhoneNumber { get; set; }

        // The clients site information !
        [Display(Name = "Client site")]
        public string ClientSite { get; set; }

        [Display(Name = "Site #")]
        public string SiteNumber { get; set; }

        [Display(Name = "Site name")]
        public string SiteName { get; set; }

        [Display(Name = "Area")]
        public string SiteArea { get; set; }


        // Requst Type/Status e.t.c !
        [Display(Name = "Request type")]
        public int? RequestTypeId { get; set; }
        [Display(Name = "Request type")]
        [ForeignKey("RequestTypeId")]
        public RequestType RequestType { get; set; }

        [Display(Name = "Status")]
        public int? RequestStatusId { get; set; }
        [Display(Name = "Status")]
        [ForeignKey("RequestStatusId")]
        public RequestStatus RequestStatus { get; set; }

        [Display(Name = "Prio.")]
        public int? RequestPrioId { get; set; }
        [Display(Name = "Prio.")]
        [ForeignKey("RequestPrioId")]
        public RequestPrio RequestPrio { get; set; }

        [Display(Name = "Posted.")]
        public DateTime? DateTimePosted { get; set; }

        // Request information Description e.t.c !

        [Display(Name = "Description")]
        public string RequestDescription { get; set; }




    }

    public class RequestPrio
    {
        public int Id { get; set; }


        [Display(Name = "Prio.")]
        public string RequestPrioName { get; set; }

        [Display(Name = "Description")]
        public string RequestPrioDescription { get; set; }

    }

    public class RequestStatus
    {
        public int Id { get; set; }


        [Display(Name = "Status")]
        public string RequestStatusName { get; set; }
    }

    public class RequestType
    {
        public int Id { get; set; }


        [Display(Name = "Request type")]
        public string RequestTypeName { get; set; }
    }
}
