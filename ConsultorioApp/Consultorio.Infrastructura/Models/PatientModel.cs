using Consultorio.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Infrastructura.Models
{
    public class PatientModel : BasePerson
    {
        public DateTime RegistrationDate { get; set; }

        public string BloodType { get; set; } = string.Empty;

        public string MedicalHistory { get; set; } = string.Empty;

        public bool Active { get; set; }
    }
}
