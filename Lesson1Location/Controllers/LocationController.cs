using DAL.Repositories;
using Lesson1Location.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lesson1Location.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository; 
        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        [HttpGet]
        public IEnumerable<Models.Location> GetAllLocations()
        {
            return _locationRepository.GetAllLocations();
        }

        [HttpGet("{id}")]
        public IEnumerable<Models.Location> GetLocationsByUserId(string id)
        {
            return _locationRepository.GetLocationById(id);
        }

        [HttpPost("{id}")]
        public ActionResult AddLocationToPatient(string id, [FromBody] List<Models.Location> location)
        {
            IEnumerable<Location> newLocations = _locationRepository.CreateLocation(id, location);
            return CreatedAtAction(nameof(GetAllLocations), new { id= id, newLocations});
        }

        [HttpGet("{city}")]
        public IEnumerable<Models.Location> GetLocationsByCityName(string city)
        {
            return _locationRepository.GetLocationsByCity(city);
        }
    }
}
