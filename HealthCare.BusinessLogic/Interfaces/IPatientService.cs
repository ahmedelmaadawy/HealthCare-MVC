using HealthCare.BusinessLogic.ViewModels.Patient;
using HealthCare.DataAccess.Models;

namespace HealthCare.BusinessLogic.Interfaces
{
    public interface IPatientService
    {
        Task<List<PatientToDisplayVM>> GetAll();
        Task<Patient> GetPatientById(int id);
        Task Add(Patient patient);
        Task Update(Patient patient);
        Task Delete(int id);
    }
}
