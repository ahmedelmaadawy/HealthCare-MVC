using AutoMapper;
using HealthCare.BusinessLogic.Interfaces;
using HealthCare.BusinessLogic.ViewModels.Patient;
using HealthCare.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthCare.Presentaion.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private readonly IPatientService _service;
        private readonly IMapper _mapper;

        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public PatientController(IPatientService service, IMapper mapper, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _service = service;
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var patients = await _service.GetAll();
            return View(patients);
        }
        public async Task<IActionResult> Details(int id)
        {
            var patient = await _service.GetPatientById(id);
            return View(_mapper.Map<PatientToDisplayVM>(patient));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Patient")]
        [HttpPost]
        public async Task<IActionResult> Create(PatientToCreateVM patientVm)
        {
            if (ModelState.IsValid)
            {
                var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
                var patient = _mapper.Map<Patient>(patientVm);
                patient.UserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                await _service.Add(patient);
                var user = await _userManager.FindByIdAsync(id);
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim("PatientId", $"{patient.Id}"));
                await _signInManager.SignInWithClaimsAsync(user, false, claims);
                return RedirectToAction("Index", "Doctor");
            }
            return View(patientVm);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _service.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            var userid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userid == patient.UserId)
            {
                var patientModel = _mapper.Map<PatientToEditVM>(patient);

                return View(patientModel);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PatientToEditVM patientVM)
        {
            if (ModelState.IsValid)
            {
                var patient = _mapper.Map<Patient>(patientVM);
                try
                {
                    await _service.Update(patient);
                    return RedirectToAction("Index", "Doctor");
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }
            }
            return View("Edit", patientVM);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _service.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == patient.UserId)
                return View(patient);
            else
                return Unauthorized();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _service.Delete(id);
                return RedirectToAction("Index");
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }


    }

}
