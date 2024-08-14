using HealthCare.DataAccess.Models;

namespace HealthCare.DataAccess.Interfaces
{
    public interface IPatientRepository
    {
        public Task Add(Patient patient);
        public Task<List<Patient>> GetAll();
        void Update(Patient patient);
        void Delete(Patient patient);
    }
}
