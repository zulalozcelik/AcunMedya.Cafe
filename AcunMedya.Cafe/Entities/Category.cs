﻿using System.ComponentModel.DataAnnotations;

namespace AcunMedya.Cafe.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string? CategoryName { get; set; }

        public List<Product> Products { get; set; }
    }
}
