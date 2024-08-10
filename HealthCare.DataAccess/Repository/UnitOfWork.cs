using HealthCare.DataAccess.Context;
using HealthCare.DataAccess.Interfaces;

namespace HealthCare.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDoctorRepository Doctors { get; }

        private readonly ApplicationDbContext _context;
        public IAppointmentRepository Appointments{get;}

        public UnitOfWork(ApplicationDbContext context, IDoctorRepository doctors,IAppointmentRepository appointments)
        {
            _context = context;
            Doctors = doctors;
            Appointments = appointments;
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
