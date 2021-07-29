using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FakePaymentManager : IFakePaymentService
    {
        public IResult FakePaymentExist(FakePayment fakePayment)
        {
            if (fakePayment.CardNumber == FakeCard.CardNUmber
                && fakePayment.MounthOfExp == FakeCard.MounthOfExp
                && fakePayment.YearOfExp == FakeCard.YearOfExp
                && fakePayment.CVC == FakeCard.CVC
                && fakePayment.Amount <= FakeCard.Amount)
            {
                return new SuccessResult(Messages.PaymentSuccessful);
            }

            return new ErrorResult(Messages.PaymentUnSeccessful);
        }
    }
}
