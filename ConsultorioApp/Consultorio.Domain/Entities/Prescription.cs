using Consultorio.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Domain.Entities
{
    // Receta
    public class Prescription : BaseEntity
    {
        public int ConsultationId { get; set; }

        public int PatientId { get; set; }

        public string Medication { get; set; } = string.Empty;

        public string Dosage { get; set; } = string.Empty;

        public string Instructions { get; set; } = string.Empty;

        public DateTime IssueDate { get; set; }
    }
}
