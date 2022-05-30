using CoronaApp.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(string id);
        Task<IEnumerable<Patient>> GetPatientByNameAsync(string name);
        Task<Patient> CreatePatientAsync(Patient patient);
        Task<Patient> DeletePatientAsync(string id);

        //Task<IEnumerable<Patient>> GetAllPatients(PatientSearch patientSearch);
        //Task<Patient> GetPatientById(PatientSearch patientSearch, string id);
        //Task<IEnumerable<Patient>> GetPatientByName(PatientSearch patientSearch, string name);
        //Task<Patient> CreatePatient(PatientSearch patientSearch, Patient patient);
        //Task<Patient> DeletePatient(PatientSearch patientSearch, string id);
    }
}
