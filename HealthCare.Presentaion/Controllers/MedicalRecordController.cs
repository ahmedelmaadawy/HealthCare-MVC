using HealthCare.BusinessLogic.Interfaces;
using HealthCare.BusinessLogic.ViewModels.MedicalRecord;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Presentaion.Controllers
{
    [Authorize]
    public class MedicalRecordController : Controller
    {
        private readonly IMedicalRecordService _service;
        private readonly IAppointmentServices _appointmentsService;
        public MedicalRecordController(IMedicalRecordService service, IAppointmentServices appointmentService)
        {
            _service = service;
            _appointmentsService = appointmentService;
        }
        [Authorize(Roles = "Doctor")]
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var appointment = await _appointmentsService.GetById(id);
            var medicalVm = new MedicalRecordViewModel()
            {
                DoctorId = appointment.DoctorId,
                PatientId = appointment.PatientId,
                DoctorName = appointment.Doctor.FirstName + appointment.Doctor.LastName,
                PatientName = appointment.Patient.FirstName + appointment.Patient.LastName,
                AppointmentDate = appointment.DateTime
            };
            return View(medicalVm);
        }
        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public async Task<IActionResult> Create(AddingMedicalRecordVM model)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateMedicalRecord(model);
                return RedirectToAction("Index", "Doctor");
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var record = await _service.GetMedicalRecordById(id);
            return View(record);
        }

        [Authorize(Roles = "Doctor")]
        [HttpGet]
        public async Task<IActionResult> ViewDoctorMedicalRecords(int id)
        {
            var records = await _service.GetMedicalRecordsByDoctor(id);
            return View(records);
        }

        [HttpGet]
        [Authorize(Roles = "Patient")]
        public async Task<IActionResult> ViewPatientMedicalRecords(int id)
        {
            var records = await _service.GetMedicalRecordsByPatient(id);
            return View(records);
        }
    }
}
