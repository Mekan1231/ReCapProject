using System;
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
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var item in carManager.GetCarDetials())
            {
                Console.WriteLine(item.CarId+" / "+item.BrandName+" / "+" / "+item.ColorName+" / "+item.DailyPrice);
            }

        }    
    }
}
