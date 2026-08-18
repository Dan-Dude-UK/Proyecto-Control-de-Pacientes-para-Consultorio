using Consultorio.Infrastructura.Interfaces.Repository;
using Consultorio.Infrastructura.Context;
using Consultorio.Infrastructura.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Infrastructura.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ConsultorioDbContext _db;

        public PatientRepository(ConsultorioDbContext db)
        {
            _db = db;
        }

        public async Task Add(Patient patient)
        {
            var nPatient = new PatientModel
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Age = patient.Age,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                RegistrationDate = patient.RegistrationDate,
                BloodType = patient.BloodType,
                MedicalHistory = patient.MedicalHistory,
                Active = patient.Active,
                id = patient.id
            };
            await _db.Patients.AddAsync(nPatient);
            await _db.SaveChangesAsync();
            return;
        }

        public async Task Delete(int id)
        {
            var patient = await _db.Patients.FindAsync(id);
            if (patient != null)
            {
                _db.Patients.Remove(patient);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            var patients = await _db.Patients.AsNoTracking().ToListAsync();
            return patients.Select(p => new Patient
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                Age = p.Age,
                Email = p.Email,
                PhoneNumber = p.PhoneNumber,
                RegistrationDate = p.RegistrationDate,
                BloodType = p.BloodType,
                MedicalHistory = p.MedicalHistory,
                Active = p.Active,
                id = p.id
            });
        }

        public async Task<Patient> GetById(int id)
        {
            var patient = await _db.Patients.AsNoTracking().FirstOrDefaultAsync(p => p.id == id);
            if (patient == null)
            {
                return null;
            }
            return new Patient
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Age = patient.Age,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                RegistrationDate = patient.RegistrationDate,
                BloodType = patient.BloodType,
                MedicalHistory = patient.MedicalHistory,
                Active = patient.Active,
                id = patient.id
            };
        }

        public async Task Update(int id, Patient patient)
        {
            var existingPatient = await _db.Patients.FindAsync(id);
            if (existingPatient != null)
            {
                existingPatient.FirstName = patient.FirstName;
                existingPatient.LastName = patient.LastName;
                existingPatient.Age = patient.Age;
                existingPatient.Email = patient.Email;
                existingPatient.PhoneNumber = patient.PhoneNumber;
                existingPatient.RegistrationDate = patient.RegistrationDate;
                existingPatient.BloodType = patient.BloodType;
                existingPatient.MedicalHistory = patient.MedicalHistory;
                existingPatient.Active = patient.Active;

                await _db.SaveChangesAsync();
            }
        }
    }
}
