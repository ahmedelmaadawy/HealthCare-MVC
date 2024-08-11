using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Presentaion.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult New()
        {
            return View();
        }
    }
}
