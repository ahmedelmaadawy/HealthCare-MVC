using HealthCare.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.DataAccess.Interfaces
{
    public interface IAppointmentRepository
    {
        public List<Appointment> GetAllAppointmentsForThatDay(int doctorId, DateTime day);
        public List<Appointment> GetAllAppointmentsForThatPatient(int patientId);
        public void BookAppointment(Appointment appointment);
        public void ChangeAppointment(Appointment appointment);
        public void CancleAppointment(int ID);
        public void CompletedAppointment(int Id);

    }
}
