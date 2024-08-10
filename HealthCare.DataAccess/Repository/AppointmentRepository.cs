using HealthCare.DataAccess.Context;
using HealthCare.DataAccess.Enums;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DataAccess.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {

        public readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context)
        {
            _context=context;
        }

        public List<Appointment> GetAllAppointmentsForThatDay(int doctorId , DateTime day)
        {
           var apps = _context.Appointments.Where(x => x.DoctorId == doctorId && x.DateTime.Date == day.Date).Include(a =>a.Patient).ToList();
            return apps;
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
            var appointment = _context.Appointments.FirstOrDefault(_x => _x.Id == ID);
            appointment.Status = AppointmentStatus.Canceled;
            ChangeAppointment(appointment);
        }

        public void CompletedAppointment(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(_x => _x.Id ==id);
             appointment.Status = AppointmentStatus.Completed;
            ChangeAppointment(appointment);
        }
        public List<Appointment> GetAllAppointmentsForThatPatient(int patientId)
        {
            return _context.Appointments.Where(x => x.PatientId == patientId ).Include(x => x.Doctor).ToList();
        }

        
    }
   
}
