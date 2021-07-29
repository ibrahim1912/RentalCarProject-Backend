using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService  //Data access i cağırmak gerek
    {

        ICarDal _carDal;       // data katmanıyla bağlantı

        public CarManager(ICarDal carDal)    //burda da concrete de hangi tekniği secerek onu yazcaz mainde
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //if (car.CarName.Length < 2 || car.DailyPrice < 0)
            //{
            //    //ilk benim yaptığım// throw new NotImplementedException("Name must be minimum 2 charecter and dailyprice must be grater than 0");
            //    return new ErrorResult(Messages.CarNameLengthInvalid + " / " + Messages.DailyPriceInvalid);
            //}

            //var context = new ValidationContext<Car>(car);
            //CarValidator carValidator = new CarValidator();
            //var result = carValidator.Validate(context);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}


            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded); // Result varkenki kullanım(true, "Ürün eklendi.");  //eski kullanım ("Ürün eklendi.")
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 04)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id));
        }

        //public IDataResult<List<Car>> GetCarsByBrandId(int id)
        //{
        //    return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id));
        //}

        //public IDataResult<List<Car>> GetCarsByColorId(int id)
        //{
        //    return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        //}

        public IDataResult<List<CarDetailDto>> GetCarsWithDetails()
        {
            //if (DateTime.Now.Hour == 05)
            //{
            //    return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintanceTime);
            //}
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails(), Messages.CarsListed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

        public IDataResult<List<CarDetailDto>> GetByBrand(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails(c => c.BrandId == brandId));
        }

        public IDataResult<List<CarDetailDto>> GetByColor(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarsDetails(c => c.CarId == carId));
        }

        //public IDataResult<List<CarDetailDto>> GetCarDetails(int carId)
        //{
        //    return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(carId));
        //}


        public IDataResult<List<CarDetailDto>> GetCarsByBrandAndColor(int brandId, int colorId)
        {
            List<CarDetailDto> car = (_carDal.GetCarsDetails(c => c.BrandId == brandId && c.ColorId == colorId));

            if (car == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.NoCar);
            }

            return new SuccessDataResult<List<CarDetailDto>>(car);

        }

        //public IDataResult<List<CarDetailDto>> GetCarDetails(int carId)
        //{
        //    return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(carId));
        //}
    }
}

