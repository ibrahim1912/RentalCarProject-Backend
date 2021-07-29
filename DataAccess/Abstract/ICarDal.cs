using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;


namespace DataAccess.Abstract
{
   public interface ICarDal: IEntityRepository<Car>  //Car ile ilgili Db de yapılacak operasyonları içerir
    {
       // List<CarDetailDto> GetCarDetails();

        List<CarDetailDto> GetCarsDetails(Expression<Func<CarDetailDto, bool>> filter = null);
        CarDetailDto GetCarDetails(int carId);
        
    }
}
