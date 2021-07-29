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
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDAL)
        {
            _creditCardDal = creditCardDAL;
        }

        
        public IResult Add(CreditCard creditCard)
        {
            IResult result = BusinessRules.Run(IsCardExist(creditCard));

            if (result != null)
            {
                return result;
            }
            _creditCardDal.Add(creditCard);
            return new SuccessResult();
        }

        
        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult();
        }

        
        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult();
        }

        
        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        
        public IDataResult<List<CreditCard>> GetByCustomer(int id)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(c => c.CustomerId == id));
        }

        public IDataResult<CreditCard> FindByID(int Id)
        {
            CreditCard p = new CreditCard();
            if (!_creditCardDal.GetAll().Any(x => x.CreditCardId == Id))
            {
                return new ErrorDataResult<CreditCard>(Messages.NotExist + "credit card");
            }
            p = _creditCardDal.GetAll().FirstOrDefault(x => x.CreditCardId == Id);
            return new SuccessDataResult<CreditCard>(p);
        }


        private IResult IsCardExist(CreditCard creditCard)
        {
            var result = _creditCardDal.Get(c =>
            c.OwnerName == creditCard.OwnerName
            && c.CreditCardNumber == creditCard.CreditCardNumber
            && c.CVV == creditCard.CVV
            && c.ExpirationDate == creditCard.ExpirationDate);

            if (result != null)
            {
                return new ErrorResult(Messages.CardExist);
            }

            return new SuccessResult();
        }


    }
}
