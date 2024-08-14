using AutoMapper;
using HealthCare.BusinessLogic.ViewModels.Identity;
using HealthCare.DataAccess.Interfaces;
using HealthCare.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HealthCare.Presentaion.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUnitOfWork _context;
        public AccountController(UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signinManager, IUnitOfWork context)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signinManager;
            _context = context;
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
                    var res = await _userManager.AddToRoleAsync(user, userVm.Role);
                    //  await _signInManager.SignInAsync(user, false);

                    if (res.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);

                        if (userVm.Role == "Doctor")

                        {
                            return RedirectToAction("Create", "Doctor");
                        }
                        else if (userVm.Role == "Patient")
                        {
                            return RedirectToAction("Create", "Patient");
                        }


                    }
                    else
                    {
                        throw new Exception("erron in role");

                    }

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Identity", error.Description);
                }
                return View(userVm);
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
                        var doctor = _context.Doctors.GetAll().FirstOrDefault(d => d.UserId == user.Id);
                        var patient = _context.Patients.GetAll().FirstOrDefault(d => d.UserId == user.Id);
                        if (doctor == null && User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value == "Doctor")
                        {
                            return RedirectToAction("Create", "Doctor");
                        }
                        else if (patient == null && User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value == "Patient")
                        {
                            return RedirectToAction("Create", "Patient");
                        }
                        else if (User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value == "Patient")
                        {
                            List<Claim> claims = new List<Claim>();
                            claims.Add(new Claim("PatientId", $"{patient.Id}"));
                            await _signInManager.SignInWithClaimsAsync(user, false, claims);

                            return RedirectToAction("Index", "Doctor");
                        }
                        else if (User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value == "Doctor")
                        {
                            List<Claim> claims = new List<Claim>();
                            claims.Add(new Claim("DoctorId", $"{doctor.Id}"));
                            await _signInManager.SignInWithClaimsAsync(user, false, claims);

                            return RedirectToAction("Index", "Doctor");
                        }

                    }
                }
                ModelState.AddModelError("authentication", "Email Or Password Wrong");
            }
            return View(userVm);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }


    }
}
