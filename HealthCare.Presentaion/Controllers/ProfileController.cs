using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Presentaion.Controllers
{
    public class ProfileController : Controller
    {

        public IActionResult Index()
        {
            if (User.IsInRole("Patient"))
            {
                return RedirectToAction("Edit", "Patient", new { id = User.Claims.FirstOrDefault(c => c.Type == "PatientId")?.Value });
            }
            else
            {
                return RedirectToAction("Edit", "Doctor", new { id = User.Claims.FirstOrDefault(c => c.Type == "DoctorId")?.Value });

            }
        }
    }
}
