using AutoMapper;
using HealthCare.BusinessLogic.ViewModels;
using HealthCare.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Presentaion.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public AccountController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserVM userVm)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _userManager.CreateAsync(_mapper.Map<AppUser>(userVm));
                if (result.Succeeded)
                {

                    return RedirectToAction("Index", "Doctor");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("Identity", error.Description);
                    }
                    return View(userVm);


                }
            }
            return View(userVm);

        }
    }
}
