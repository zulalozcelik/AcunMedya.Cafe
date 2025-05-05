using AcunMedya.Cafe.Context;
using AcunMedya.Cafe.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;



namespace AcunMedyaCafe.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly CafeContext _db;
        private const string AuthScheme = "AdminScheme";

        public LoginController(CafeContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Admin admin)
        {
            if (!ModelState.IsValid)
                return View(admin); // FluentValidation hatalarını göster

            var foundAdmin = _db.Admins
                .FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);

            if (foundAdmin == null)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
                return View(admin);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, foundAdmin.Username),
                new Claim(ClaimTypes.NameIdentifier, foundAdmin.AdminId.ToString())
            };

            var identity = new ClaimsIdentity(claims, AuthScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(AuthScheme, principal);

            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(AuthScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}