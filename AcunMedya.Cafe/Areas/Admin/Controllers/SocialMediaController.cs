﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcunMedya.Cafe.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
