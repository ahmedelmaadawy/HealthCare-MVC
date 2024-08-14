using HealthCare.DataAccess.Models;

namespace HealthCare.DataAccess.Interfaces
{
    public interface ITimeSlotRepository
    {
        Task Add(TimeSlot timeSlot);
        void Delete(TimeSlot timeSlot);
        public Task<TimeSlot> GetById(int id);
        public void Update(TimeSlot timeSlot);

    }
}
