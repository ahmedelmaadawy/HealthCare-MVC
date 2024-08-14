using AutoMapper;
using HealthCare.BusinessLogic.Interfaces;
using HealthCare.DataAccess.Enums;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;

namespace HealthCare.BusinessLogic.Services
{

    public class AppointmentServices : IAppointmentServices
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public AppointmentServices(IUnitOfWork context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Appointment> GetAllByDay(int doctorId, DateTime day)
        {
            var Appointments = _context.Appointments.GetByDoctorId(doctorId).Where(x => x.DateTime.Date == day.Date).ToList();
            return Appointments;
        }
        public void CompletedAppointment(int Id)
        {
            var appointment = _context.Appointments.GetById(Id);
            appointment.Status = AppointmentStatus.Completed;
            _context.Appointments.Update(appointment);
            _context.Compelete();

        }
        public void BookAppointment(int timeslotId, int patientId)
        {
            var timeslot = _context.TimeSlots.GetById(timeslotId);
            if (timeslot != null)
            {
                timeslot.IsAvailable = false;
                _context.TimeSlots.Update(timeslot);
                var appointment = new Appointment()
                {
                    PatientId = patientId,
                    DoctorId = timeslot.DoctorID,
                    DateTime = timeslot.StartTime,
                    Status = AppointmentStatus.Scheduled
                };
                _context.Appointments.Create(appointment);
                _context.Compelete();
            }
        }
        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.Compelete();
        }
        public void CancleAppointment(int ID)
        {
            var appointment = _context.Appointments.GetById(ID);
            appointment.Status = AppointmentStatus.Canceled;
            _context.Appointments.Update(appointment);
            _context.Compelete();
        }
        public List<Appointment> GetByPatientId(int patientId)
        {
            return _context.Appointments.GetByPatientId(patientId);
        }
        public Appointment GetById(int Id)
        {
            return _context.Appointments.GetById(Id);
        }

    }
}
