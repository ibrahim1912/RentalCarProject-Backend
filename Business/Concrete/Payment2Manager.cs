using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class Payment2Manager : IPayment2Service
    {
        IPayment2Dal _paymentDal;
        ICustomerService _customerService;
        ICreditCardService _creditCardService;
        public Payment2Manager(
            IPayment2Dal paymentDal,
            ICustomerService customerService,
            ICreditCardService creditCardService
            )
        {
            _paymentDal = paymentDal;
            _creditCardService = creditCardService;
            _customerService = customerService;
        }

        public IResult Add(Payment2 entity)
        {
            IResult result = BusinessRules.Run(
                CheckIsCreditCardExist(entity.CreditCardNumber, entity.ExpirationDate, entity.CVV));

            if (result != null)
            {
                return result;
            }
            _paymentDal.Add(entity);

            return new SuccessResult("Payment" + Messages.AddSingular);
        }

        public IResult Delete(Payment2 entity)
        {
            _paymentDal.Delete(entity);
            return new SuccessResult("Payment" + Messages.DeleteSingular);
        }

       

        public IDataResult<Payment2> Get(Payment2 entity)
        {
            return new SuccessDataResult<Payment2>(_paymentDal.Get(x => x.Payment2Id == entity.Payment2Id));
        }

        

        public IDataResult<List<Payment2>> GetAll()
        {
            return new SuccessDataResult<List<Payment2>>(_paymentDal.GetAll());
        }

        public IDataResult<Payment2> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IResult GetList(List<Payment2> list)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Payment2 entity)
        {
            _paymentDal.Update(entity);
            return new SuccessResult("Payment" + Messages.UpdateSingular);
        }

        private IResult CheckIsCreditCardExist(string cardNumber, string expirationDate, string CVV)
        {
            if (_creditCardService.GetAll().Data.Any(c => c.CreditCardNumber == cardNumber))
            {
                if (!_creditCardService.GetAll().Data.Any(
                    c => c.CreditCardNumber == cardNumber &&
                    c.ExpirationDate == expirationDate &&
                    c.CVV==CVV
                    ))
                {
                    return new ErrorResult(Messages.NotExist + "credit card");
                }
            }
            return new SuccessResult();
        }
    }
}

