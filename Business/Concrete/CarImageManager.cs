using Business.Abstract;
using Business.Constants;
using Core.Utilities.FileHelper.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CarImageDTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;

        }

        public IResult Add(AddCarImageDto carImageDto)
        {
            var imagePath = _fileHelper.UploadFile(carImageDto.File);
            if (imagePath.Success)
            {
                CarImage carImage = new CarImage
                {
                    Date = DateTime.Now,
                    ImagePath = imagePath.Data,
                    CarId = carImageDto.CarId

                };
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.AddCarImage);
            }
            return new ErrorResult(imagePath.Message);

        }

        public IResult Delete(CarImage image)
        {
            _carImageDal.Delete(image);
            return new SuccessResult(Messages.DeleteCarImage);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();
            return new SuccessDataResult<List<CarImage>>(result, Messages.GetAllCarImage);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            var result = _carImageDal.Get(p => p.Id == id);
            return new SuccessDataResult<CarImage>(result, Messages.GetCarImageById);
        }

        public IDataResult<List<CarImage>> GetImageByCarId(int id)
        {
            var result = _carImageDal.GetAll(p => p.CarId == id);
            return new SuccessDataResult<List<CarImage>>(result, Messages.GetCarImageByCarId);
        }

        public IResult Update(UpdateCarImageDto updateCarImageDto)
        {

               _carImageDal.Update()
        }
    }
}
