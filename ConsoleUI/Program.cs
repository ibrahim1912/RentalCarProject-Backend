using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //InMemoryTest();
            //EfCarGetBrandIdTest();
            //EfCarAddTest();
            //EfCarDeleteTest();
            //EfCarUpdateTest();
            //EfCarDalTest();
            //EfCarGetByIdTest();
            //EfBrandGetByIdTest();
            //EfBrandGetAllTest();
            //EfCarGetCarDetailsTest();

            Console.ReadLine();
        }

        private static void EfCarGetCarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + " / " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void EfBrandGetAllTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            foreach (var brand in result.Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void EfBrandGetByIdTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetById(2);
            Console.WriteLine(result.Data.BrandName);
        }

        private static void EfCarGetByIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetById(2);
            Console.WriteLine(result.Data.CarName);
        }

        private static void EfCarUpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { CarId=3016,BrandId = 8, CarName = "Volvo", ColorId = 7, DailyPrice = 1200, Description = "Benzin", ModelYear = 2020 });
        }

        private static void EfCarDeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car { CarId = 14 });
        }

        private static void EfCarAddTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            carManager.Add(new Car { BrandId = 8, CarName = "Volvo", ColorId = 7, DailyPrice = 900, Description = "Benzin", ModelYear = 2020 });
        }

        private static void EfCarGetBrandIdTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetByBrand(2);
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void EfCarDalTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();

            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName);
            }
        }

        private static void InMemoryTest()
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());   //buuniessdaki constructorun çalıştırpı yer parantez içi
            var result = carManager.GetAll();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.CarName);
            }
        }
    }
}
