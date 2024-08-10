using HealthCare.DataAccess.Context;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;

namespace HealthCare.DataAccess.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;
        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Doctor doctor) => _context.Doctors.Add(doctor);


        public List<Doctor> GetAll() => _context.Doctors.ToList();

        public Doctor GetById(int id) => _context.Doctors.FirstOrDefault(d => d.Id == id);

        public void Update(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
        }
        public void Delete(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
            }
        }
    }
}
