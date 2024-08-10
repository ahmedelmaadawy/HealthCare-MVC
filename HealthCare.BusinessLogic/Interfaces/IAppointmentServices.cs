using HealthCare.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HealthCare.BusinessLogic.Interfaces
{
    public interface IAppointmentServices
    {
        public List<Appointment> GetAllAppointmentsForThatDay(int doctorId , DateTime day);


        public void CompletedAppointment(int id);
       


        public void BookAppointment(Appointment appointment);




        public void ChangeAppointment(Appointment appointment);

        public void CancleAppointment(int ID);

        public List<Appointment> GetAllAppointmentsForThatPatient(int patientId);
        

    }
}

