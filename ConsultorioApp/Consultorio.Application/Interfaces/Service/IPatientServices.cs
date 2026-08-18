using Consultorio.Application.Dtos.DtoPatient;
using Consultorio.Infrastructura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Application.Interfaces.Service
{
    public interface IPatientServices
    {
        public Task<IEnumerable<ReadPatientDto>> GetAll();

        public Task Add(CreatePatientDto patient);

        public Task Update(int id, CreatePatientDto patient);

        public Task Delete(int id);
        public Task<ReadPatientDto> GetById(int id);
    }
}
