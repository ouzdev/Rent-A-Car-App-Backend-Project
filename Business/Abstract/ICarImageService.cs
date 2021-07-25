using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs.CarImageDTOs;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(AddCarImageDto carImage);
        IResult Update(UpdateCarImageDto carImage);
        IResult Delete(CarImage image);
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetImageByCarId(int id);
        IResult CheckImageCount(int id);
        IDataResult<string> UploadImage(List<IFormFile> File);
    }
}
