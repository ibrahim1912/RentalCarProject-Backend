using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDto>> GetByBrand(int brandId);
        IDataResult<List<CarDetailDto>> GetByColor(int colorId);
        IDataResult<Car>GetById(int id);

        //IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<CarDetailDto>> GetCarsWithDetails();
       IDataResult<List<CarDetailDto>> GetCarDetails(int carId);
        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

        IDataResult<List<CarDetailDto>> GetCarsByBrandAndColor(int brandId, int colorId);

        /*void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
        List<Car> GetById();
         */


    }
}
