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

        public async Task<List<Appointment>> GetAllByDoctorId(int doctorId)
        {
            var Appointments = await _context.Appointments.GetByDoctorId(doctorId);
            return Appointments;
        }
        public async Task<List<Appointment>> GetAllByDay(int doctorId, DateTime day)
        {
            var Appointments = await _context.Appointments.GetByDoctorId(doctorId);
            var result = Appointments.Where(x => x.DateTime.Date == day.Date).ToList();
            return result;
        }
        public async Task CompletedAppointment(int Id)
        {
            var appointment = await _context.Appointments.GetById(Id);
            appointment.Status = AppointmentStatus.Completed;
            _context.Appointments.Update(appointment);
            await _context.Compelete();

        }
        public async Task BookAppointment(int timeslotId, int patientId)
        {
            var timeslot = await _context.TimeSlots.GetById(timeslotId);
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
                await _context.Appointments.Create(appointment);
                await _context.Compelete();
            }
        }
        public async Task Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.Compelete();
        }
        public async Task CancleAppointment(int ID)
        {
            var appointment = await _context.Appointments.GetById(ID);
            appointment.Status = AppointmentStatus.Canceled;
            _context.Appointments.Update(appointment);
            await _context.Compelete();
        }
        public async Task<List<Appointment>> GetByPatientId(int patientId)
        {
            return await _context.Appointments.GetByPatientId(patientId);
        }
        public async Task<Appointment> GetById(int Id)
        {
            return await _context.Appointments.GetById(Id);
        }

    }
}
