using Microsoft.AspNetCore.Mvc;
using SampleAPIProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIProject.Controllers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointsofinterest")]

    public class PointOfInterestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPointsofInterest(int cityId)
        {
            var city = CitiesDataStore.Current.Cities
                                     .FirstOrDefault(c => c.Id == cityId);
            if (city == null)
                return NotFound();
            return Ok(city.PointOfInterests);
        }

        [HttpGet("{id}")]
        public IActionResult GetPointofInterest(int cityId,int id)
        {
            var city = CitiesDataStore.Current.Cities
                                     .FirstOrDefault(c => c.Id == cityId);
            if (city == null)
                return NotFound();
            var pointOfInterest = city.PointOfInterests
                                     .FirstOrDefault(p => p.Id == id);
            if (pointOfInterest == null)
                return NotFound();
            return Ok(pointOfInterest);
        }
    }
}
