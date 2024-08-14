using HealthCare.DataAccess.Context;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.DataAccess.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;
        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
        }

        public async Task<List<Patient>> GetAll()
        {
            return await _context.Patients.ToListAsync();
        }

        public void Update(Patient patient)
        {
            _context.Patients.Update(patient);
        }

        public void Delete(Patient patient)
        {
            _context.Patients.Remove(patient);
        }

    }
}
