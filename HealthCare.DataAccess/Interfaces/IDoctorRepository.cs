using HealthCare.DataAccess.Models;

namespace HealthCare.DataAccess.Interfaces
{
    public interface IDoctorRepository
    {
        public void Add(Doctor doctor);
        public List<Doctor> GetAll();
    }
}
