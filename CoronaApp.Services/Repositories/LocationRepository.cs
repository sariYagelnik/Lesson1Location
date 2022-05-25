using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoronaApp.Services.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly List<Patient> _patients;
        public LocationRepository(IDB patientContext)
        {
            _patients =patientContext.Patients;
        }

        public async Task<IEnumerable<Location>> GetAllLocations()
        {
            return await Task.FromResult(_patients.SelectMany(patient => patient.Locations).ToList());
        }

        public async Task<IEnumerable<Location>> GetLocationById(string id)
        {
            return await Task.FromResult(_patients.Where(patient => patient.PatientId == id).SingleOrDefault().Locations);
        }

        public async Task<IEnumerable<Location>> GetLocationsByCity(string city)
        {
            return await Task.FromResult(_patients.SelectMany(patient => patient.Locations).Where(location => location.City == city).ToList());
        }

        async public Task<IEnumerable<Location>> CreateLocation(string id, IEnumerable<Location> locations)
        {
            _patients.Where(patient => patient.PatientId == id).SingleOrDefault().Locations.AddRange(locations);
            string patientContext = JsonSerializer.Serialize(_patients, new JsonSerializerOptions() { WriteIndented = true });
            using (StreamWriter outputFile = new StreamWriter("data.json"))
            {
                outputFile.WriteLine(patientContext);
            }
            return await Task.FromResult(locations);
        }
    }
}
