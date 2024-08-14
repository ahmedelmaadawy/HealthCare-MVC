using HealthCare.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Presentaion.Controllers
{
    [Authorize]
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
            return View("GetAllAppointmentsForThatDay", model);
        }
        [Authorize(Roles = "Doctor")]
        public IActionResult CompletedAppointment(int Id)
        {

            _services.CompletedAppointment(Id);
            return RedirectToAction("Create", "MedicalRecord", new { id = Id });
        }
        [Authorize(Roles = "Patient")]
        public IActionResult PatientAppointments(int ID)
        {
            var model = _services.GetByPatientId(ID);
            return View(model);

        }
        public IActionResult CancleAppointment(int Id)
        {
            _services.CancleAppointment(Id);
            return RedirectToAction(nameof(PatientAppointments), new { id = Id });
        }
        [Authorize(Roles = "Patient")]

        public IActionResult BookNewAppointment(int timeslotId, int patientId)
        {
            _services.BookAppointment(timeslotId, patientId);
            return RedirectToAction("PatientAppointments", new { ID = patientId });

        }


    }
}
