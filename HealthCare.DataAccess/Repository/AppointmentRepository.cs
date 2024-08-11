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

        public List<Appointment> GetByDoctorId(int doctorId)
        {
            var appointments = _context.Appointments.Where(x => x.DoctorId == doctorId).Include(a => a.Patient).ToList();
            return appointments;
        }

        public void Create(Appointment appointment)
        {
            appointment.Status = AppointmentStatus.Scheduled;
            _context.Appointments.Add(appointment);
        }

        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
        }
        public List<Appointment> GetByPatientId(int patientId)
        {
            return _context.Appointments.Where(x => x.PatientId == patientId).Include(x => x.Doctor).ToList();
        }

        public Appointment GetById(int id)
        {
            return _context.Appointments.Where(a => a.Id == id).FirstOrDefault();
        }
    }

}
