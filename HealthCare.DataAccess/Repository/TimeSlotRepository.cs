using HealthCare.DataAccess.Context;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.DataAccess.Repository
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly ApplicationDbContext _context;

        public TimeSlotRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(TimeSlot timeSlot)
        {
            await _context.TimeSlots.AddAsync(timeSlot);
        }
        public void Delete(TimeSlot timeSlot)
        {
            _context.TimeSlots.Remove(timeSlot);
        }
        public async Task<TimeSlot> GetById(int id)
        {
            return await _context.TimeSlots.FirstOrDefaultAsync(t => t.Id == id);
        }
        public void Update(TimeSlot timeSlot)
        {

            _context.TimeSlots.Update(timeSlot);
        }
    }
}
