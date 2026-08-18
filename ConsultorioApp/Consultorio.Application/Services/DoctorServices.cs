using Consultorio.Application.Dtos.DtoDoctor;
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
    public class DoctorServices(IDoctorRepository _repo) : IDoctorServices
    {
        public async Task AddDoctor(CreateDoctorDto doctor)
        {
            var nDoctor = new Doctor
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Age = doctor.Age,
                Email = doctor.Email,
                PhoneNumber = doctor.PhoneNumber,
                Specialty = doctor.Specialty,
                LicenseNumber = doctor.LicenseNumber
            };
            await _repo.AddDoctor(nDoctor);
        }

        public async Task DeleteDoctor(int id)
        {
            await _repo.DeleteDoctor(id);
        }

        public async Task<IEnumerable<ReadDoctorDto>> GetAllDoctor()
        {
            var doctors = await _repo.GetAllDoctor();
            return doctors.Select(d => new ReadDoctorDto
            {
                id = d.id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                Age = d.Age,
                Email = d.Email,
                Specialty = d.Specialty
            });
        }

        public async Task<ReadDoctorDto> GetDoctorById(int id)
        {
            var doctor = await _repo.GetDoctorById(id);
            if (doctor == null)
            {
                return null;
            }
            return new ReadDoctorDto
            {
                id = doctor.id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Age = doctor.Age,
                Email = doctor.Email,
                Specialty = doctor.Specialty
            };
        }

        public async Task UpdateDoctor(int id, CreateDoctorDto doctor)
        {
            var nDoctor = new Doctor
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Age = doctor.Age,
                Email = doctor.Email,
                PhoneNumber = doctor.PhoneNumber,
                Specialty = doctor.Specialty,
                LicenseNumber = doctor.LicenseNumber
            };
            await _repo.UpdateDoctor(id, nDoctor);
        }
    }
}
