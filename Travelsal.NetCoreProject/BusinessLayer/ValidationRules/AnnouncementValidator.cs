using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementAddDTO>
    {
        public AnnouncementValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Lütfen başlık kısmını boş bırakmayanız.");
            RuleFor(x=>x.Title).MinimumLength(5).WithMessage("Lütfen başlık kısmı 5 karakterden fazla olsun.");
            RuleFor(x=>x.Title).MaximumLength(50).WithMessage("Lütfen başlık kısmı 50 karakterden az olsun.");
            


            RuleFor(x=>x.Content).NotEmpty().WithMessage("Lütfen duyuru kısmını boş bırakmayanız.");
            RuleFor(x=>x.Content).MinimumLength(20).WithMessage("Lütfen duyuru kısmı 20 karakterden fazla olsun.");
            RuleFor(x=>x.Content).MaximumLength(500).WithMessage("Lütfen duyuru kısmı 500 karakterden az olsun.");
        }
    }
}
