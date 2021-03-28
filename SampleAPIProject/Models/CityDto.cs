﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIProject.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }
        public ICollection<PointOfInterestDto> PointOfInterests { get; set; }
             = new List<PointOfInterestDto>();
        public int NumberOfPointOfInterest
        {
            get
            {
                return PointOfInterests.Count;
            }
        }
    }
}
