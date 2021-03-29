using Microsoft.AspNetCore.Mvc;
using SampleAPIProject.Models;
using SampleAPIProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIProject.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController: ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository ??
                throw new ArgumentNullException(nameof(cityInfoRepository));
           
        }



        [HttpGet]
        public IActionResult GetCities()
        {
            var cityEntities = _cityInfoRepository.GetCities();

            var results = new List<CityWithoutPointsOfInterestDto>();

            foreach (var cityEntity in cityEntities)
            {
                results.Add(new CityWithoutPointsOfInterestDto()
                {
                    Id = cityEntity.Id,
                    Description = cityEntity.Description,
                    Name = cityEntity.Name
                });

            }
            return Ok(results);
        }
        [HttpGet("{id}")]
        public IActionResult GetCity(int id,bool includePointOfInterst=false)
        {
            var city = _cityInfoRepository.GetCity(id, includePointOfInterst);
            if (city == null)
                return NotFound();
            if (includePointOfInterst)
            {
                var cityResult = new CityDto()
                {
                    Id = city.Id,
                    Name = city.Name,
                    Description = city.Description
                };
                foreach(var poi in city.PointsOfInterest)
                {
                    cityResult.PointOfInterests.Add(
                      new PointOfInterestDto()
                      {
                          Id = poi.Id,
                          Name = poi.Name,
                          Description = poi.Description
                      });
                }
                return Ok(cityResult);

            }
            var cityWithoutPointsOfInterestsResult =
                new CityWithoutPointsOfInterestDto()
                {
                    Id = city.Id,
                    Description = city.Description,
                    Name = city.Name
                };
            return Ok(cityWithoutPointsOfInterestsResult);
        }

    }
}
