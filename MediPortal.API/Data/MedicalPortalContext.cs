using MediPortal.API.Models;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Patient>().HasData(

                new Patient
                {
                    Id = 1,
                    FirstName = "Lawrence",
                    LastName = "Mugwena",
                    PatientNumber = "LAWRE123",
                    Phone = "0722247453",
                    City = "Polokwane",
                    Region ="Thohoyandou",
                    Country ="South Africa",
                    NextOfKinPhone ="0791069624",
                    NextOfKinName ="Percy",
                    Age = 45,
                    DateOfBirth = "1990-12-13",
                    Address ="Wits, Braam, Campus",
                    PostalCode = "1441"
                },
                 new Patient
                 {
                     Id = 2,
                     FirstName = "John",
                     LastName = "Thendo",
                     PatientNumber = "JON123",
                     Phone = "0722247453",
                     City = "Polokwane",
                     Region = "Thohoyandou",
                     Country = "South Africa",
                     NextOfKinPhone = "0791069624",
                     NextOfKinName = "Percy",
                     Age = 45,
                     DateOfBirth = "1990-12-13",
                     Address = "Wits, Braam, Campus",
                     PostalCode ="1441"
                 },
                  new Patient
                  {
                      Id = 3,
                      FirstName = "John",
                      LastName = "Smith",
                      PatientNumber = "LAWRE123",
                      Phone = "0722247453",
                      City = "Polokwane",
                      Region = "Thohoyandou",
                      Country = "South Africa",
                      NextOfKinPhone = "0791069624",
                      NextOfKinName = "Percy",
                      Age = 45,
                      DateOfBirth = "1990-12-13",
                      Address = "Wits, Braam, Campus",
                      PostalCode = "1441"
                  }

             );

            modelBuilder.Entity<PatientRecord>().HasData(

                 new PatientRecord
                 {
                     Id = 1,
                     DateCreate = new DateTime(2024, 6, 1),
                     DateUpdate = new DateTime(2024, 6, 5),
                     RecordContext = "Initial consultation. Patient reports headaches and dizziness.",
                     DoctorName = "Dr. Smith",
                     PatientId = 1
                 },
            new PatientRecord
            {
                Id = 2,
                DateCreate = new DateTime(2024, 6, 2),
                DateUpdate = new DateTime(2024, 6, 6),
                RecordContext = "Follow-up for respiratory symptoms. Prescribed cough syrup.",
                DoctorName = "Dr. Johnson",
                PatientId = 2
            },
            new PatientRecord
            {
                Id = 3,
                DateCreate = new DateTime(2024, 6, 3),
                DateUpdate = new DateTime(2024, 6, 7),
                RecordContext = "Routine check-up. Blood pressure slightly elevated.",
                DoctorName = "Dr. Lee",
                PatientId = 3
            },
            new PatientRecord
            {
                Id = 4,
                DateCreate = new DateTime(2024, 6, 4),
                DateUpdate = new DateTime(2024, 6, 8),
                RecordContext = "Patient presents with abdominal pain. Recommended ultrasound.",
                DoctorName = "Dr. Brown",
                PatientId = 1
            },
            new PatientRecord
            {
                Id = 5,
                DateCreate = new DateTime(2024, 6, 5),
                DateUpdate = new DateTime(2024, 6, 9),
                RecordContext = "Routine diabetes check. A1C levels are stable.",
                DoctorName = "Dr. Green",
                PatientId = 2
            },
            new PatientRecord
            {
                Id = 6,
                DateCreate = new DateTime(2024, 6, 6),
                DateUpdate = new DateTime(2024, 6, 10),
                RecordContext = "Emergency visit for a sprained ankle. Applied a brace.",
                DoctorName = "Dr. Adams",
                PatientId = 3
            },
            new PatientRecord
            {
                Id = 7,
                DateCreate = new DateTime(2024, 6, 7),
                DateUpdate = new DateTime(2024, 6, 11),
                RecordContext = "Consultation for back pain. Suggested physical therapy.",
                DoctorName = "Dr. Davis",
                PatientId = 1
            },
            new PatientRecord
            {
                Id = 8,
                DateCreate = new DateTime(2024, 6, 8),
                DateUpdate = new DateTime(2024, 6, 12),
                RecordContext = "Annual physical exam. Cholesterol levels high.",
                DoctorName = "Dr. Wilson",
                PatientId = 2
            },
            new PatientRecord
            {
                Id = 9,
                DateCreate = new DateTime(2024, 6, 9),
                DateUpdate = new DateTime(2024, 6, 13),
                RecordContext = "Routine follow-up for high blood pressure. Medication adjusted.",
                DoctorName = "Dr. Moore",
                PatientId = 2
            },
            new PatientRecord
            {
                Id = 10,
                DateCreate = new DateTime(2024, 6, 10),
                DateUpdate = new DateTime(2024, 6, 14),
                RecordContext = "Patient experiencing insomnia. Prescribed sleep aids.",
                DoctorName = "Dr. Taylor",
                PatientId = 1
            },
            new PatientRecord
            {
                Id = 11,
                DateCreate = new DateTime(2024, 6, 11),
                DateUpdate = new DateTime(2024, 6, 15),
                RecordContext = "Routine immunization. Administered flu vaccine.",
                DoctorName = "Dr. Martinez",
                PatientId = 3
            },
            new PatientRecord
            {
                Id = 12,
                DateCreate = new DateTime(2024, 6, 12),
                DateUpdate = new DateTime(2024, 6, 16),
                RecordContext = "Consultation for skin rash. Prescribed topical ointment.",
                DoctorName = "Dr. Clark",
                PatientId = 1
            },
            new PatientRecord
            {
                Id = 13,
                DateCreate = new DateTime(2024, 6, 13),
                DateUpdate = new DateTime(2024, 6, 17),
                RecordContext = "Follow-up for asthma. Adjusted inhaler dosage.",
                DoctorName = "Dr. Lewis",
                PatientId = 2
            },
            new PatientRecord
            {
                Id = 14,
                DateCreate = new DateTime(2024, 6, 14),
                DateUpdate = new DateTime(2024, 6, 18),
                RecordContext = "Patient with persistent cough. Recommended chest X-ray.",
                DoctorName = "Dr. Walker",
                PatientId = 3
            },
            new PatientRecord
            {
                Id = 15,
                DateCreate = new DateTime(2024, 6, 15),
                DateUpdate = new DateTime(2024, 6, 19),
                RecordContext = "Routine eye exam. No significant changes detected.",
                DoctorName = "Dr. Harris",
                PatientId = 1
            }
        );

        }
    }
}
