using HealthCare.DataAccess.Models;
using HealthCare.Presentaion.ViewModels;

namespace HealthCare.BusinessLogic.Interfaces
{
    public interface IDoctorService
    {
        List<DoctorToDisplayVM> GetAll();
        void Add(Doctor doctor);
    }
}
