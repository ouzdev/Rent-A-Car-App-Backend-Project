using Core.Entities;
using System;

namespace Entities.DTOs.RentalDTOs
{
    public class GetRentalDetailDTO : IDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CarName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }

    }
}
