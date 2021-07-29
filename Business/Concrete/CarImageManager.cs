using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }


        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.CarImageId == id));
        }
        
        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId);
            if (result.Any()) return new SuccessDataResult<List<CarImage>>(result);
            return new SuccessDataResult<List<CarImage>>(new List<CarImage>
            {
                new CarImage{ ImagePath = "default.jpg", Date = DateTime.Now }
            });
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }



       // [ValidationAspect(typeof(CarImageValidator))]

        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }

            var oldPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\wwwroot")) + _carImageDal.Get(p => p.CarImageId == carImage.CarImageId).ImagePath;

            carImage.ImagePath = FileHelper.Update(oldPath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        //[ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }



        //business rules
        private IResult CheckImageLimitExceeded(int carId)
        {
            var carImageCount = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (carImageCount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }


        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\uploads\default.jpg";

                var result = _carImageDal.GetAll(c => c.CarId == id).Any();

                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>();

                    carImage.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });

                    return new SuccessDataResult<List<CarImage>>(carImage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));
        }
        private IResult CheckCarImagesCount(int carId)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carId).Count < 5;
            if (!result) return new ErrorResult(Messages.CarImageCountExceeded);
            return new SuccessResult();
        }
    }
}
