using HealthCare.DataAccess.Context;
using HealthCare.DataAccess.Interfaces;

namespace HealthCare.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IDoctorRepository Doctors { get; }
        public IPatientRepository Patients { get; }
        public IMedicalRecordRepositery MedicalRecords { get; }

        public IAppointmentRepository Appointments { get; }
        public ITimeSlotRepository TimeSlots { get; private set; }


        public UnitOfWork(ApplicationDbContext context, IDoctorRepository doctors, IMedicalRecordRepositery medicalRecords, IPatientRepository patients, IAppointmentRepository appointments)
        {
            _context = context;
            TimeSlots = new TimeSlotRepository(_context);
            Doctors = doctors;
            MedicalRecords = medicalRecords;
            Appointments = appointments;
            Patients = patients;
        }
        public async Task<int> Compelete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
