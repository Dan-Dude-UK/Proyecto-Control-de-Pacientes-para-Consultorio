using Consultorio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Application.Interfaces.Repository
{
    public interface IPrescriptionRepository
    {
        public Task<IEnumerable<Prescription>> GetAll();

        public Task Add(Prescription prescription);

        public Task Update(int id, Prescription prescription);

        public Task Delete(int id);
        public Task<Prescription> GetById(int id);
    }
}
