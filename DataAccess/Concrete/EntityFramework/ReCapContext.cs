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
            optionsBuilder.UseSqlServer(@"server=DESKTOP-51P73VP; database=OG.RecapProjectDb; integrated security=true;");
            base.OnConfiguring(optionsBuilder);
        }

        DbSet<Car> Cars { get; set; }
    }
}
