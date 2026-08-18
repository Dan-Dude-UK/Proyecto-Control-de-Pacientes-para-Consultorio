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
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ConsultorioDbContext _db;

        public DoctorRepository(ConsultorioDbContext db)
        {
            _db = db;
        }

        public async Task AddDoctor(Doctor doctor)
        {
            var nDoctor = new DoctorModel
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Specialty = doctor.Specialty,
                LicenseNumber = doctor.LicenseNumber,
                Active = doctor.Active,
                Email = doctor.Email,
                PhoneNumber = doctor.PhoneNumber,
                Age = doctor.Age,
                id = doctor.id
            };
            await _db.Doctors.AddAsync(nDoctor);
            await _db.SaveChangesAsync();
            return;
        }

        public async Task DeleteDoctor(int id)
        {
            var doctor = await _db.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _db.Doctors.Remove(doctor);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctor()
        {
            var doctors = await _db.Doctors.AsNoTracking().ToListAsync();
            return doctors.Select(d => new Doctor
            {
                FirstName = d.FirstName,
                LastName = d.LastName,
                Specialty = d.Specialty,
                LicenseNumber = d.LicenseNumber,
                Active = d.Active,
                Email = d.Email,
                PhoneNumber = d.PhoneNumber,
                Age = d.Age,
                id = d.id
            });
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            var doctor = await _db.Doctors.AsNoTracking().FirstOrDefaultAsync(d => d.id == id);
            if (doctor == null)
            {
                return null;
            }
            return new Doctor
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Specialty = doctor.Specialty,
                LicenseNumber = doctor.LicenseNumber,
                Active = doctor.Active,
                Email = doctor.Email,
                PhoneNumber = doctor.PhoneNumber,
                Age = doctor.Age,
                id = doctor.id
            };
        }

        public async Task UpdateDoctor(int id, Doctor doctor)
        {
            var existingDoctor = await _db.Doctors.FindAsync(id);
            if (existingDoctor != null)
            {
                existingDoctor.FirstName = doctor.FirstName;
                existingDoctor.LastName = doctor.LastName;
                existingDoctor.Specialty = doctor.Specialty;
                existingDoctor.LicenseNumber = doctor.LicenseNumber;
                existingDoctor.Active = doctor.Active;
                existingDoctor.Email = doctor.Email;
                existingDoctor.PhoneNumber = doctor.PhoneNumber;
                existingDoctor.Age = doctor.Age;

                await _db.SaveChangesAsync();
            }
        }
    }
}
