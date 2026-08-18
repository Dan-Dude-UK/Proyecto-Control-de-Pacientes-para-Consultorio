using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Application.Dtos.DtoPatient
{
    public class CreatePatientDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string BloodType { get; set; } = string.Empty;
        public string MedicalHistory { get; set; } = string.Empty;
    }
}
