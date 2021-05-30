using MassDataApi.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassDataApi.Data.DbContexts
{
    public class MassDataContext : IdentityDbContext
    {
        //public MassDataContext() { }
        public MassDataContext(DbContextOptions<MassDataContext> options)
           : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Data Source=.;Initial Catalog=MassDb;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<MainCertificate> MainCertificates { get; set; }
        public DbSet<StudentRegistration> StudentRegistrations { get; set; }
        public DbSet<TemporaryCertificate> TemporaryCertificates { get; set; }
    }
}
