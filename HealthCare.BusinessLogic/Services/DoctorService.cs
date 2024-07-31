using HealthCare.BusinessLogic.Interfaces;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;

namespace HealthCare.BusinessLogic.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _context;
        public DoctorService(IUnitOfWork context)
        {
            _context = context;
        }
        public void Add(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.Compelete();
        }

        public List<Doctor> GetAll()
        {
            return _context.Doctors.GetAll();
        }
    }
}
