using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.Models.DataModels
{
    public class TimeLogStatus
    {
        public int Id { get; set; }

        [Display(Name = "Status")]
        public string TimeLogStatusName { get; set; }
    }
}
