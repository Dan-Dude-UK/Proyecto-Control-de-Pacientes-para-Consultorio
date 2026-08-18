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
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly ConsultorioDbContext _db;

        public PrescriptionRepository(ConsultorioDbContext db)
        {
            _db = db;
        }

        public async Task Add(Prescription prescription)
        {
            var nPrescription = new PrescriptionModel
            {
                ConsultationId = prescription.ConsultationId,
                PatientId = prescription.PatientId,
                Medication = prescription.Medication,
                Dosage = prescription.Dosage,
                Instructions = prescription.Instructions,
                IssueDate = prescription.IssueDate,
                Id = prescription.Id
            };
            await _db.Prescriptions.AddAsync(nPrescription);
            await _db.SaveChangesAsync();
            return;
        }

        public async Task Delete(int id)
        {
            var prescription = await _db.Prescriptions.FindAsync(id);
            if (prescription != null)
            {
                _db.Prescriptions.Remove(prescription);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Prescription>> GetAll()
        {
            var prescriptions = await _db.Prescriptions.AsNoTracking().ToListAsync();
            return prescriptions.Select(p => new Prescription
            {
                ConsultationId = p.ConsultationId,
                PatientId = p.PatientId,
                Medication = p.Medication,
                Dosage = p.Dosage,
                Instructions = p.Instructions,
                IssueDate = p.IssueDate,
                Id = p.Id
            });
        }

        public async Task<Prescription> GetById(int id)
        {
            var prescription = await _db.Prescriptions.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
            if (prescription == null)
            {
                return null;
            }
            return new Prescription
            {
                ConsultationId = prescription.ConsultationId,
                PatientId = prescription.PatientId,
                Medication = prescription.Medication,
                Dosage = prescription.Dosage,
                Instructions = prescription.Instructions,
                IssueDate = prescription.IssueDate,
                Id = prescription.Id
            };
        }

        public async Task Update(int id, Prescription prescription)
        {
            var existingPrescription = await _db.Prescriptions.FindAsync(id);
            if (existingPrescription != null)
            {
                existingPrescription.ConsultationId = prescription.ConsultationId;
                existingPrescription.PatientId = prescription.PatientId;
                existingPrescription.Medication = prescription.Medication;
                existingPrescription.Dosage = prescription.Dosage;
                existingPrescription.Instructions = prescription.Instructions;
                existingPrescription.IssueDate = prescription.IssueDate;

                await _db.SaveChangesAsync();
            }
        }
    }
}
