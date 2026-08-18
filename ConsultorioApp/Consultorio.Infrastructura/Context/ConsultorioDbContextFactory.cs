using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.Infrastructura.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ConsultorioDbContext>
    {
        public ConsultorioDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ConsultorioDbContext>();
            optionsBuilder.UseSqlServer(
                "Data Source=MSI\\SQLEXPRESS;Initial Catalog=ConsultorioDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True;Packet Size=4096;Command Timeout=0");

            return new ConsultorioDbContext(optionsBuilder.Options);
        }
    }
}