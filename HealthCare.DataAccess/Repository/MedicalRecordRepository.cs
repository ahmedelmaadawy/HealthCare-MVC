using HealthCare.DataAccess.Context;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DataAccess.Repository
{
    public class MedicalRecordRepository : IMedicalRecordRepositery
    {
        private readonly ApplicationDbContext _context;


        public MedicalRecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public void AddMedicalRecord(MedicalRecord record)
        {
            _context.MedicalRecords.Add(record);
            
        }

        public List<MedicalRecord> GetAllMedicalRecords()
        {
            return _context.MedicalRecords.ToList();
        }

        public MedicalRecord GetMedicalRecordById(int id)
        {
            return _context.MedicalRecords.Include(r => r.Doctor).Include(r => r.Patient).FirstOrDefault(r=>r.Id==id);
        }

        public List<MedicalRecord> GetMedicalRecordsByDoctor(int doctorId)
        {
            return _context.MedicalRecords.Include(r=>r.Patient)
                .Where(r => r.DoctorID == doctorId)
                .ToList();
        }

        public List<MedicalRecord> GetMedicalRecordsByPatient(int patientId)
        {
            return _context.MedicalRecords.Include(r=>r.Doctor)
                .Where(r => r.PatientID == patientId)
                .ToList();
        }
        
      
    }
}
