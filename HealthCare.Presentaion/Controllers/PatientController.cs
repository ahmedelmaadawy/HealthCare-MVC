using AutoMapper;
using HealthCare.BusinessLogic.Interfaces;
using HealthCare.BusinessLogic.ViewModels.Patient;
using HealthCare.DataAccess.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthCare.Presentaion.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        private readonly IPatientService _service;
        private readonly IMapper _mapper;

        public PatientController(IPatientService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
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
                var patient = _mapper.Map<Patient>(patientVm);
                patient.UserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                await _service.Add(patient);
                return RedirectToAction("Logout", "Account");
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
