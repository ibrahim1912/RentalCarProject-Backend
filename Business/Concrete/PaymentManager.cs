using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        //testing
        public IResult MakePayment(Payment payment)
        {
            if (payment.Amount < 1000)
            {
                return new ErrorResult("PAYMENT TEST ERROR");
            }
            return new SuccessResult();
        }
    }
}
