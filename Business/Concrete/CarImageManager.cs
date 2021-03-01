using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage image)
        {
            throw new System.NotImplementedException();
        }

        public IResult Delete(CarImage image)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<CarImage> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetImageByCarId(int id)
        {
            throw new System.NotImplementedException();
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage image)
        {
            throw new System.NotImplementedException();
        }
    }
}
