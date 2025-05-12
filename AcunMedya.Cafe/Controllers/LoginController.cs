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
        CafeContext db = new CafeContext();
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string userName, string password)
        {
            // Admin kontrolü
            var admin = db.Admins.FirstOrDefault(x => x.Username == userName && x.Password == password);

            if (admin != null)
            {
                // Kimlik bilgileri oluştur
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, admin.Username ?? "admin"),
            new Claim("ProfilePhoto", admin.ProfilePhoto ?? "")
        };

                var identity = new ClaimsIdentity(claims, "Login");
                var principal = new ClaimsPrincipal(identity);

                // Giriş yap
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home"); // Giriş sonrası yönlendirme
            }
            else
            {
                ViewBag.Error = "Geçersiz kullanıcı adı veya şifre";
                return View();
            }
        }
    }
}