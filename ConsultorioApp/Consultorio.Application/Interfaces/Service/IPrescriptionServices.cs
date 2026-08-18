using Consultorio.Application.Dtos.DtoPrescription;
using Consultorio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Application.Interfaces.Service
{
    public interface IPrescriptionServices
    {
        public Task<IEnumerable<ReadPrescriptionDto>> GetAll();

        public Task Add(CreatePrescriptionDto prescription);

        public Task Update(int id, CreatePrescriptionDto prescription);

        public Task Delete(int id);
        public Task<ReadPrescriptionDto> GetById(int id);
    }
}
