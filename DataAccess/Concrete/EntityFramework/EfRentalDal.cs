using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs.RentalDTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<GetRentalDetailDTO> GetRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from rent in context.Rentals
                              join customer in context.Users
                              on rent.CustomerId equals customer.Id
                              join car in context.Cars
                              on rent.CarId equals car.Id
                              select new GetRentalDetailDTO
                              {
                                  CarName = car.Name,
                                  CustomerName = customer.FirstName + " " + customer.LastName,
                                  Id = rent.Id,
                                  RentDate = rent.RentDate,
                                  ReturnDate = rent.ReturnDate
                              }
                              ).ToList();
                return result;
            }
        }

        public bool IsCarAvailable(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = context.Rentals.Any(x => x.Id == id && x.ReturnDate == null);
                return result;
            }
        }
    }
}
