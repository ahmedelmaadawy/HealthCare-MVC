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

        public MedicalRecordController(IMedicalRecordService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Doctor")]       
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public IActionResult Create(AddingMedicalRecordVM model)
        {
            if (ModelState.IsValid)
            {
                _service.CreateMedicalRecord(model);
                return RedirectToAction("Index", "Doctor");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var record = _service.GetMedicalRecordById(id);
            return View(record);
        }

        [Authorize(Roles = "Doctor")]
        [HttpGet]
        public IActionResult ViewDoctorMedicalRecords(int id)
        {
            var records = _service.GetMedicalRecordsByDoctor(id);
            return View(records);
        }

        [HttpGet]
        [Authorize(Roles = "Patient")]
        public IActionResult ViewPatientMedicalRecords(int id)
        {
            var records = _service.GetMedicalRecordsByPatient(id);
            return View(records);
        }
    }
}
