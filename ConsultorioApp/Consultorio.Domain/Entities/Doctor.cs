using Consultorio.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Infrastructura.Models
{
    public class Doctor : BasePerson
    {
        public string Specialty { get; set; } = string.Empty;

        public string LicenseNumber { get; set; } = string.Empty;

        public bool Active { get; set; }
    }
}
