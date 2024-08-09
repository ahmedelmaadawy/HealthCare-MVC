using HealthCare.DataAccess.Context;
using HealthCare.DataAccess.Interfaces;

namespace HealthCare.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDoctorRepository Doctors { get; }

        private readonly ApplicationDbContext _context;
        public ITimeSlotRepository TimeSlots { get; private set; }


        public UnitOfWork(ApplicationDbContext context, IDoctorRepository doctors)
        {
            _context = context;
            TimeSlots = new TimeSlotRepository(_context);
            Doctors = doctors;
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
