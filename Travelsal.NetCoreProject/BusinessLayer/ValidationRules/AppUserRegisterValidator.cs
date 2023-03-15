using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTO>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanını boş bırakmayınız.");

            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim alanını boş bırakmayınız.");

            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı alanını boş bırakmayınız.");
            RuleFor(x => x.Username).MinimumLength(6).WithMessage("Kullanıcı adı en az 6 karakterden oluşmalıdır.");

            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanını boş bırakmayınız.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanını boş bırakmayınız.");
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("Şifreniz en az 8 karakter olmalıdır.");

            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre tekrarı alanını boş bırakmayınız.");
            RuleFor(x => x.ConfirmPassword).Equal(y=>y.Password).WithMessage("Şifreler birbiriyle uyuşmuyor.");
        }
    }
}
