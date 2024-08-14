using HealthCare.DataAccess.Context;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.DataAccess.Repository
{
    public class MedicalRecordRepository : IMedicalRecordRepositery
    {
        private readonly ApplicationDbContext _context;


        public MedicalRecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddMedicalRecord(MedicalRecord record)
        {
            await _context.MedicalRecords.AddAsync(record);

        }

        public async Task<List<MedicalRecord>> GetAllMedicalRecords()
        {
            return await _context.MedicalRecords.ToListAsync();
        }

        public async Task<MedicalRecord> GetMedicalRecordById(int id)
        {
            return await _context.MedicalRecords.Include(r => r.Doctor).Include(r => r.Patient).FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<MedicalRecord>> GetMedicalRecordsByDoctor(int doctorId)
        {
            return await _context.MedicalRecords.Include(r => r.Patient)
                .Where(r => r.DoctorID == doctorId)
                .ToListAsync();
        }

        public async Task<List<MedicalRecord>> GetMedicalRecordsByPatient(int patientId)
        {
            return await _context.MedicalRecords.Include(r => r.Doctor)
                .Where(r => r.PatientID == patientId)
                .ToListAsync();
        }


    }
}
