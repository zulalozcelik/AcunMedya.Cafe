﻿using AcunMedya.Cafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.ViewComponents
{
    public class _DefaultTestimonialComponentPartial : ViewComponent
    {
        private readonly CafeContext _context;

        public _DefaultTestimonialComponentPartial(CafeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var value = _context.Testimonials.ToList();
            return View(value);
        }
    }
}