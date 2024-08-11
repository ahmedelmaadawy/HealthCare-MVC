using HealthCare.BusinessLogic.ViewModels.Patient;
using HealthCare.DataAccess.Models;

namespace HealthCare.BusinessLogic.Interfaces
{
    public interface IPatientService
    {
        List<PatientToDisplayVM> GetAll();
        Patient GetPatientById(int id);
        void Add(Patient patient);
        void Update(Patient patient);
        void Delete(int id);
    }
}
