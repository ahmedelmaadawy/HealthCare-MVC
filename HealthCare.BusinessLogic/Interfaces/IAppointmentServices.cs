using HealthCare.DataAccess.Models;


namespace HealthCare.BusinessLogic.Interfaces
{
    public interface IAppointmentServices
    {
        public Task<List<Appointment>> GetAllByDay(int doctorId, DateTime day);
        public Task CompletedAppointment(int Id);
        public Task BookAppointment(int patientId, int doctorId);
        public Task Update(Appointment appointment);
        public Task CancleAppointment(int ID);
        public Task<List<Appointment>> GetByPatientId(int patientId);
        public Task<Appointment> GetById(int Id);
        public Task<List<Appointment>> GetAllByDoctorId(int doctorId);
    }
}

