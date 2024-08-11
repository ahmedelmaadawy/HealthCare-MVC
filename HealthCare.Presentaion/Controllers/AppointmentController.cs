using HealthCare.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Presentaion.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentServices _services;
        public AppointmentController(IAppointmentServices appointmentServices)
        {
            _services = appointmentServices;
        }
        public IActionResult GetAllByDay(int doctorID, DateTime day)
        {
            var model = _services.GetAllByDay(doctorID, day);
            return View(model);
        }
        public IActionResult CompletedAppointment(int Id, DateTime day, int doctorId)
        {
            _services.CompletedAppointment(Id);
            return RedirectToAction(nameof(GetAllByDay), new { doctorID = doctorId, Day = day });
        }
        public IActionResult GetAllAppointmentsForThatPatient(int ID)
        {
            var model = _services.GetByPatientId(ID);
            return View(model);

        }
        public IActionResult CancleAppointment(int Id)
        {
            _services.CancleAppointment(Id);
            return RedirectToAction(nameof(GetAllAppointmentsForThatPatient), new { id = Id });
        }


    }
}
