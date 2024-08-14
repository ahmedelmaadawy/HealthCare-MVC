using HealthCare.DataAccess.Context;
using HealthCare.DataAccess.Enums;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.DataAccess.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {

        public readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Appointment>> GetByDoctorId(int doctorId)
        {
            var appointments = await _context.Appointments.Where(x => x.DoctorId == doctorId).Include(a => a.Patient).ToListAsync();
            return appointments;
        }

        public async Task Create(Appointment appointment)
        {
            appointment.Status = AppointmentStatus.Scheduled;
            await _context.Appointments.AddAsync(appointment);
        }

        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
        }
        public async Task<List<Appointment>> GetByPatientId(int patientId)
        {
            return await _context.Appointments.Where(x => x.PatientId == patientId).Include(x => x.Doctor).ToListAsync();
        }

        public async Task<Appointment> GetById(int id)
        {
            return await _context.Appointments.Include(x => x.Doctor).Include(x => x.Patient).Where(a => a.Id == id).FirstOrDefaultAsync();
        }
    }

}
