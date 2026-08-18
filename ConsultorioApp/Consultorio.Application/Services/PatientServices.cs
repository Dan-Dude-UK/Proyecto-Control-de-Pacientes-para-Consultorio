using Consultorio.Application.Dtos.DtoPatient;
using Consultorio.Application.Interfaces.Repository;
using Consultorio.Application.Interfaces.Service;
using Consultorio.Infrastructura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Application.Services
{
    public class PatientServices(IPatientRepository _repo) : IPatientServices
    {
        public async Task Add(CreatePatientDto patient)
        {
            var nPatient = new Patient
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Age = patient.Age,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                RegistrationDate = patient.RegistrationDate,
                BloodType = patient.BloodType,
                MedicalHistory = patient.MedicalHistory
            };
            await _repo.Add(nPatient);
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<IEnumerable<ReadPatientDto>> GetAll()
        {
            var patients = await _repo.GetAll();
            return patients.Select(p => new ReadPatientDto
            {
                id = p.id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Age = p.Age,
                Email = p.Email,
                PhoneNumber = p.PhoneNumber,
                BloodType = p.BloodType
            });
        }

        public async Task<ReadPatientDto> GetById(int id)
        {
            var patient = await _repo.GetById(id);
            if (patient == null)
            {
                return null;
            }
            return new ReadPatientDto
            {
                id = patient.id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Age = patient.Age,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                BloodType = patient.BloodType
            };
        }

        public async Task Update(int id, CreatePatientDto patient)
        {
            var nPatient = new Patient
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Age = patient.Age,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                RegistrationDate = patient.RegistrationDate,
                BloodType = patient.BloodType,
                MedicalHistory = patient.MedicalHistory
            };

            await _repo.Update(id, nPatient);
        }
    }
}
