using CoronaApp.Services.Repositories;
using CoronaApp.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Locations.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ILogger _logger;
        public LocationController(ILocationRepository locationRepository, ILogger logger)
        {
            _locationRepository = locationRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IEnumerable<Location>> Get()
        {
            return await _locationRepository.GetAllLocations();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<Location>> Get(string id)
        {
            return await _locationRepository.GetLocationById(id);
        }

        [HttpPost("{id}")]
        public async Task<CreatedResult> Post(string id, [FromBody] List<Location> location)
        {
            Task<IEnumerable<Location>> newLocations = _locationRepository.CreateLocation(id, location);
            return await Task.FromResult(Created(id, location));
        }

        [HttpGet("city/{city}")]
        public async Task<IEnumerable<Location>> GetByCity(string city)
        {
            return await _locationRepository.GetLocationsByCity(city);
        }
    }
}
