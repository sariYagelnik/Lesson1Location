using Lesson1Location.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetAllLocations();
        IEnumerable<Location> GetLocationById(string id);
        IEnumerable<Location> GetLocationsByCity(string city);
        IEnumerable<Location> CreateLocation(string id, IEnumerable<Location> location);
    }
}
