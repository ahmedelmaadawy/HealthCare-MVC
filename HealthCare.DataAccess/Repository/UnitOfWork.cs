using HealthCare.DataAccess.Context;
using HealthCare.DataAccess.Interfaces;

namespace HealthCare.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDoctorRepository Doctors { get; }
        public IPatientRepository Patients { get; }

        private readonly ApplicationDbContext _context;
        public IAppointmentRepository Appointments{get;}
        public ITimeSlotRepository TimeSlots { get; private set; }

        public UnitOfWork(ApplicationDbContext context, IDoctorRepository doctors,IAppointmentRepository appointments)

        public UnitOfWork(ApplicationDbContext context, IDoctorRepository doctors , IPatientRepository patients)
        {
            _context = context;
            TimeSlots = new TimeSlotRepository(_context);
            Doctors = doctors;
            Appointments = appointments;
            Patients = patients;
        }
        public int Compelete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
