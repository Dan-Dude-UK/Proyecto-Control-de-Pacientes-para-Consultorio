using Consultorio.Application.Dtos.DtoConsultation;
using Consultorio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Application.Interfaces.Service
{
    public interface IConsultationServices
    {
        public Task<IEnumerable<ReadConsultationDto>> GetAll();

        public Task Add(CreateConsultationDto consultation);

        public Task Update(int id, CreateConsultationDto consultation);

        public Task Delete(int id);
        public Task<ReadConsultationDto> GetById(int id);
    }
}
