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
        Task<IEnumerable<Location>> GetAllLocationsAsync();
        Task<IEnumerable<Location>> GetLocationByIdAsync(string id);
        Task<IEnumerable<Location>> GetLocationsByCityAsync(string city);
        Task<IEnumerable<Location>> CreateLocationAsync(string id, IEnumerable<Location> location);


        //Task<IEnumerable<Location>> Get(LocationSearch locationSearch);
        //Task<IEnumerable<Location>> GetLocationById(LocationSearch locationSearch, string id);
        //Task<IEnumerable<Location>> GetLocationsByCity(LocationSearch locationSearch, string city);
        //Task<IEnumerable<Location>> CreateLocation(LocationSearch locationSearch, string id, IEnumerable<Location> location);
    }
}
