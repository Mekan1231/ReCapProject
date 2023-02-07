using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarDtoTest();

            //Brandtest();
            ICustomerService customer = new CustomerManager(new EfCustomerDal());

            var result = customer.GetAll();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.CompanyName+"  "+item.UserId);
            }

        }

        private static void Brandtest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetAll();
            foreach (var item in result.Data)
            {
                Console.WriteLine(item.Id + " / " + item.Name);
            }

            Console.WriteLine();
            Console.WriteLine(result.Message);
        }

        private static void CarDtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var item in carManager.GetCarDetials().Data)
            {
                Console.WriteLine(item.CarId + " / " + item.BrandName + " / " + " / " + item.ColorName + " / " + item.DailyPrice);
            }
        }
    }
}
