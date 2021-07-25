using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs.BrandDTOs
{
    public class AddBrandDto:IDto
    {
        public string Name { get; set; }
    }
}
