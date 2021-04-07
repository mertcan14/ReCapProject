using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator: AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(c => c.CreditNumber).NotEmpty();
            RuleFor(c => c.CreditNumber).MinimumLength(16);
            RuleFor(c => c.CreditNumber).MaximumLength(16);

            RuleFor(c => c.CardCvv).NotEmpty();
            RuleFor(c => c.CardCvv).MinimumLength(3);
            RuleFor(c => c.CardCvv).MaximumLength(3);

            RuleFor(c => c.NameOnCard).NotEmpty();
            RuleFor(c => c.NameOnCard).Must(checkWhiteSpace);
        }

        private bool checkWhiteSpace(string arg)
        {
            if (arg.Contains(" "))
            {
                return true;
            }
            return false;
        }
    }
}
