using Consultorio.Infrastructura.Interfaces.Repository;
using Consultorio.Infrastructura.Context;
using Consultorio.Infrastructura.Models;
using Consultorio.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Infrastructura.Repositories
{
    public class ConsultationRepository : IConsultationRepository
    {
        private readonly ConsultorioDbContext _db;

        public ConsultationRepository(ConsultorioDbContext db)
        {
            _db = db;
        }

        public async Task Add(Consultation consultation)
        {
            var nConsultation = new ConsultationModel
            {
                PatientId = consultation.PatientId,
                DoctorId = consultation.DoctorId,
                ConsultationDate = consultation.ConsultationDate,
                Reason = consultation.Reason,
                Diagnosis = consultation.Diagnosis,
                Notes = consultation.Notes,
                Id = consultation.Id
            };
            await _db.Consultations.AddAsync(nConsultation);
            await _db.SaveChangesAsync();
            return;
        }

        public async Task Delete(int id)
        {
            var consultation = await _db.Consultations.FindAsync(id);
            if (consultation != null)
            {
                _db.Consultations.Remove(consultation);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Consultation>> GetAll()
        {
            var consultations = await _db.Consultations.AsNoTracking().ToListAsync();
            return consultations.Select(c => new Consultation
            {
                PatientId = c.PatientId,
                DoctorId = c.DoctorId,
                ConsultationDate = c.ConsultationDate,
                Reason = c.Reason,
                Diagnosis = c.Diagnosis,
                Notes = c.Notes,
                Id = c.Id
            });
        }

        public async Task<Consultation> GetById(int id)
        {
            var consultation = await _db.Consultations.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            if (consultation == null)
            {
                return null;
            }
            return new Consultation
            {
                PatientId = consultation.PatientId,
                DoctorId = consultation.DoctorId,
                ConsultationDate = consultation.ConsultationDate,
                Reason = consultation.Reason,
                Diagnosis = consultation.Diagnosis,
                Notes = consultation.Notes,
                Id = consultation.Id
            };
        }

        public async Task Update(int id, Consultation consultation)
        {
            var existingConsultation = await _db.Consultations.FindAsync(id);
            if (existingConsultation != null)
            {
                existingConsultation.PatientId = consultation.PatientId;
                existingConsultation.DoctorId = consultation.DoctorId;
                existingConsultation.ConsultationDate = consultation.ConsultationDate;
                existingConsultation.Reason = consultation.Reason;
                existingConsultation.Diagnosis = consultation.Diagnosis;
                existingConsultation.Notes = consultation.Notes;

                await _db.SaveChangesAsync();
            }
        }
    }
}
