using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<Car>> GetAll()
        {
            var result = _carDal.GetAll();
            return new SuccessDataResult<List<Car>>(result, Messages.CarListed);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<CarDetailsDTO>> GetCarDetails()
        {
            var result = _carDal.GetCarDetails();
            return new SuccessDataResult<List<CarDetailsDTO>>(result, Messages.GetCarDetails);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            var result = _carDal.GetAll(c => c.BrandId == id);

            return new SuccessDataResult<List<Car>>(result, Messages.GetCarsBrandId);
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            var result = _carDal.GetAll(c => c.ColorId == id);
            return new SuccessDataResult<List<Car>>(result, Messages.GetCarsColorId);
        }

        [SecuredOperation("car.update,administrator")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [SecuredOperation("car.add,administrator")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [PerformanceAspect(0)]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        [SecuredOperation("car.delete,administrator")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
    }
}
