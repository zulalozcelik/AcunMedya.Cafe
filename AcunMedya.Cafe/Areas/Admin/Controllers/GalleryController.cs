using AcunMedya.Cafe.Context;
using AcunMedya.Cafe.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class GalleryController : Controller
    {
        private readonly CafeContext _context;

        public GalleryController(CafeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Galleries.ToList();
            return View(values);
        }

        public IActionResult AddGallery()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGallery(Gallery p)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Galleries.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult DeleteGallery(int id)
        {
            var value = _context.Galleries.Find(id);
            _context.Galleries.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateGallery(int id)
        {
            var value = _context.Galleries.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateGallery(Gallery p)
        {
            _context.Galleries.Update(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
