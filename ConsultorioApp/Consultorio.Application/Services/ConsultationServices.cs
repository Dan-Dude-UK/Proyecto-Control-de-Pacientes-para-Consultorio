using Consultorio.Application.Dtos.DtoConsultation;
using Consultorio.Application.Interfaces.Repository;
using Consultorio.Application.Interfaces.Service;
using Consultorio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Application.Services
{
    public class ConsultationServices(IConsultationRepository _repo) : IConsultationServices
    {
        public async Task Add(CreateConsultationDto consultation)
        {
            var nConsultation = new Consultation
            {
                PatientId = consultation.PatientId,
                DoctorId = consultation.DoctorId,
                ConsultationDate = consultation.ConsultationDate,
                Reason = consultation.Reason,
                Diagnosis = consultation.Diagnosis,
                Notes = consultation.Notes
            };
            await _repo.Add(nConsultation);
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<IEnumerable<ReadConsultationDto>> GetAll()
        {
            var consultations = await _repo.GetAll();
            return consultations.Select(c => new ReadConsultationDto
            {
                Id = c.Id,
                PatientId = c.PatientId,
                DoctorId = c.DoctorId,
                ConsultationDate = c.ConsultationDate,
                Reason = c.Reason,
                Diagnosis = c.Diagnosis
            });
        }

        public async Task<ReadConsultationDto> GetById(int id)
        {
            var consultation = await _repo.GetById(id);
            if (consultation == null)
            {
                return null;
            }
            return new ReadConsultationDto
            {
                Id = consultation.Id,
                PatientId = consultation.PatientId,
                DoctorId = consultation.DoctorId,
                ConsultationDate = consultation.ConsultationDate,
                Reason = consultation.Reason,
                Diagnosis = consultation.Diagnosis
            };
        }

        public async Task Update(int id, CreateConsultationDto consultation)
        {
            var nConsultation = new Consultation
            {
                PatientId = consultation.PatientId,
                DoctorId = consultation.DoctorId,
                ConsultationDate = consultation.ConsultationDate,
                Reason = consultation.Reason,
                Diagnosis = consultation.Diagnosis,
                Notes = consultation.Notes
            };
            await _repo.Update(id, nConsultation);
        }
    }
}
