using Consultorio.Infrastructura.Interfaces.Repository;
using Consultorio.Infrastructura.Models;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController(IDoctorRepository _repo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetAllDoctors()
        {
            var doctors = await _repo.GetAllDoctor();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctorById(int id)
        {
            var doctor = await _repo.GetDoctorById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        [HttpPost]
        public async Task<ActionResult> AddDoctor(Doctor doctor)
        {
            await _repo.AddDoctor(doctor);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDoctor(int id, Doctor doctor)
        {
            await _repo.UpdateDoctor(id, doctor);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            await _repo.DeleteDoctor(id);
            return Ok();
        }
    }
}
