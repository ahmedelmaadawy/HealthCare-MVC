using HealthCare.BusinessLogic.ViewModels.MedicalRecord;

namespace HealthCare.BusinessLogic.Interfaces
{
    public interface IMedicalRecordService
    {
        Task CreateMedicalRecord(AddingMedicalRecordVM model);
        Task<MedicalRecordViewModel> GetMedicalRecordById(int id);
        Task<List<MedicalRecordViewModel>> GetMedicalRecordsByDoctor(int doctorId);
        Task<List<MedicalRecordViewModel>> GetMedicalRecordsByPatient(int patientId);

    }
}
