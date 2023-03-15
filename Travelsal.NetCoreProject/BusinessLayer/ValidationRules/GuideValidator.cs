using DTOLayer.DTOs.GuideDTOs;
using EntityLayer.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<GuideViewDto>
    {
        public GuideValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Lütfen Rehber Adını Giriniz...");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Lütfen Rehber Açıklamasını Giriniz...");
            RuleFor(x=>x.Image).NotEmpty().WithMessage("Lütfen Rehber Görselini Giriniz...");
        }
    }
}
