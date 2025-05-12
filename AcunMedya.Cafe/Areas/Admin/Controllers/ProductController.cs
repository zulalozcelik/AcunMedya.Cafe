﻿using AcunMedya.Cafe.Context;
using AcunMedya.Cafe.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace AcunMedya.Cafe.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly CafeContext _context;

        public ProductController(CafeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //Eager Loading
            var values = _context.Products.Include(x => x.Category).ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {

            List<SelectListItem> values = (from x in _context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }
                                         ).ToList();
            ViewBag.v = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product model)
        {

            if (model.ImageFile != null)
            {
                //uygulamanın çalıştığı dizini al
                var currenDirectory = Directory.GetCurrentDirectory();

                //uygulamanın uzantısını al (jpg,png)
                var extension = Path.GetExtension(model.ImageFile.FileName);

                //benzersiz bir dosya adı oluştur
                var filename = Guid.NewGuid().ToString();

                //Kayıt edilecek Dosyanın yolu
                var saveLocation = Path.Combine(currenDirectory, "wwwroot/images", filename + extension);

                //belirtilen konumda bir dosya oluştur
                var stream = new FileStream(saveLocation, FileMode.Create);

                //dosyayaı fiziksel olarak sunucuya yazar
                model.ImageFile.CopyTo(stream);

                model.ImageUrl = "/images/" + filename + extension;
            }

            _context.Products.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            List<SelectListItem> values = (from x in _context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }
                                     ).ToList();
            ViewBag.v = values;

            var value = _context.Products.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product model)
        {
            if (model.ImageFile != null)
            {
                //uygulamanın çalıştığı dizini al
                var currenDirectory = Directory.GetCurrentDirectory();

                //uygulamanın uzantısını al (jpg,png)
                var extension = Path.GetExtension(model.ImageFile.FileName);

                //benzersiz bir dosya adı oluştur
                var filename = Guid.NewGuid().ToString();

                //Kayıt edilecek Dosyanın yolu
                var saveLocation = Path.Combine(currenDirectory, "wwwroot/images", filename + extension);

                //belirtilen konumda bir dosya oluştur
                var stream = new FileStream(saveLocation, FileMode.Create);

                //dosyayaı fiziksel olarak sunucuya yazar
                model.ImageFile.CopyTo(stream);

                model.ImageUrl = "/images/" + filename + extension;
            }

            _context.Products.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            _context.Products.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
