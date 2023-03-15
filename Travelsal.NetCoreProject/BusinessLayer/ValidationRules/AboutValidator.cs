using EntityLayer.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	internal class AboutValidator : AbstractValidator<About>
	{
		public AboutValidator()
		{
			RuleFor(x=>x.Description).NotEmpty().WithMessage("Açıklama Kısmını Lütfen boş girmeyiniz...!");
		}
	}
}
