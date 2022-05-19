using Lesson1Location.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        public List<Patient> Patients { get; set; }
        public LocationRepository()
        {
            using (StreamReader r = new StreamReader("data.json"))
            {
                string json = r.ReadToEnd();
                Patients = JsonSerializer.Deserialize<List<Patient>>(json);
            }
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return Patients.SelectMany(patient => patient.Locations).ToList();
        }

        public IEnumerable<Location> GetLocationById(string id)
        {
            return Patients.Where(patient => patient.PatientId == id).SingleOrDefault().Locations;
        }

        public IEnumerable<Location> GetLocationsByCity(string city)
        {
            return Patients.SelectMany(patient => patient.Locations).Where(location => location.City == city).ToList();
        }

        public IEnumerable<Location> CreateLocation(string id, IEnumerable<Location> locations)
        {
            Patients.Where(patient => patient.PatientId == id).SingleOrDefault().Locations.AddRange(locations);
            string jsonString = JsonSerializer.Serialize(Patients, new JsonSerializerOptions() { WriteIndented = true });
            using (StreamWriter outputFile = new StreamWriter("data.json"))
            {
                outputFile.WriteLine(jsonString);
            }
            return locations;
        }
    }
}
