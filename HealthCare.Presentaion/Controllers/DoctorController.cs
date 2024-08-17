using HealthCare.BusinessLogic.Interfaces;
using HealthCare.BusinessLogic.ViewModels.TimeSlotVMs;
using HealthCare.DataAccess.Enums;
using HealthCare.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthCare.Presentaion.Controllers
{
    [Authorize]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _service;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public DoctorController(IDoctorService service, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _service = service;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(string searchString, string specialization = "All")
        {

            var doctors = await _service.GetAll();
            if (specialization != "All")
            {
                Specialization s = (Specialization)int.Parse(specialization);
                doctors = doctors.Where(d => d.Specialization == s.ToString()).ToList();
            }
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
                var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                await _service.Add(doctor);
                var user = await _userManager.FindByIdAsync(id);
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim("DoctorId", $"{doctor.Id}"));
                await _signInManager.SignInWithClaimsAsync(user, false, claims);

                return RedirectToAction("Index");
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
            var timeSlot = doctor.AvailableTimeSlots?.Where(t => t.IsAvailable == true && t.StartTime.Day >= Date.Day).OrderBy(t => t.StartTime).ToList();
            var tmVM = new TimeSlotwithDoctorVM()
            {
                DoctorName = doctor.FirstName + doctor.LastName,
                Address = doctor.OfficeAddress,
                Contact = doctor.ContactNumber,
                TimeSlots = timeSlot.ToList()
            };
            return View(tmVM);
        }
        public async Task<IActionResult> RemoveTimeSlot(int id)
        {
            var doctorId = User.Claims.FirstOrDefault(c => c.Type == "DoctorId")?.Value;
            await _service.DeleteTimeSlot(id);
            return RedirectToAction("DisplayTimeSlots", new { Id = doctorId, Date = DateTime.Now });
        }
    }
}
