using HealthCare.BusinessLogic.Interfaces;
using HealthCare.BusinessLogic.ViewModels.TimeSlotVMs;
using HealthCare.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthCare.Presentaion.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _service;
        public DoctorController(IDoctorService service)
        {
            _service = service;
        }
        [AllowAnonymous]
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

        [Authorize(Roles = "Doctor")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            doctor.UserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (ModelState.IsValid)
            {
                _service.Add(doctor);
                return RedirectToAction("Logout", "Account");
            }
            else
            {
                return View("Create", doctor);
            }
        }
        //----------------------------------------------------------------
        [Authorize(Roles = "Doctor")]

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var doctor = _service.GetById(id);
            return View(doctor);
        }
        [Authorize(Roles = "Doctor")]

        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public IActionResult Edit(Doctor doctor)
        {
            if (ModelState.IsValid)
            {

                _service.Update(doctor.Id, doctor);
                return RedirectToAction("Index");
            }
            return View("Edit", doctor);
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
        [Authorize(Roles = "Doctor")]
        [HttpGet]
        public IActionResult AddTimeSlot(int doctorId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var doctor = _service.GetById(doctorId);
            if (userId == doctor.UserId)
            {
                var model = new TimeSlotViewModel
                {
                    DoctorID = doctorId
                };

                return View(model);
            }
            return Unauthorized();
        }
        [HttpPost]
        public IActionResult AddTimeSlot(TimeSlotViewModel model)
        {
            if (ModelState.IsValid)
            {
                var timeSlot = new TimeSlot
                {
                    DoctorID = model.DoctorID,
                    StartTime = model.StartTime,
                    IsAvailable = true,
                };

                _service.AddTimeSlot(timeSlot);

                return RedirectToAction("Details", new { id = model.DoctorID });
            }
            return View("AddTimeSlot", model);
        }
        [HttpGet]
        public IActionResult DisplayTimeSlots(int id, DateTime Date)
        {
            var doctor = _service.GetById(id);
            var timeSlot = doctor.AvailableTimeSlots?.Where(t => t.IsAvailable == true && t.StartTime.Date >= Date.Date).ToList();
            var tmVM = new TimeSlotwithDoctorVM()
            {
                DoctorName = doctor.FirstName + ' ' + doctor.LastName,
                Address = doctor.OfficeAddress,
                Contact = doctor.ContactNumber,
                TimeSlots = timeSlot.ToList()
            };
            return View(tmVM);
        }
    }
}
