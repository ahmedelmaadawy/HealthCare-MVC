using HealthCare.DataAccess.Models;

namespace HealthCare.DataAccess.Interfaces
{
    public interface IMedicalRecordRepositery
    {
        Task AddMedicalRecord(MedicalRecord record);
        Task<MedicalRecord> GetMedicalRecordById(int id);
        Task<List<MedicalRecord>> GetMedicalRecordsByDoctor(int doctorId);
        Task<List<MedicalRecord>> GetMedicalRecordsByPatient(int patientId);
    }
}
