using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class AppUserLoginValidator : AbstractValidator<AppUserLoginDTO>
    {
        public AppUserLoginValidator() {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı girişini boş bırakmayınız.");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre girişini boş bırakmayınız.");
        }
    }
}
