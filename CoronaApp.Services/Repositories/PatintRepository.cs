using CoronaApp.Services.Models;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Sinks.File;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Formatting;
using Serilog.Events;

namespace CoronaApp.Services.Repositories
{
    public class PatintRepository : IPatientRepository
    {
        private readonly List<Patient> _patients;

        public PatintRepository(IDB patientContext)
        {
            _patients = patientContext.Patients;

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console(LogEventLevel.Information)
            .WriteTo.File("logs/logs.txt", rollingInterval: RollingInterval.Day, shared:true)
            .CreateLogger();
        }

        public async Task<Patient> CreatePatientAsync(Patient patient)
        {
            bool validId = _patients.Find(p => p.PatientId == patient.PatientId) == null;
            if (validId)
            {
                _patients.Add(patient);
                Log.Information("Patients/POST Patient Added Successfully");
                JsonHelper.WriteObjectToJsonFile(_patients, "data.json");
            }
            else
            {
                Log.Warning("Patients/POST Failed to add patient: The id must be unique");
                patient = null;
            }
            return await Task.FromResult(patient);
        }

        public async Task<Patient> DeletePatientAsync(string id)
        {
            Patient patientToDelete = _patients?.Find(patient => patient.PatientId == id);
            _patients.RemoveAll(patient => patient.PatientId == id); 
            JsonHelper.WriteObjectToJsonFile(_patients, "data.json");
            bool deleted = patientToDelete != null;
            string massege = deleted ? "Patients/DELETE Patient {0} deleted successfully" : "Patients/DELETE Id {0} have not been found";
            LogEventLevel logLevel = deleted ? LogEventLevel.Information : LogEventLevel.Warning;
            Log.Write(logLevel, massege, id);
            return await Task.FromResult(patientToDelete);
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            Log.Information("Patients/GET Get all patients...");
            return await Task.FromResult(_patients);
        }

        public async Task<Patient> GetPatientByIdAsync(string id)
        {
            Patient patientToShow = _patients.Where(patient => patient.PatientId == id).FirstOrDefault();
            bool found = patientToShow != null;
            string massege = found ? "Patients/GET/{0} Patient {0} have gotten successfully" : "Patients/GET/{0} Id {0} have not been found";
            LogEventLevel logLevel = found ? LogEventLevel.Information : LogEventLevel.Warning;
            Log.Write(logLevel, massege, id);
            return await Task.FromResult(patientToShow);
        }

        public async Task<IEnumerable<Patient>> GetPatientByNameAsync(string name)
        {
            IEnumerable<Patient> patientsToShow = _patients.Where(patient => patient.Name == name).ToList();
            bool found = patientsToShow.Count() > 0;
            string massege = found ? "Patients/GET/{0} Patients named {0} have gotten successfully" : "Patients/GET/{0} Name {0} have not been found";
            LogEventLevel logLevel = found ? LogEventLevel.Information : LogEventLevel.Warning;
            Log.Write(logLevel, massege, name);
            return await Task.FromResult(patientsToShow);
        }
    }
}
