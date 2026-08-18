using Consultorio.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Domain.Entities
{
    // Consulta
    public class Consultation : BaseEntity
    {
        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateTime ConsultationDate { get; set; }

        public string Reason { get; set; } = string.Empty;

        public string Diagnosis { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;
    }
}
