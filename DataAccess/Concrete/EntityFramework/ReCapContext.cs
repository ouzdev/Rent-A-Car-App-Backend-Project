using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Scaffold - DbContext "server=DESKTOP-51P73VP; database=OG.RecapProjectDb; integrated security=true;" Microsoft.EntityFrameworkCore.SqlServer - OutputDir Models
            optionsBuilder.UseSqlServer(@"server=DESKTOP-51P73VP; database=OG.RecapProjectDb; integrated security=true;");
            base.OnConfiguring(optionsBuilder);
        }

        DbSet<Car> Cars { get; set; }
        DbSet<Color> Colors { get; set; }
        DbSet<Brand> Brands { get; set; }
    }
}
