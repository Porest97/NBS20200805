using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.Models.DataModels
{
    public class Status
    {
        public int Id { get; set; }

        [Display(Name="Status")]
        public string StatusName { get; set; }
        
        [Display(Name = "Beskrivning")]
        public string StatusDescription { get; set; }
        
        [Display(Name = "Act")]
        public bool Action { get; set; }
    }
}
