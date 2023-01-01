using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Id);
            }

            Console.WriteLine("Ekleme Yapıldıktan sonra---------");
            Car car1 = new Car {Id=6, BrandId=3, ColorId=3, DailyPrice=700, Description="İyi durumda", ModelYear="2016" };

            carManager.Add(car1);

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Id);
            }
        }
    }
}
