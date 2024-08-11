using HealthCare.DataAccess.Models;

namespace HealthCare.DataAccess.Interfaces
{
    public interface IAppointmentRepository
    {
        public List<Appointment> GetByDoctorId(int doctorId);
        public List<Appointment> GetByPatientId(int patientId);
        public void Create(Appointment appointment);
        public void Update(Appointment appointment);
        public Appointment GetById(int id);

    }
}
