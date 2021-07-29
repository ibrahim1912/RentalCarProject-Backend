using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarRentalContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CarRental;Trusted_Connection=True");
        }

        public DbSet<Car> Cars { get; set; }          //Nesneler ile Db tablolarını eşleştirdik.
        public DbSet<Brand> Brands { get; set; }      //Context ile bağladık Set ile eşitledik
        public DbSet<Color> Colors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Payment2> Payments { get; set; }

    }
}
