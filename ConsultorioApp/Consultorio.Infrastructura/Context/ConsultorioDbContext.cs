using Consultorio.Domain.Entities;
using Consultorio.Infrastructura.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Infrastructura.Context
{
    public class ConsultorioDbContext(DbContextOptions<ConsultorioDbContext> options) : DbContext(options)
    {
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<DoctorModel> Doctors { get; set; }
        public DbSet<ConsultationModel> Consultations { get; set; }
        public DbSet<PrescriptionModel> Prescriptions { get; set; }
    }
}
