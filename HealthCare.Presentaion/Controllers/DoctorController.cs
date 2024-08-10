using HealthCare.BusinessLogic.Interfaces;
using HealthCare.BusinessLogic.Services;
using HealthCare.BusinessLogic.ViewModels;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;
using HealthCare.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Presentaion.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _service;
        public DoctorController(IDoctorService service)
        {
            _service = service;
        }
        public IActionResult Index(string searchString)
        {
            var doctors = _service.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
                doctors = doctors.Where(d => d.FullName.Contains(searchString, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            ViewData["CurrentFilter"] = searchString;
            return View(doctors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _service.Add(doctor);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create",doctor);

            }
        }
        //----------------------------------------------------------------
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var doctor = _service.GetById(id);
            return View(doctor);
        }

        [HttpPost]
        public IActionResult SaveEdit(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                var doc = new Doctor() { FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Specialization = doctor.Specialization,
                    OfficeAddress = doctor.OfficeAddress,
                    ContactNumber = doctor.ContactNumber
                };
                _service.Update(doctor.Id ,doctor);
                return RedirectToAction("Index");
            }
            return View("Edit",doctor);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var doctor = _service.GetById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        [HttpGet]
        public IActionResult AddTimeSlot(int doctorId)
        {
            var model = new TimeSlotViewModel
            {
                DoctorID = doctorId
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult SaveTimeSlot(TimeSlotViewModel model)
        {
            if (ModelState.IsValid)
            {
                var timeSlot = new TimeSlot
                {
                    DoctorID = model.DoctorID,
                    StartTime = model.StartTime,
                    IsAvailable = model.IsAvailable
                };

                _service.AddTimeSlot(timeSlot);

                return RedirectToAction("Details", new { id = model.DoctorID });
            }
            return View("AddTimeSlot", model);
        }
    }
}
