using CoronaApp.Services.Models;
using Serilog;
using Serilog.Events;
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
            _patients = patientContext.Patients;
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console(LogEventLevel.Information)
            .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day, shared: true)
            .CreateLogger();
        }

        public async Task<IEnumerable<Location>> GetAllLocationsAsync()
        {
            Log.Information("Locations/GET Get all locations...");
            return await Task.FromResult(_patients.SelectMany(patient => patient.Locations).ToList());
        }

        public async Task<IEnumerable<Location>> GetLocationByIdAsync(string id)
        {
            return await Task.FromResult(_patients.Where(patient => patient.PatientId == id).FirstOrDefault().Locations);
        }

        public async Task<IEnumerable<Location>> GetLocationsByCityAsync(string city)
        {
            IEnumerable<Location> allLocations = _patients.SelectMany(patient => patient.Locations);
            return await Task.FromResult(allLocations.Where(location => location.City == city).ToList());
        }

        async public Task<IEnumerable<Location>> CreateLocationAsync(string id, IEnumerable<Location> locations)
        {
            _patients.Where(patient => patient.PatientId == id).SingleOrDefault()?.Locations.AddRange(locations);
            JsonHelper.WriteObjectToJsonFile(_patients, "data.json");
            return await Task.FromResult(locations);
        }

    }
}
