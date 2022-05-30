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
    public class LocationsController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        public LocationsController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<CoronaApp.Services.Models.Location>> Get()
        {
            return await _locationRepository.GetAllLocationsAsync();
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<CoronaApp.Services.Models.Location>> Get([FromRoute]string id)
        {
            return await _locationRepository.GetLocationByIdAsync(id);
        }

        [HttpPost("{id}")]
        public async Task<CreatedResult> Post([FromRoute]string id, [FromBody] List<CoronaApp.Services.Models.Location> location)
        {
            Task<IEnumerable<CoronaApp.Services.Models.Location>> newLocations = _locationRepository.CreateLocationAsync(id, location);
            return await Task.FromResult(Created(id, location));
        }

        [HttpGet("city/{city}")]
        public async Task<IEnumerable<CoronaApp.Services.Models.Location>> GetByCity([FromRoute]string city)
        {
            return await _locationRepository.GetLocationsByCityAsync(city);
        }
    }
}
