using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //burda enttiy framework kodları yazılır.
    //E.F veritabanındaki tabloyu class gbi ilişkilendirir,bütün operasyonları yani sqlleri linq ile yapılan ortam
    //E.F veritabanı ile kodlar arasında bir ilişki kurar,veritabı işlerini yapar
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto()
                             {
                                 CarId = c.CarId,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 BrandId=b.BrandId,
                                 ColorId=co.ColorId,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear
                             };
                //return result.ToList();
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }

        public CarDetailDto GetCarDetails(int carId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from car in context.Cars.Where(c => c.CarId == carId)

                             join color in context.Colors
                             on car.ColorId equals color.ColorId

                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId

                             select new CarDetailDto()
                             {
                                 CarId = car.CarId,
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 BrandId = brand.BrandId,
                                 ColorId = color.ColorId,
                                 ColorName = color.ColorName,

                                 
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear,
                                 
                                 //MinFindexScore = car.MinFindexScore
                             };

                return result.SingleOrDefault();
            }
        }
    }
}
