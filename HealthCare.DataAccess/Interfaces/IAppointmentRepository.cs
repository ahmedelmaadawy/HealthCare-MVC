using HealthCare.DataAccess.Models;

namespace HealthCare.DataAccess.Interfaces
{
    public interface IAppointmentRepository
    {
        public List<Appointment> GetAppointmentByDoctorId(int doctorId);
        public List<Appointment> GetAllAppointmentsForThatPatient(int patientId);
        public void BookAppointment(Appointment appointment);
        public void ChangeAppointment(Appointment appointment);
        public void CancleAppointment(int ID);
        public void CompletedAppointment(int Id);

    }
}
