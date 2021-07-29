using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal: EfEntityRepositoryBase<Customer, CarRentalContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from customer in context.Customers 
                             join users in context.Users on customer.UserId equals users.UserId

                             select new CustomerDetailDto()
                             {
                                 CustomerId = customer.CustomerId,
                                 CompanyName = customer.CompanyName,
                                 FirstName = users.FirstName,
                                 LastName = users.LastName,
                                 Email = users.Email

                             };
                return result.ToList();

            }


        }
    }
}




            