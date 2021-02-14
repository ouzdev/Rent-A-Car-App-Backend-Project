using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //------------------- Get All -----------------------------
            //GetAll(carManager);


            //-------------------- Get By Id --------------------------
          
            //GetById(carManager);


            //--------------------- Add  ------------------------------
           

            //CarAdd(carManager);


            //----------------------- Delete --------------------------
            
            
            //CarDeleted(carManager);

            //---------------------- Update ---------------------------

            //CarUpdated(carManager,3);
        }

        private static void CarUpdated(CarManager carManager,int id)
        {
            Car car = carManager.GetById(id).Data;
            car.Description = "Değiştirildi.";
            var result = carManager.Update(car);
            Console.WriteLine(result.Message);
        }

        private static void CarDeleted(CarManager carManager)
        {
            Console.WriteLine("Hangi Id e Sahip Aracı Silmek İstiyorsunuz ?");
            int carId = Convert.ToInt32(Console.ReadLine());
            var result = carManager.Delete(new Car { Id = carId });
            Console.WriteLine(result.Message);
        }

        private static void CarAdd(CarManager carManager)
        {
            Car car = new Car()
            {
                BrandId = 1,
                ColorId = 2,
                DailyPrice = 15000,
                Description = "Açıklama",
                ModelYear = 2020,
            };
            var result = carManager.Add(car);
            Console.WriteLine(result.Message, result.Success);
        }

        private static void GetById(CarManager carManager)
        {
            var getById = carManager.GetById(1);
            Console.WriteLine(getById.Data.ModelYear);
        }

        private static void GetAll(CarManager carManager)
        {
            var getAll = carManager.GetAll();
            foreach (var item in getAll.Data)
            {
                Console.WriteLine(item.ModelYear);
            }
        }
    }
}
