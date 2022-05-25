using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Repositories
{
    public interface ILocationRepository
    {
        Task<IEnumerable<Location>> GetAllLocations();
        Task<IEnumerable<Location>> GetLocationById(string id);
        Task<IEnumerable<Location>> GetLocationsByCity(string city);
        Task<IEnumerable<Location>> CreateLocation(string id, IEnumerable<Location> location);
    }
}
