using HealthCare.DataAccess.Context;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DataAccess.Repository
{
    public class PatientRepository:IPatientRepository
    {
        private readonly ApplicationDbContext _context;
        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Patient patient)
        {
            _context.Patients.Add(patient);
        }

        public List<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public void Update(Patient patient)
        {
            _context.Patients.Update(patient);  // Entity Framework will handle the update
        }

        public void Delete(Patient patient)
        {
            _context.Patients.Remove(patient);  // Entity Framework will handle the deletion
        }

    }
}
