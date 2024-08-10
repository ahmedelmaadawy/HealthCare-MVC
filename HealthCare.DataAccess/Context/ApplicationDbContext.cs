using HealthCare.DataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.DataAccess.Context
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<TimeSlot> TimeSlots { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Doctors
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor {Id =3,  FirstName = "John", LastName = "Doe", Specialization = "Cardiology", ContactNumber = "123-456-7890", OfficeAddress = "123 Heart Lane" },
                new Doctor { Id = 2, FirstName = "Jane", LastName = "Smith", Specialization = "Neurology", ContactNumber = "987-654-3210", OfficeAddress = "456 Brain Blvd" }
            );

            // Seed Patients
            modelBuilder.Entity<Patient>().HasData(
                new Patient {Id = 1, FirstName = "Alice", LastName = "Johnson", DateOfBirth = new DateTime(1990, 1, 1), Gender = "Female", ContactNumber = "111-222-3333", Adderss = "789 Elm Street" },
                new Patient { Id = 2, FirstName = "Bob", LastName = "Williams", DateOfBirth = new DateTime(1985, 5, 15), Gender = "Male", ContactNumber = "444-555-6666", Adderss = "321 Oak Avenue" }
            );

            // Seed TimeSlots
            modelBuilder.Entity<TimeSlot>().HasData(
                new TimeSlot {Id = 1, DoctorID = 1, StartTime = new DateTime(2024, 8, 10, 9, 0, 0), IsAvailable = false },
                new TimeSlot {Id = 2, DoctorID = 1, StartTime = new DateTime(2024, 8, 10, 10, 0, 0), IsAvailable = true },
                new TimeSlot { Id = 3, DoctorID = 2, StartTime = new DateTime(2024, 8, 10, 11, 0, 0), IsAvailable =false }
            );

            // Seed Appointments
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment {Id = 1, PatientId = 1, DoctorId = 1, DateTime = new DateTime(2024, 8, 10, 9, 0, 0), Status = AppointmentStatus.Scheduled },
                new Appointment { Id = 2, PatientId = 2, DoctorId = 2, DateTime = new DateTime(2024, 8, 10, 11, 0, 0), Status = AppointmentStatus.Scheduled }
            );

            // Seed MedicalRecords
            modelBuilder.Entity<MedicalRecord>().HasData(
                new MedicalRecord { Id = 1, PatientID = 1, DoctorID = 1, Date = new DateTime(2024, 8, 10), Description = "Routine Checkup", Prescription = "Take 1 tablet of aspirin daily" },
                new MedicalRecord { Id=2,PatientID = 2, DoctorID = 2, Date = new DateTime(2024, 8, 10), Description = "Migraine Treatment", Prescription = "Rest and Hydrate" }
            );
        }

    }
}
