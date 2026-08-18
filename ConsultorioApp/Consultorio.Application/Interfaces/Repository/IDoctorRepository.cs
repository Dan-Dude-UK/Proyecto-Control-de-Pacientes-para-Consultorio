using Consultorio.Infrastructura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Application.Interfaces.Repository
{
    public interface IDoctorRepository
    {
        public Task<IEnumerable<Doctor>> GetAllDoctor();

        public Task AddDoctor(Doctor doctor);

        public Task UpdateDoctor(int id, Doctor doctor);

        public Task DeleteDoctor(int id);
        public Task<Doctor> GetDoctorById(int id);
    }
}
