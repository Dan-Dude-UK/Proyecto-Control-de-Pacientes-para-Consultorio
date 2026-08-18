using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Application.Dtos.DtoConsultation
{
    public class ReadConsultationDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime ConsultationDate { get; set; }
        public string Reason { get; set; }
        public string Diagnosis { get; set; }
    }
}
