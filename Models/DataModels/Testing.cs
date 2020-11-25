using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using NBS.Data;

namespace NBS.Models.DataModels
{
    public class Testing
    {
        public int Id { get; set; }

        [Display(Name ="Beskrivning")]
        public string Description { get; set; }

    }
}
