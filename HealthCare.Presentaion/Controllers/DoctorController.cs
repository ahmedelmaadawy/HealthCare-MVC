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
        public async Task<IActionResult> Index(string searchString)
        {

            var doctors = await _service.GetAll();

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
        public async Task<IActionResult> Create(Doctor doctor)
        {
            doctor.UserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (ModelState.IsValid)
            {
                await _service.Add(doctor);
                return RedirectToAction("Logout", "Account");
            }
            else
            {
                return View("Create", doctor);
            }
        }

        [Authorize(Roles = "Doctor")]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var doctor = await _service.GetById(id);
            var userid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userid == doctor.UserId)
            {
                return View(doctor);

            }
            else
            {
                return Unauthorized();
            }
        }

        [Authorize(Roles = "Doctor")]
        [HttpPost]
        public async Task<IActionResult> Edit(Doctor doctor)
        {
            if (ModelState.IsValid)
            {

                await _service.Update(doctor.Id, doctor);
                return RedirectToAction("Index");
            }
            return View("Edit", doctor);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var doctor = await _service.GetById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }
        [Authorize(Roles = "Doctor")]
        [HttpGet]
        public async Task<IActionResult> AddTimeSlot(int doctorId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var doctor = await _service.GetById(doctorId);
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
        public async Task<IActionResult> AddTimeSlot(TimeSlotViewModel model)
        {
            if (ModelState.IsValid)
            {
                var timeSlot = new TimeSlot
                {
                    DoctorID = model.DoctorID,
                    StartTime = model.StartTime,
                    IsAvailable = true,
                };

                await _service.AddTimeSlot(timeSlot);

                return RedirectToAction("DisplayTimeSlots", new { id = model.DoctorID, Date = DateTime.Now });
            }
            return View("AddTimeSlot", model);
        }
        [HttpGet]
        public async Task<IActionResult> DisplayTimeSlots(int id, DateTime Date)
        {
            var doctor = await _service.GetById(id);
            var timeSlot = doctor.AvailableTimeSlots?.Where(t => t.IsAvailable == true && t.StartTime.Date >= Date.Date).ToList();
            var tmVM = new TimeSlotwithDoctorVM()
            {
                DoctorName = doctor.FirstName + doctor.LastName,
                Address = doctor.OfficeAddress,
                Contact = doctor.ContactNumber,
                TimeSlots = timeSlot.ToList()
            };
            return View(tmVM);
        }
    }
}
