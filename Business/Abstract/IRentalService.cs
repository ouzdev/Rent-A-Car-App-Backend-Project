using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs.RentalDTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<Rental> GetById(int id);
        IDataResult<List<Rental>> GetAll();
        IResult IsCarAvailable(int id);
        IDataResult<List<GetRentalDetailDTO>> GetListRentalDetails();
    }
}
