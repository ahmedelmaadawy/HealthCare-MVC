using AutoMapper;
using HealthCare.BusinessLogic.Interfaces;
using HealthCare.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Presentaion.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _service;
        private readonly IMapper _mapper;

        public PatientController(IPatientService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var patients = _service.GetAll();
            return View(patients);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _service.Add(patient);
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        public IActionResult Edit(int id)
        {
            var patient = _service.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost]
        public IActionResult Update(Patient patient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(patient);
                    return RedirectToAction("Index");
                }
                catch (ArgumentException)
                {
                    return NotFound();
                }
            }
            return View("Edit", patient);
        }

        public IActionResult Delete(int id)
        {
            var patient = _service.GetPatientById(id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
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
