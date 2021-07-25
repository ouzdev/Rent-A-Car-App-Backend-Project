using Core.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Entities.DTOs.CarImageDTOs
{
    public class AddCarImageDto : IDto
    {
        public int CarId { get; set; }
        public List<IFormFile> File { get; set; }
    }
}
