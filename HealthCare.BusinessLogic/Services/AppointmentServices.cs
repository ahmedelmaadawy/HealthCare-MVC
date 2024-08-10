using AutoMapper;
using HealthCare.BusinessLogic.Interfaces;

using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.BusinessLogic.Services
{
  
    public class AppointmentServices :IAppointmentServices
    {
        private readonly IUnitOfWork _context;
        private readonly IMapper _mapper;
        public AppointmentServices(IUnitOfWork context,IMapper mapper) 
        { 
            _context = context;
            _mapper = mapper;
        }

        public List<Appointment> GetAllAppointmentsForThatDay(int doctorId, DateTime day)
        {
          var Appointments= _context.Appointments.GetAllAppointmentsForThatDay(doctorId, day);

         
            return Appointments;

        }


        public void CompletedAppointment(int Id)
        {
            _context.Appointments.CompletedAppointment(Id);
            _context.Compelete();
       
        }


        public void BookAppointment(Appointment appointment)
        {
            _context.Appointments.BookAppointment(appointment);
            _context.Compelete();
        }


        public void ChangeAppointment(Appointment appointment)
        {
            _context.Appointments.ChangeAppointment(appointment);
            _context.Compelete();
        }
        public void CancleAppointment(int ID)
        {
            _context.Appointments.CancleAppointment(ID);
            _context.Compelete();
        }
        public List<Appointment> GetAllAppointmentsForThatPatient(int patientId)
        {
            return _context.Appointments.GetAllAppointmentsForThatPatient(patientId);
        }

    }
}
