using AcunMedya.Cafe.Context;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.ViewComponents
{
    public class _DefaultFeatureComponentPartial:ViewComponent
    {
        private readonly CafeContext _context;

        public _DefaultFeatureComponentPartial(CafeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.Subtitle = _context.Features.Select(x=>x.SubTitle).FirstOrDefault();
            ViewBag.Title = _context.Features.Select(x=>x.Title).FirstOrDefault();
            return View();
        }
    }
}
