using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIProject.Models
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();
        public List<CityDto> Cities { get; set; }
        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id=1,
                    Name="New York",
                    Description="The one with the big park"
                },
                new CityDto()
                {
                    Id=2,
                    Name="Gondia",
                    Description="Behind Saheed Zamya timya"
                }
            };
        }
    }
}
