using Academy.Models;
using Academy.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Academy.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationRepo _registrationRepo;

        public RegistrationController(IRegistrationRepo registrationRepo)
        {
            _registrationRepo = registrationRepo;
        }

        public async Task<IActionResult> Index()
        {
            var registrations = await _registrationRepo.GetAll();
            return View(registrations.ToList());

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Registration registration)
        {
            if (ModelState.IsValid)
            {
                registration.Password = BCrypt.Net.BCrypt.HashPassword(registration.Password);
                await _registrationRepo.Create(registration);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

    }
}
