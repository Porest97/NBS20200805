using NBS.ImageUpload.Models;
using NBS.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.ImageUpload.ViewModels
{
    public class ImagesIncidentViewModel
    {
        public Incident Incident { get; set; }

        public List<ImageModel> Images { get; internal set; }

        public List<Incident> Incidents { get; internal set; }


    }
}
