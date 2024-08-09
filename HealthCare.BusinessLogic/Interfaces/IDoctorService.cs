using HealthCare.DataAccess.Models;
using HealthCare.Presentaion.ViewModels;
using System.Collections.Generic;


namespace HealthCare.BusinessLogic.Interfaces
{
    public interface IDoctorService
    {
        List<DoctorToDisplayVM> GetAll();
        void Add(Doctor doctor);
        //-------------------
        public Doctor GetById(int id);
        public void Update(int id, Doctor doctor);
        void Delete(int id);
        void AddTimeSlot(TimeSlot timeSlot);
    }
}
