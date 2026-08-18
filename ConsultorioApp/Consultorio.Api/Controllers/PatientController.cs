using Consultorio.Infrastructura.Interfaces.Repository;
using Consultorio.Infrastructura.Models;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController(IPatientRepository _repo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAllPatients()
        {
            var patients = await _repo.GetAll();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatientById(int id)
        {
            var patient = await _repo.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public async Task<ActionResult> AddPatient(Patient patient)
        {
            await _repo.Add(patient);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePatient(int id, Patient patient)
        {
            await _repo.Update(id, patient);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            await _repo.Delete(id);
            return Ok();
        }
    }
}
