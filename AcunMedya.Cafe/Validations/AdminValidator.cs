using AcunMedya.Cafe.Entities;
using FluentValidation;

namespace AcunMedyaCafe.Validations
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Kullanıcı Adı boş bırakılamaz!")
                .MinimumLength(2).WithMessage("Kullanıcı Adı en az 2 karakter olmalıdır!");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre boş bırakılamaz!")
                .MinimumLength(4).WithMessage("Şifre en az 4 karakter olmalıdır!");

            RuleFor(x => x.ProfilePhoto).NotEmpty().WithMessage("Profil Resmi Boş Geçilemez!");
        }
    }
}