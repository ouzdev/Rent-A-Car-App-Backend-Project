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
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());


            //------------------- Get All -----------------------------
            //GetAll(carManager);


            //-------------------- Get By Id --------------------------

            GetById(carManager, 2);


            //--------------------- Add  ------------------------------
            BrandGetAll(brandManager);

            Car car = new Car();
            Console.WriteLine("Lütfen Eklemek İstediğiniz Arabanın Adını Giriniz.");
            car.Name = Console.ReadLine();
            Console.WriteLine("Lütfen Eklemek İstediğiniz Arabanın Marka ID değerini Giriniz.");
            car.BrandId = int.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen Eklemek İstediğiniz Arabanın Renk ID değerini Giriniz.");
            car.ColorId = int.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen Eklemek İstediğiniz Arabanın Açıklamasını Giriniz.");
            car.Description = Console.ReadLine();
            Console.WriteLine("Lütfen Eklemek İstediğiniz Arabanın Açıklamasını Giriniz.");
            car.DailyPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen Eklemek İstediğiniz Arabanın Modelini Sayısal Olarak Giriniz.");
            car.ModelYear = int.Parse(Console.ReadLine());
            CarAdd(carManager,car);


            //----------------------- Delete --------------------------


            //CarDeleted(carManager);

            //---------------------- Update ---------------------------

            //CarUpdated(carManager,3);

            //---------------------- GetCarsByBrandId -----------------
            //GetCarsByBrandId(carManager, 2);

            //---------------------- GetCarsByColorId -----------------

            //GetCarsByColorId(carManager,3);

            //--------------------BRAND CRUD OPERATİON ----------------


            //-------------------Get All---------------------------- -

            //BrandGetAll(brandManager);

            //--------------------Get By Id --------------------------

            //BrandGetById(brandManager, 1);

            //---------------------Add------------------------------

            //BrandAdd(brandManager, new Brand { Name = "Scania" });


            //-----------------------Delete--------------------------
            //BrandDelete(brandManager);

            //----------------------Update-------------------------- -
            //BrandUpdate(brandManager,10);

            //--------------------Color CRUD OPERATİON ----------------

            //ColorManager colorManager = new ColorManager(new EfColorDal());

            //-------------------Get All---------------------------- -

            //BrandGetAll(brandManager);

            //--------------------Get By Id --------------------------

            //BrandGetById(brandManager, 1);

            //---------------------Add------------------------------

            //BrandAdd(brandManager, new Brand { Name = "Scania" });


            //-----------------------Delete--------------------------
            //BrandDelete(brandManager);

            //----------------------Update-------------------------- -
            //BrandUpdate(brandManager,10);

        }

        private static void BrandUpdate(BrandManager brandManager, int id)
        {
            Brand brand = brandManager.GetById(id).Data;
            brand.Name = "Mazda Motors";
            Console.WriteLine(brandManager.Update(brand).Message);
        }

        private static void BrandDelete(BrandManager brandManager)
        {
            BrandGetAll(brandManager);
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Silmek istediğiniz markının ID değerini tuşlayınız.");
            int brandId = int.Parse(Console.ReadLine());
            Console.Write(brandManager.Delete(new Brand { Id = brandId }).Message);
        }

        private static void BrandAdd(BrandManager brandManager, Brand brand)
        {
            Console.WriteLine(brandManager.Add(brand).Message);
        }

        private static void BrandGetById(BrandManager brandManager, int id)
        {
            Console.WriteLine(brandManager.GetById(id).Data.Name);
        }

        private static void BrandGetAll(BrandManager brandManager)
        {
            foreach (var item in brandManager.GetAll().Data)
            {
                Console.WriteLine(item.Id + "---" + item.Name);
            }
        }

        private static void GetCarsByColorId(CarManager carManager, int id)
        {
            Console.WriteLine(carManager.GetCarsByBrandId(id).Message);
            foreach (var item in carManager.GetCarsByBrandId(id).Data)
            {
                Console.WriteLine(item.Description);
            }
        }

        private static void GetCarsByBrandId(CarManager carManager, int id)
        {
            Console.WriteLine(carManager.GetCarsByBrandId(id).Message);
            foreach (var item in carManager.GetCarsByBrandId(id).Data)
            {
                Console.WriteLine(item.Description);
            }
        }

        private static void CarUpdated(CarManager carManager, Car car)
        {
            car = carManager.GetById(car.Id).Data;
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

        private static void CarAdd(CarManager carManager, Car car)
        {
            var result = carManager.Add(car);
            Console.WriteLine(result.Message, result.Success);
        }

        private static void GetById(CarManager carManager, int id)
        {
            var getById = carManager.GetById(id);
            Console.WriteLine(getById.Data.Name);
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
