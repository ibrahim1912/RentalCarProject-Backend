using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()//GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                                 //from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join color in context.Colors
                             on c.ColorId equals color.ColorId
                             join u in context.Users
                            on cu.UserId equals u.UserId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 BrandName = b.BrandName,
                                 //CarId= c.CarId,
                                 ColorName=color.ColorName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 UserName = u.FirstName + " " + u.LastName,
                                 //CustomerId=cu.CustomerId,

                             };


                return result.ToList();
            }
        }

       
    }
}
