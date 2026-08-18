using Consultorio.Infrastructura.Interfaces.Repository;
using Consultorio.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultationController(IConsultationRepository _repo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consultation>>> GetAllConsultations()
        {
            var consultations = await _repo.GetAll();
            return Ok(consultations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Consultation>> GetConsultationById(int id)
        {
            var consultation = await _repo.GetById(id);
            if (consultation == null)
            {
                return NotFound();
            }
            return Ok(consultation);
        }

        [HttpPost]
        public async Task<ActionResult> AddConsultation(Consultation consultation)
        {
            await _repo.Add(consultation);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateConsultation(int id, Consultation consultation)
        {
            await _repo.Update(id, consultation);
            if (consultation == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteConsultation(int id)
        {
            await _repo.Delete(id);
            return Ok();
        }
    }
}
