using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentcarContext>, ICarDal
    {
        public List<CarDetialDto> GetCarDetials()
        {
            using (RentcarContext context= new RentcarContext())
            {
                var result = from cr in context.Cars
                             join b in context.Brands
                             on cr.BrandId equals b.Id
                             join c in context.Colors
                             on cr.ColorId equals c.Id
                             select new CarDetialDto { BrandName = b.Name, CarId = cr.Id, ColorName = c.Name, DailyPrice = cr.DailyPrice };
                return result.ToList();
            }
        }
    }
}
