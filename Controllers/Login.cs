using Academy.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Academy.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginRepo _loginRepo;

        public LoginController(ILoginRepo loginRepo)
        {
            _loginRepo = loginRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string usernameOrEmail, string password)
        {
            if (ModelState.IsValid)
            {
                bool isValidUser = await _loginRepo.ValidateUser(usernameOrEmail, password);
                if (isValidUser)
                {
                    return RedirectToAction("Index", "Trainee");
                }
                else
                {
                    ViewData["ErrorMessage"] = "Invalid username/email or password.";
                }
            }
            return View();
        }
    }
}
