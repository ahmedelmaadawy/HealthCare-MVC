using AutoMapper;
using HealthCare.BusinessLogic.ViewModels.Identity;
using HealthCare.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Presentaion.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signinManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signinManager;
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
                var user = _mapper.Map<AppUser>(userVm);
                IdentityResult result = await _userManager.CreateAsync(user, userVm.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    if (userVm.Role == "Doctor")
                    {
                        var res = await _userManager.AddToRoleAsync(user, "Doctor");
                        if (res.Succeeded)
                        {
                            return RedirectToAction("Create", "Doctor");
                        }
                    }
                    else if (userVm.Role == "Patient")
                    {
                        var res = await _userManager.AddToRoleAsync(user, "Patient");
                        if (res.Succeeded)
                            return RedirectToAction("Create", "Patient");
                    }
                    else
                    {
                        throw new Exception("erron in role");
                    }
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
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserVM userVm)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userVm.Email);
                if (user != null)
                {
                    var result = await _userManager.CheckPasswordAsync(user, userVm.Password);
                    if (result)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Doctor");
                    }
                }
                ModelState.AddModelError("authentication", "Email Or Password Wrong");
            }
            return View(userVm);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Register");
        }


    }
}
