using HealthCare.DataAccess.Models;

namespace HealthCare.BusinessLogic.Interfaces
{
    public interface IDoctorService
    {
        List<Doctor> GetAll();
        void Add(Doctor doctor);
    }
}
