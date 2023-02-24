using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.AddedSuccessful);
            }

            return new ErrorResult(Messages.AddedNotSuccessful);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.DeletedSuccessful);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==06)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.ListedSuccessful);
        }

        public IDataResult<List<CarDetialDto>> GetCarDetials()
        {
            return new SuccessDataResult<List<CarDetialDto>>(_carDal.GetCarDetials(), Messages.GotDetialSuccessful);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult UpDate(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.UpdatedSuccessful);
        }
    }
}
