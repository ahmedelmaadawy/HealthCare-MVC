using HealthCare.DataAccess.Context;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;

namespace HealthCare.DataAccess.Repository
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly ApplicationDbContext _context;

        public TimeSlotRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(TimeSlot timeSlot)
        {
            _context.TimeSlots.Add(timeSlot);
        }
        public void Delete(TimeSlot timeSlot)
        {
            _context.TimeSlots.Remove(timeSlot);
        }
    }
}
