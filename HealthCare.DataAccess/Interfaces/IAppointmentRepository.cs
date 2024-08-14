using HealthCare.DataAccess.Models;

namespace HealthCare.DataAccess.Interfaces
{
    public interface IAppointmentRepository
    {
        public Task<List<Appointment>> GetByDoctorId(int doctorId);
        public Task<List<Appointment>> GetByPatientId(int patientId);
        public Task Create(Appointment appointment);
        public void Update(Appointment appointment);
        public Task<Appointment> GetById(int id);

    }
}
