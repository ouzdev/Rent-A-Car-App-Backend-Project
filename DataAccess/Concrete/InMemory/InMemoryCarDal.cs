using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{BrandId=1,ColorId=2,DailyPrice=13000,Description="BMW M3 GTT",ModelYear=2000,Id=1},
                new Car{BrandId=2,ColorId=2,DailyPrice=25000,Description="Toyota Supra",ModelYear=1997,Id=2},
                new Car{BrandId=3,ColorId=3,DailyPrice=80000,Description="Nissan R34 GTR",ModelYear=1998,Id=3},
                new Car{BrandId=4,ColorId=1,DailyPrice=20000,Description="Nissan S15 Silvia",ModelYear=1995,Id=4},
                new Car{BrandId=5,ColorId=2,DailyPrice=28000,Description="Subaru WRX",ModelYear=2010,Id=5},
                new Car{BrandId=6,ColorId=3,DailyPrice=6000,Description="Fiat Miafiro",ModelYear=1975,Id=6},
            };
        }
        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

        public void Delete(Car entity)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == entity.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            //var result = filter == null ? _cars.Where(filter);
            return null;

        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailsDTO> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
