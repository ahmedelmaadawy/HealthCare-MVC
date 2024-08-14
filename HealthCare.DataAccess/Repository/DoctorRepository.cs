using HealthCare.DataAccess.Context;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.DataAccess.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _context;
        public DoctorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Doctor doctor) => await _context.Doctors.AddAsync(doctor);


        public async Task<List<Doctor>> GetAll() => await _context.Doctors.ToListAsync();

        public async Task<Doctor> GetById(int id) => await _context.Doctors.Include(d => d.AvailableTimeSlots).FirstOrDefaultAsync(d => d.Id == id);

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
