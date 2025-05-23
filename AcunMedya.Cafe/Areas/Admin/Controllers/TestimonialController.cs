using AcunMedya.Cafe.Context;
using AcunMedya.Cafe.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly CafeContext _context;

        public TestimonialController(CafeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var testimonials = _context.Testimonials.ToList();
            return View(testimonials);
        }

        public IActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {
            if (ModelState.IsValid)
            {
                _context.Testimonials.Add(testimonial);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testimonial);
        }

        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var testimonial = _context.Testimonials.Find(id);
            if (testimonial == null)
            {
                return RedirectToAction("Index");
            }
            return View(testimonial);
        }

        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            if (ModelState.IsValid)
            {
                _context.Testimonials.Update(testimonial);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(testimonial);
        }

        public IActionResult DeleteTestimonial(int id)
        {
            var testimonial = _context.Testimonials.Find(id);
            if (testimonial != null)
            {
                _context.Testimonials.Remove(testimonial);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
