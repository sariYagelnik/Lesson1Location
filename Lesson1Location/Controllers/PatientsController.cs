using CoronaApp.Services.Models;
using CoronaApp.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Location.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientRepository _patientRepository;

        public PatientsController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Patient>> Get()
        {
            return await _patientRepository.GetAllPatientsAsync();
        }

        [HttpGet("{id}")]
        public async Task<Patient> Get([FromRoute]string id)
        {
            return await _patientRepository.GetPatientByIdAsync(id);
        }

        [HttpGet("name/{name}")]
        public async Task<IEnumerable<Patient>> GetByName([FromRoute]string name)
        {
            return await _patientRepository.GetPatientByNameAsync(name);
        }

        [HttpDelete("{id}")]
        public async Task<Patient> Delete([FromRoute]string id)
        {
            return await _patientRepository.DeletePatientAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Patient patient)
        {
            Patient createdPatient =await _patientRepository.CreatePatientAsync(patient);
            bool isCreated = createdPatient != null;
            ActionResult result = isCreated ? Created("", patient) : ValidationProblem(detail: "The PatientId field's value must be unique");
            return  result;
        }
    }
}
