using Consultorio.Application.Dtos.DtoPrescription;
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
    public class PrescriptionServices(IPrescriptionRepository _repo) : IPrescriptionServices
    {
        public async Task Add(CreatePrescriptionDto prescription)
        {
            var nPrescription = new Prescription
            {
                ConsultationId = prescription.ConsultationId,
                PatientId = prescription.PatientId,
                Medication = prescription.Medication,
                Dosage = prescription.Dosage,
                Instructions = prescription.Instructions,
                IssueDate = prescription.IssueDate
            };
            await _repo.Add(nPrescription);
        }

        public async Task Delete(int id)
        {
            await _repo.Delete(id);
        }

        public async Task<IEnumerable<ReadPrescriptionDto>> GetAll()
        {
            var prescriptions = await _repo.GetAll();
            return prescriptions.Select(p => new ReadPrescriptionDto
            {
                Id = p.Id,
                ConsultationId = p.ConsultationId,
                PatientId = p.PatientId,
                Medication = p.Medication,
                Dosage = p.Dosage,
                IssueDate = p.IssueDate
            });
        }

        public async Task<ReadPrescriptionDto> GetById(int id)
        {
            var prescription = await _repo.GetById(id);
            if (prescription == null)
            {
                return null;
            }
            return new ReadPrescriptionDto
            {
                Id = prescription.Id,
                ConsultationId = prescription.ConsultationId,
                PatientId = prescription.PatientId,
                Medication = prescription.Medication,
                Dosage = prescription.Dosage,
                IssueDate = prescription.IssueDate
            };
        }

        public async Task Update(int id, CreatePrescriptionDto prescription)
        {
            var nPrescription = new Prescription
            {
                ConsultationId = prescription.ConsultationId,
                PatientId = prescription.PatientId,
                Medication = prescription.Medication,
                Dosage = prescription.Dosage,
                Instructions = prescription.Instructions,
                IssueDate = prescription.IssueDate
            };
            await _repo.Update(id, nPrescription);
        }
    }
}
