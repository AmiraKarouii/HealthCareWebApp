using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HealthCareWebApp.Models;

namespace HealthCareWebApp
{
    public class HealthCareWebAppContext : DbContext
    {
        public HealthCareWebAppContext (DbContextOptions<HealthCareWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<HealthCareWebApp.Models.Doctor> Doctor { get; set; } = default!;

        public DbSet<HealthCareWebApp.Models.Appointment>? Appointment { get; set; }

        public DbSet<HealthCareWebApp.Models.Patient>? Patient { get; set; }

        public DbSet<HealthCareWebApp.Models.Prescription>? Prescription { get; set; }
    }
}
