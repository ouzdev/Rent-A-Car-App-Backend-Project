using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.CarImageDTOs
{
    public class UpdateCarImageDto : IDto
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public IFormFile File { get; set; }
    }
}
