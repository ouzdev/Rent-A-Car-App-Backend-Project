using Core.Utilities.Result;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImage image);
        IResult Update(IFormFile file, CarImage image);
        IResult Delete(CarImage image);
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetImageByCarId(int id);
    }
}
