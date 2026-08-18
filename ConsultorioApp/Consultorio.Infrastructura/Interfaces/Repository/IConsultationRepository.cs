using Consultorio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Infrastructura.Interfaces.Repository
{
    public interface IConsultationRepository
    {
        public Task<IEnumerable<Consultation>> GetAll();

        public Task Add(Consultation consultation);

        public Task Update(int id, Consultation consultation);

        public Task Delete(int id);
        public Task<Consultation> GetById(int id);
    }
}
