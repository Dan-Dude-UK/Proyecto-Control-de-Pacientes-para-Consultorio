using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Application.Dtos.DtoPrescription
{
    public class ReadPrescriptionDto
    {
        public int Id { get; set; }
        public int ConsultationId { get; set; }
        public int PatientId { get; set; }
        public string Medication { get; set; }
        public string Dosage { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
