using HealthCare.DataAccess.Models;

namespace HealthCare.DataAccess.Interfaces
{
    public interface IDoctorRepository
    {

        public Task Add(Doctor doctor);
        public Task<List<Doctor>> GetAll();

        public Task<Doctor> GetById(int id);
        public void Update(Doctor doctor);
        void Delete(int id);

    }
}
