using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.CarId).NotEmpty();

            RuleFor(r => r.CustomerId).NotEmpty();

            RuleFor(r => r.Id).NotEmpty();

            RuleFor(r => r.RentDate).NotEmpty();
            RuleFor(r => r.RentDate).Must(RentDateValid).WithMessage("2010 yılından ve sonrası için tarih yazabilirsiniz...");

            RuleFor(r => r).Must(ReturnDateValid).When(r => r.ReturnDate != null).WithMessage("Hatalı tarih");
            //RuleFor(r => r.ReturnDate).ExclusiveBetween(new DateTime(2010, 1, 1, 0, 0, 0), DateTime.Now);
        }

        private bool ReturnDateValid(Rental arg)
        {
            return arg.RentDate < arg.ReturnDate && arg.ReturnDate < DateTime.Now;
        }

        private bool RentDateValid(DateTime arg)
        {
            DateTime time = new DateTime(2010, 1, 1, 0, 0, 0);
            if (arg > time)
            {
                return true;
            }
            return false;
        }
    }
}
