﻿using AcunMedya.Cafe.Entities;
using FluentValidation;

namespace AcunMedya.Cafe.Validations
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı boş geçilemez").
                                         MinimumLength(3).WithMessage("Kategori Adı en az 3 karakter olmalıdır");

        }
    }
}
