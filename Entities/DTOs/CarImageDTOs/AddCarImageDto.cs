using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.CarImageDTOs
{
    public class AddCarImageDto : IDto
    {
        public int CarId { get; set; }
        public IFormFile File { get; set; }
    }
}
