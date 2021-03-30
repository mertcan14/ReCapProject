using Business.Abstract;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentsManager : IPaymentService
    {
        public IResult Pay(CreditCardDto creditCard)
        {
            var result = CheckCreditCart(creditCard);
            if (result == true)
            {
                return new SuccessResult("Çekim Başarılı");
            }
            else
            {
                return new ErrorResult("Çekim Başarısız");
            }
        }

        public bool CheckCreditCart(CreditCardDto creditCard)
        {
            int firstCardNumber = Convert.ToInt32(creditCard.creditNumber.Substring(0,1));
            int firstCardCVV = Convert.ToInt32(creditCard.cardCVV.Substring(0, 1));
            if (firstCardNumber % 2 == 0)
            {
                if (firstCardCVV % 2 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (firstCardCVV % 2 == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
