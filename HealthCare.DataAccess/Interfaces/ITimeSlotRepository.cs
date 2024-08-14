using HealthCare.DataAccess.Models;

namespace HealthCare.DataAccess.Interfaces
{
    public interface ITimeSlotRepository
    {
        void Add(TimeSlot timeSlot);
        void Delete(TimeSlot timeSlot);
        public TimeSlot GetById(int id);
    }
}
