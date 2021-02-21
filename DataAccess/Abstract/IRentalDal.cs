using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs.RentalDTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        bool IsCarAvailable(int id);
        List<GetRentalDetailDTO> GetRentalDetails();
    }
}
