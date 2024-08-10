using HealthCare.BusinessLogic.Interfaces;
using HealthCare.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Presentaion.Controllers
{
    public class MedicalRecordController : Controller
    {
        private readonly IMedicalRecordService _service;

        public MedicalRecordController(IMedicalRecordService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult AddMedicalRecord() {
            return View();
        }

        [HttpPost]
        public IActionResult AddMedicalRecord(AddingMedicalRecordVM model)
        {
            if (ModelState.IsValid)
            {
                _service.CreateMedicalRecord(model);
                return RedirectToAction("Index","Doctor"); 
            }
            return View(model);
        }
      

        [HttpGet]
        public IActionResult ViewMedicalRecord(int id)
        {
            var record = _service.GetMedicalRecordById(id);
            return View(record);
        }

        [HttpGet]
        public IActionResult ViewDoctorMedicalRecords(int doctorId)
        {
            var records = _service.GetMedicalRecordsByDoctor(doctorId);
            return View(records);
        }

        [HttpGet]
        public IActionResult ViewPatientMedicalRecords(int patientId)
        {
            var records = _service.GetMedicalRecordsByPatient(patientId);
            return View(records);
        }
    }
}
