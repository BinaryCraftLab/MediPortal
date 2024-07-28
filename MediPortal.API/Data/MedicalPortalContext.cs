using MediPortal.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediPortal.API.Data
{
    public class MedicalPortalContext: IdentityDbContext<ApplicationUser>
    {
        public MedicalPortalContext(DbContextOptions<MedicalPortalContext> options) : base(options) { }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<PatientRecord> PatientRecords { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public  DbSet<Doctor> Doctors { get; set; }
        public DbSet<MedicationSchedule> MedicationSchedules { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "0F712A70-B189-46DF-A4C9-373C1F889896",
                    Name ="Patient",
                    NormalizedName ="PATIENT"
                },
                new IdentityRole
                {
                    Id = "0F712A70-B189-46DF-A4C9-373C1F889895",
                    Name = "Doctor",
                    NormalizedName = "DOCTOR"
                },
                new IdentityRole
                {
                    Id = "0F712A70-B189-46DF-A4C9-373C1F889894",
                    Name = "SuperAdmin",
                    NormalizedName = "SUPERADMIN"
                }
            );
        }
    }
}
