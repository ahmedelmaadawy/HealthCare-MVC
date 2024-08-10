using HealthCare.DataAccess.Context;
using HealthCare.DataAccess.Interfaces;

namespace HealthCare.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IDoctorRepository Doctors { get; }
        public IMedicalRecordRepositery MedicalRecords { get; }

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context, IDoctorRepository doctors, IMedicalRecordRepositery medicalRecords)
        {
            _context = context;
            Doctors = doctors;
            MedicalRecords = medicalRecords;
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
