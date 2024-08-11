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
        public IActionResult Index()
        {
            var patients = _service.GetAll();
            return View(patients);
        }
        public IActionResult Details(int id)
        {
            var patient = _service.GetPatientById(id);

            return View(_mapper.Map<PatientToDisplayVM>(patient));
        }

        [HttpGet]
        [Authorize(Roles = "Patient")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Patient")]
        [HttpPost]
        public IActionResult Create(PatientToCreateVM patientVm)
        {
            if (ModelState.IsValid)
            {
                var patient = _mapper.Map<Patient>(patientVm);
                patient.UserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                _service.Add(patient);
                return RedirectToAction("Index", "Doctor");
            }
            return View(patientVm);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var patient = _service.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            var userid = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
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
        public IActionResult Edit(PatientToEditVM patientVM)
        {
            if (ModelState.IsValid)
            {
                var patient = _mapper.Map<Patient>(patientVM);
                try
                {
                    _service.Update(patient);
                    return RedirectToAction("Details", new { id = patient.Id });
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }
            }
            return View("Edit", patientVM);
        }
        public IActionResult Delete(int id)
        {
            var patient = _service.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;

            if (userId == patient.UserId)
                return View(patient);
            else
                return Unauthorized();
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _service.Delete(id);
                return RedirectToAction("Index");
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }


    }

}
