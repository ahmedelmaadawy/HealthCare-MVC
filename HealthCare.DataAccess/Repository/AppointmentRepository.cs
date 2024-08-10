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

        public List<Appointment> GetAppointmentByDoctorId(int doctorId)
        {
            var appointments = _context.Appointments.Where(x => x.DoctorId == doctorId).Include(a => a.Patient).ToList();
            return appointments;
        }

        public void BookAppointment(Appointment appointment)
        {
            appointment.Status = AppointmentStatus.Scheduled;
            _context.Appointments.Add(appointment);
        }

        public void ChangeAppointment(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
        }
        public void CancleAppointment(int ID)
        {
            var appointment = _context.Appointments.FirstOrDefault(x => x.Id == ID);
            appointment.Status = AppointmentStatus.Canceled;
            ChangeAppointment(appointment);
        }

        public void CompletedAppointment(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(x => x.Id == id);
            appointment.Status = AppointmentStatus.Completed;
            ChangeAppointment(appointment);
        }
        public List<Appointment> GetAllAppointmentsForThatPatient(int patientId)
        {
            return _context.Appointments.Where(x => x.PatientId == patientId).Include(x => x.Doctor).ToList();
        }


    }

}
