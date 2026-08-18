using Consultorio.Infrastructura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Infrastructura.Interfaces.Repository
{
    public interface IPatientRepository
    {
        public Task<IEnumerable<Patient>> GetAll();

        public Task Add(Patient patient);

        public Task Update(int id, Patient patient);

        public Task Delete(int id);
        public Task<Patient> GetById(int id);
    }
}
