using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {

        }
        public static void RentUpdate()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            RentGetAll();
            Console.WriteLine("Lütfen değiştirmek istediğiniz markanın ID değerini giriniz.");
            var rentId = int.Parse(Console.ReadLine());

            Rental rental = rentalManager.GetById(rentId).Data;
            Console.WriteLine("Lütfen yeni teslim tarihini tuşlayınız");
            var rentalReturnDate = DateTime.Parse(Console.ReadLine());
            rental.ReturnDate = rentalReturnDate;
            Console.WriteLine(rentalManager.Update(rental).Message);
        }

        public static void RentDelete()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            RentGetAll();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Silmek istediğiniz kayıtın ID değerini tuşlayınız.");
            int rentId = int.Parse(Console.ReadLine());
            Console.Write(rentalManager.Delete(new Rental { Id = rentId }).Message);
        }

        public static void RentAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rent = new Rental();
            rent.CarId = 1;
            rent.CustomerId = 1;
            rent.RentDate = DateTime.Now;
            rent.ReturnDate = DateTime.Now.AddDays(2);
            Console.WriteLine(rentalManager.Add(rent).Message);

        }

        public static void RentGetById()
        {
            RentGetAll();
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Console.WriteLine("Lütfen Kiralanan kayıtın ID değerini yazınız.");
            var rentId = int.Parse(Console.ReadLine());
            Console.WriteLine(rentalManager.GetById(rentId).Data);
        }

        public static void RentGetAll()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            foreach (var item in rentalManager.GetListRentalDetails().Data)
            {
                Console.WriteLine(item.Id + "---" + item.CustomerName + "---" + item.CarName + "---" + item.RentDate + "---" + item.ReturnDate);
            }
        }
        public static void ColorUpdate()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            ColorGetAll();
            Console.WriteLine("Lütfen değiştirmek istediğiniz markanın ID değerini giriniz.");
            var colorId = int.Parse(Console.ReadLine());

            Color color = colorManager.GetById(colorId).Data;
            Console.WriteLine("Lütfen yeni rengi tuşlayınız");
            var colorName = Console.ReadLine();
            color.Name = colorName;
            Console.WriteLine(colorManager.Update(color).Message);
        }

        public static void ColorDelete()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            ColorGetAll();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Silmek istediğiniz rengin ID değerini tuşlayınız.");
            int colorId = int.Parse(Console.ReadLine());
            Console.Write(colorManager.Delete(new Color { Id = colorId }).Message);
        }

        public static void ColorAdd()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color();
            Console.WriteLine("Lütfen eklemek istediğiniz rengi tuşlayınız");
            var colorName = Console.ReadLine();
            color.Name = colorName;
            Console.WriteLine(colorManager.Add(color).Message);
        }

        public static void ColorGetById()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine("Lütfen Rengin ID değerini yazınız.");
            var colorId = int.Parse(Console.ReadLine());
            Console.WriteLine(colorManager.GetById(colorId).Data.Name);
        }

        public static void ColorGetAll()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var item in colorManager.GetAll().Data)
            {
                Console.WriteLine(item.Id + "---" + item.Name);
            }
        }
        public static void BrandUpdate()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            BrandGetAll();
            Console.WriteLine("Lütfen değiştirmek istediğiniz markanın ID değerini giriniz.");
            var brandId = int.Parse(Console.ReadLine());

            Brand brand = brandManager.GetById(brandId).Data;
            Console.WriteLine("Lütfen yeni markayı tuşlayınız");
            var brandName = Console.ReadLine();
            brand.Name = brandName;
            Console.WriteLine(brandManager.Update(brand).Message);
        }

        public static void BrandDelete()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            BrandGetAll();
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Silmek istediğiniz markının ID değerini tuşlayınız.");
            int brandId = int.Parse(Console.ReadLine());
            Console.Write(brandManager.Delete(new Brand { Id = brandId }).Message);
        }

        public static void BrandAdd()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand();
            Console.WriteLine("Lütfen eklemek istediğiniz markayı tuşlayınız");
            var brandName = Console.ReadLine();
            brand.Name = brandName;
            Console.WriteLine(brandManager.Add(brand).Message);
        }

        public static void BrandGetById()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine("Lütfen Marka ID değerini yazınız.");
            var brandId = int.Parse(Console.ReadLine());
            Console.WriteLine(brandManager.GetById(brandId).Data.Name);
        }

        public static void BrandGetAll()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var item in brandManager.GetAll().Data)
            {
                Console.WriteLine(item.Id + "---" + item.Name);
            }
        }

        public static void GetCarsByColorId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Lütfen Araç Renk ID değerini tuşlayınız.");
            var colorId = int.Parse(Console.ReadLine());
            Console.WriteLine(carManager.GetCarsByBrandId(colorId).Message);
            foreach (var item in carManager.GetCarsByBrandId(colorId).Data)
            {
                Console.WriteLine(item.Description);
            }
        }

        public static void GetCarsByBrandId()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Lütfen Araba Renk ID değerini tuşlayınız.");
            var brandId = int.Parse(Console.ReadLine());
            Console.WriteLine(carManager.GetCarsByBrandId(brandId).Message);
            foreach (var item in carManager.GetCarsByBrandId(brandId).Data)
            {
                Console.WriteLine(item.Id + "---" + item.Name + "---" + item.DailyPrice + "---" + item.Description);
            }
        }

        public static void CarUpdated()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            CarGetAll();
            Console.WriteLine("Güncellemek İstediğiniz Aracın ID değerini tuşlayınız.");
            var carId = int.Parse(Console.ReadLine());
            var carUpdated = carManager.GetById(carId);
            Console.WriteLine("Lütfen Eklemek İstediğiniz Arabanın Adını Giriniz.");
            carUpdated.Data.Name = Console.ReadLine();
            Console.WriteLine("Lütfen Eklemek İstediğiniz Arabanın Marka ID değerini Giriniz.");
            carUpdated.Data.BrandId = int.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen Eklemek İstediğiniz Arabanın Renk ID değerini Giriniz.");
            carUpdated.Data.ColorId = int.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen Eklemek İstediğiniz Arabanın Açıklamasını Giriniz.");
            carUpdated.Data.Description = Console.ReadLine();
            Console.WriteLine("Lütfen Eklemek İstediğiniz Arabanın Günlük Kiralama Ücretini Giriniz.");
            carUpdated.Data.DailyPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen Eklemek İstediğiniz Arabanın Modelini Sayısal Olarak Giriniz.");
            carUpdated.Data.ModelYear = int.Parse(Console.ReadLine());
            var result = carManager.Update(carUpdated.Data);
            Console.WriteLine(result.Message);
        }

        public static void CarDeleted()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Hangi Id e Sahip Aracı Silmek İstiyorsunuz ?");
            int carId = Convert.ToInt32(Console.ReadLine());
            var result = carManager.Delete(new Car { Id = carId });
            Console.WriteLine(result.Message);
        }

        public static void CarAdd()
        {
            Console.WriteLine("Not => Eklemek istediğiniz aracın rengi veya markası yoksa ilk o bilgileri siteme ekleyiniz.");
            Console.WriteLine("------------------Renkler--------------------------");
            ColorGetAll();
            Console.WriteLine("------------------Markalar--------------------------");
            BrandGetAll();

            CarManager carManager = new CarManager(new EfCarDal());
            Car car = new Car();
            Console.WriteLine("Lütfen Eklemek İstediğiniz Arabanın Adını Giriniz.");
            car.Name = Console.ReadLine();
            Console.WriteLine("Lütfen Eklemek İstediğiniz Arabanın Marka ID değerini Giriniz.");
            car.BrandId = int.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen Eklemek İstediğiniz Arabanın Renk ID değerini Giriniz.");
            car.ColorId = int.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen Eklemek İstediğiniz Arabanın Açıklamasını Giriniz.");
            car.Description = Console.ReadLine();
            Console.WriteLine("Lütfen Eklemek İstediğiniz Arabanın Günlük Kiralama Ücretini Giriniz.");
            car.DailyPrice = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Lütfen Eklemek İstediğiniz Arabanın Modelini Sayısal Olarak Giriniz.");
            car.ModelYear = int.Parse(Console.ReadLine());
            var result = carManager.Add(car);
            Console.WriteLine(result.Message, result.Success);
        }

        public static void CarGetById()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine("Lütfen Araba ID değerini giriniz.");
            var carId = int.Parse(Console.ReadLine());
            var getById = carManager.GetById(carId);
            Console.WriteLine(getById.Data.Name);
        }

        public static void CarGetAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var getAll = carManager.GetAll();
            foreach (var item in getAll.Data)
            {
                Console.WriteLine(item.Name);
            }
        }

        public static void ListCarDetail()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var getAll = carManager.GetCarDetails();

            foreach (var item in getAll.Data)
            {
                Console.WriteLine(item.CarName + "---" + item.BrandName + "---" + item.ColorName + "---" + item.DailyPrice);
            }

        }

    }
}
