using HealthCare.BusinessLogic.Interfaces;
using HealthCare.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Presentaion.Controllers
{
    public class DoctorController : Controller
    {
        //this is me
        // Mo Sabaer
        private readonly IDoctorService _service;
        public DoctorController(IDoctorService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View(_service.GetAll());
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
                return View(doctor);

            }
        }
    }
}
