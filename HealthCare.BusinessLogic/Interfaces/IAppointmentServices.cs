using HealthCare.DataAccess.Models;


namespace HealthCare.BusinessLogic.Interfaces
{
    public interface IAppointmentServices
    {
        public List<Appointment> GetAllByDay(int doctorId, DateTime day);
        public void CompletedAppointment(int Id);
        public void BookAppointment(int patientId, int doctorId);
        public void Update(Appointment appointment);
        public void CancleAppointment(int ID);
        public List<Appointment> GetByPatientId(int patientId);
    }
}

