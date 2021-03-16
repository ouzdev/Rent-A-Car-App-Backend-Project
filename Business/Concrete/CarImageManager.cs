using Business.Abstract;
using Business.Constants;
using Core.Utilities.FileHelper.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.CarImageDTOs;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (CheckImageCount(carImageDto.CarId).Success)
            {
                var imagePath = _fileHelper.UploadFile(carImageDto.File);
                if (imagePath.Success)
                {
                    CarImage carImage = new CarImage
                    {
                        ImagePath = imagePath.Data,
                        CarId = carImageDto.CarId
                    };
                    _carImageDal.Add(carImage);
                    return new SuccessResult(Messages.AddCarImage);
                }
            }
            return new ErrorResult(Messages.PictureLimitExceeded);
        }

        public IResult CheckImageCount(int id)
        {
            var result = _carImageDal.GetAll(p => p.CarId == id);
            if (result.Count > 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
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
            var result = CheckIfCarImageNull(id);
            return new SuccessDataResult<CarImage>(result.Data.FirstOrDefault(), Messages.GetCarImageById);
        }

        public IDataResult<List<CarImage>> GetImageByCarId(int id)
        {
            var result = _carImageDal.GetAll(p => p.CarId == id);
            return new SuccessDataResult<List<CarImage>>(result, Messages.GetCarImageByCarId);
        }

        public IResult Update(UpdateCarImageDto carImageDto)
        {
            CarImage carImage = new CarImage
            {
                Id = carImageDto.Id,
                CarId = carImageDto.CarId
            };

            var fileOperation = _fileHelper.UploadFileUpdate(carImageDto.File);
            if (fileOperation.Success)
            {
                carImage.ImagePath = fileOperation.Data;
                _carImageDal.Update(carImage);
                return new SuccessResult(Messages.UpdateCarImage);
            }
            return new ErrorResult(fileOperation.Message);
        }

        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {

            string path = @"\wwwroot\images\placeholder.png";
            var result = _carImageDal.GetAll(p => p.CarId == id).Any();
            if (!result)
            {
                List<CarImage> carImage = new List<CarImage>();
                carImage.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });
                return new SuccessDataResult<List<CarImage>>(carImage);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == id));
        }
    }
}
