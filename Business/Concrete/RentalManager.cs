using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        //[SecuredOperation("rental.add")]
        [ValidationAspect(typeof(RentalValidator))]

        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run
                (
                CheckIfRentalCarExistWithIsNullReturnDate(rental.CarId),
                CheckIfExistReturnDateGreaterThanRentDate(rental.CarId, rental.RentDate)
               // CheckRentalCarAvailable(rental)
                );

            if (result != null)
            {
                return result;
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }
       

    public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 05)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(b => b.RentalId == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        private IResult CheckIfRentalCarExistWithIsNullReturnDate(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate == null).Any();
            if (result)
            {
                return new ErrorResult(Messages.RentalAddedError);
            }
            return new SuccessResult();
        }


        private IResult CheckIfExistReturnDateGreaterThanRentDate(int carId, DateTime rentDate)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId && r.ReturnDate > rentDate).Any();
            if (result)
            {
                return new ErrorResult(Messages.NotCarAvailable);
            }

            return new SuccessResult();

        }

        private IResult CheckRentalCarAvailable(Rental rental)
        {
            var result = _rentalDal.Get(r => (r.CarId == rental.CarId && r.ReturnDate == null)
            || (r.RentDate >= rental.RentDate && r.ReturnDate >= rental.RentDate));

            if (result != null)
            {
                return new ErrorResult(Messages.NotCarAvailable);
            }

            return new SuccessResult();
        }
    }
}
