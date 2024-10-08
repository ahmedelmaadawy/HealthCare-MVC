﻿using HealthCare.BusinessLogic.Interfaces;
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
        public async Task<IActionResult> GetAllByDay(int doctorID, DateTime day)
        {
            var model = await _services.GetAllByDay(doctorID, day);
            return View("GetAllAppointmentsForThatDay", model);
        }
        public async Task<IActionResult> GetPrevious(int doctorID)
        {
            var all = await _services.GetAllByDoctorId(doctorID);
            var model = all.Where(a => a.DateTime.Day < DateTime.Now.Day).ToList();
            return View("GetAllAppointmentsForThatDay", model);
        }
        public async Task<IActionResult> GetUpcomming(int doctorID)
        {
            var all = await _services.GetAllByDoctorId(doctorID);
            var model = all.Where(a => a.DateTime.Day > DateTime.Now.Day).ToList();

            return View("GetAllAppointmentsForThatDay", model);
        }

        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> CompletedAppointment(int Id)
        {

            await _services.CompletedAppointment(Id);
            return RedirectToAction("Create", "MedicalRecord", new { id = Id });
        }
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> PatientAppointments(int ID)
        {
            var model = await _services.GetByPatientId(ID);
            model = model.OrderByDescending(a => a.DateTime).ToList();
            return View(model);

        }
        public async Task<IActionResult> CancleAppointment(int Id)
        {
            await _services.CancleAppointment(Id);
            return RedirectToAction(nameof(PatientAppointments), new { id = User.Claims.FirstOrDefault(c => c.Type == "PatientId").Value });
        }
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> BookNewAppointment(int timeslotId, int patientId)
        {
            await _services.BookAppointment(timeslotId, patientId);
            return RedirectToAction("PatientAppointments", new { ID = patientId });
        }
    }
}
