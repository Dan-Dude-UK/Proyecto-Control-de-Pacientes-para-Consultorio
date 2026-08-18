using Consultorio.Application.Dtos.DtoDoctor;
using Consultorio.Infrastructura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Application.Interfaces.Service
{
    public interface IDoctorServices
    {
        public Task<IEnumerable<ReadDoctorDto>> GetAllDoctor();

        public Task AddDoctor(CreateDoctorDto doctor);

        public Task UpdateDoctor(int id, CreateDoctorDto doctor);

        public Task DeleteDoctor(int id);

        public Task<ReadDoctorDto> GetDoctorById(int id);
    }
}
