using AcunMedya.Cafe.Context;
using AcunMedya.Cafe.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class AdressController : Controller
    {
        private readonly CafeContext _context;
        public IActionResult Index()
        {
            var values = _context.Adresses.ToList();
            return View(values);
        }
        public IActionResult AddAdress()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAdress(Adress adress)
        {
            if (ModelState.IsValid)
            {
                _context.Adresses.Add(adress);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adress);
        }

        [HttpGet]
        public IActionResult UpdateAdress(int id)
        {
            var address = _context.Adresses.Find(id);
            if (address == null)
            {
                return RedirectToAction("Index");
            }
            return View(address);
        }

        [HttpPost]
        public IActionResult UpdateAdress(Adress adress)
        {
            if (ModelState.IsValid)
            {
                _context.Adresses.Update(adress);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adress);
        }

        public IActionResult DeleteAdress(int id)
        {
            var adress = _context.Adresses.Find(id);
            if (adress != null)
            {
                _context.Adresses.Remove(adress);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
