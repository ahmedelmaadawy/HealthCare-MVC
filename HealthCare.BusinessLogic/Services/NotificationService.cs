using HealthCare.BusinessLogic.Interfaces;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;

namespace HealthCare.BusinessLogic.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _context;
        public NotificationService(IUnitOfWork context)
        {
            _context = context;
        }
        public async Task BookAppointmentNotifications(Appointment appointment)
        {
            var doctors = await _context.Doctors.GetAll();
            var doctor = doctors.Where(d => d.Id == appointment.DoctorId).FirstOrDefault();
            var patients = await _context.Patients.GetAll();
            var patient = patients.Where(p => p.Id == appointment.PatientId).FirstOrDefault();
            var docnotification = new Notification()
            {
                Title = "New Appointment Booked",
                Message = $" Patinet : {patient.FirstName + ' ' + patient.LastName} Booked A New Appointment.\nDate : {appointment.DateTime.Date}\nTime {appointment.DateTime.ToShortTimeString}" +
                $"\npatients Contact : {patient.ContactNumber}",
                CreatedAt = DateTime.Now,
                UserId = doctor.UserId,
                IsRead = false,
            };
            var patnotification = new Notification()
            {
                Title = "You Booked New Appointment",
                Message = $"\nDoctor : {doctor.FirstName + ' ' + doctor.LastName} \nAddress : {doctor.OfficeAddress}\nDate : {appointment.DateTime.Date}\nTime {appointment.DateTime.ToShortTimeString}" +
                $"\nDoctor Contact : {doctor.ContactNumber} ",
                CreatedAt = DateTime.Now,
                UserId = patient.UserId,
                IsRead = false,
            };
            await _context.Notifications.AddNotification(docnotification);
            await _context.Notifications.AddNotification(patnotification);
            await _context.Compelete();


        }

        public async Task<List<Notification>> GetNotificationListByUser(string UserId)
        {
            return await _context.Notifications.GetAllByUserId(UserId);
        }
    }
}
