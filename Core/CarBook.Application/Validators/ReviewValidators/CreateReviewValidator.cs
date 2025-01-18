using CarBook.Application.Features.Mediator.Commands.ReservationCommands;
using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidators
{
	public class CreateReviewValidator : AbstractValidator<CreateReviewCommand>
	{
        public CreateReviewValidator()
        {
            RuleFor(x=>x.CustomerName).NotEmpty().WithMessage("Lütfen Müşteri Adını Boş Geçmeyin");
            RuleFor(x => x.CustomerName).MinimumLength(2).WithMessage("En az 2 karakter girişi yapınız!");
            RuleFor(x => x.Rate).NotEmpty().WithMessage("Lütfen puan değeri giriniz.");
			RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen Yorum kısmını Boş Geçmeyin");
            RuleFor(x => x.Comment).MinimumLength(5).WithMessage("Yorum kısmına en az 5 karakterden fazla değer girmelisiniz");
            RuleFor(x => x.Comment).MaximumLength(200).WithMessage("Yorum kısmı 200 karakteri geçmemelidir");
        }
    }
}
