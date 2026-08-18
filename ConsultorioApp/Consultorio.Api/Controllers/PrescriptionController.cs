using Consultorio.Infrastructura.Interfaces.Repository;
using Consultorio.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionController(IPrescriptionRepository _repo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prescription>>> GetAllPrescriptions()
        {
            var prescriptions = await _repo.GetAll();
            return Ok(prescriptions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Prescription>> GetPrescriptionById(int id)
        {
            var prescription = await _repo.GetById(id);
            if (prescription == null)
            {
                return NotFound();
            }
            return Ok(prescription);
        }

        [HttpPost]
        public async Task<ActionResult> AddPrescription(Prescription prescription)
        {
            await _repo.Add(prescription);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePrescription(int id, Prescription prescription)
        {
            await _repo.Update(id, prescription);
            if (prescription == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePrescription(int id)
        {
            await _repo.Delete(id);
            return Ok();
        }
    }
}
