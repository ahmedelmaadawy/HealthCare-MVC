using HealthCare.BusinessLogic.ViewModels.Doctor;
using HealthCare.DataAccess.Models;


namespace HealthCare.BusinessLogic.Interfaces
{
    public interface IDoctorService
    {
        Task<List<DoctorToDisplayVM>> GetAll();
        Task Add(Doctor doctor);
        public Task<Doctor> GetById(int id);
        public Task Update(int id, Doctor doctor);
        Task Delete(int id);
        Task AddTimeSlot(TimeSlot timeSlot);
    }
}
