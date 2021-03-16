using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace ConsoleUI
{
    class Program
    {
        public static void Main(string[] args)
        {
            var carService = new CarService(new EfCarDal());
            AddNewCar(carService);
            GetAllCar(carService);
            GetCarById(carService, 1);
            UpdateCar(carService);
            DeleteCar(carService);

            var brandService = new BrandService(new EfBrandDal());
            AddNewBrand(brandService);
            GetAllBrand(brandService);
            GetBrandById(brandService, 1);
            UpdateBrand(brandService);
            DeleteBrand(brandService);

            var colorService = new ColorService(new EfColorDal());
            AddNewColor(colorService);
            GetAllColor(colorService);
            GetColorById(colorService, 1);
            UpdateColor(colorService);
            DeleteColor(colorService);

            Console.ReadLine();




            // var addNewCar = new Car { BrandId = 1,Name="Opel Corsa", ColorId = 1, DailyPrice = 10000, ModelYear = 2000, Id = 1, Description = "Günlük 10000 TL" };

            //TODO: Geliştirme aşamasında validasyon kuralları kullanılarak kontrol eklenecektir.
            //Web tarafında fluent validation olabilir.


            /*
             Kural 1: Araba ismi minimum 2 karakter olmalıdır.
             Kural 2: Araba günlük fiyatı 0'dan büyük olmalıdır.
             */

            //if (addNewCar.DailyPrice > 0 && (!string.IsNullOrEmpty(addNewCar.Name) && addNewCar.Name.Length >= 2))
            //{
            //    carService.Add(addNewCar);
            //}
            //else
            //{
            //    if (!(addNewCar.DailyPrice > 0))
            //    {
            //        Console.WriteLine("Araba günlük fiyatı 0'dan büyük olmalıdır.");
            //    }

            //    if (string.IsNullOrEmpty(addNewCar.Name) || addNewCar.Name.Length < 2)
            //    {
            //        Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır.");
            //    }                
            //}


        }

        #region Color Operations
        private static void DeleteColor(ColorService colorService)
        {
            var toDeleteColor = new Color { Id = 2 };
            colorService.Delete(toDeleteColor);
            Console.WriteLine("After Deleted Color - List of Color");
            GetAllColor(colorService);
        }

        private static void UpdateColor(ColorService colorService)
        {
            var toUpdateColor = new Color { Id = 2, Name = "Purple" };
            colorService.Update(toUpdateColor);
            Console.WriteLine("After Update Color - List of Color");
            GetAllColor(colorService);
        }

        private static void AddNewColor(ColorService colorService)
        {
            var addColor = new Color { Id = 2, Name = "Red" };
            colorService.Add(addColor);
            Console.WriteLine("After Add New Color - List of Color");
            GetAllColor(colorService);
        }

        private static void GetColorById(ColorService colorService, int colorId)
        {
            var color = colorService.GetById(colorId);
            Console.WriteLine("Color Id:" + colorId);
            Console.WriteLine(color.Name);
        }

        private static void GetAllColor(ColorService colorService)
        {
            Console.WriteLine("List of Color");
            foreach (var brand in colorService.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }
        #endregion

        #region Brand Operations
        private static void DeleteBrand(BrandService brandService)
        {
            var toDeleteBrand = new Brand { Id = 2 };
            brandService.Delete(toDeleteBrand);
            Console.WriteLine("After Deleted Brand - List of Brand");
            GetAllBrand(brandService);
        }

        private static void UpdateBrand(BrandService brandService)
        {
            var toUpdateBrand = new Brand { Id = 2, Name = "BMW" };
            brandService.Update(toUpdateBrand);
            Console.WriteLine("After Update Brand - List of Brand");
            GetAllBrand(brandService);
        }

        private static void AddNewBrand(BrandService brandService)
        {
            var addBrand = new Brand { Id = 2, Name = "Peugeot" };
            brandService.Add(addBrand);
            Console.WriteLine("After Add New Brand - List of Brand");
            GetAllBrand(brandService);
        }

        private static void GetBrandById(BrandService brandService, int brandId)
        {
            var brand = brandService.GetById(brandId);
            Console.WriteLine("Brand Id:" + brandId);
            Console.WriteLine(brand.Name);
        }

        private static void GetAllBrand(BrandService brandService)
        {
            Console.WriteLine("List of Brand");
            foreach (var brand in brandService.GetAll())
            {
                Console.WriteLine(brand.Name);
            }
        }
        #endregion

        #region Car Operations
        private static void ListCarDetail(CarService carService)
        {
            Console.WriteLine("List of Car Details");
            foreach (CarDetailDTO car in carService.GetCarDetails())
            {
                Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.DailyPrice);
            }
        }

        public static void GetAllCar(CarService carService)
        {             
            ListCarDetail(carService);
        }

        public static void AddNewCar(CarService carService)
        {
            var addCar = new Car { Id = 4, BrandId = 2, ColorId = 2, Description = "New Car 4", DailyPrice = 230000, ModelYear = 2015, Name = "Araba 4" };
            carService.Add(addCar);
            Console.WriteLine("After Add New Car - List of Car");
            ListCarDetail(carService);
        }

        public static void DeleteCar(CarService carService)
        {
            var toDeleteCar = new Car { Id = 4 };
            carService.Delete(toDeleteCar);
            Console.WriteLine("After Deleted Car - List of Car");
            ListCarDetail(carService);
        }

        public static void UpdateCar(CarService carService)
        {
            var toUpdateCar = new Car { Id = 2, BrandId = 2, ColorId = 2, Description = "Update Desc", DailyPrice = 300000, ModelYear = 2021, Name = "Araba 2" };
            carService.Update(toUpdateCar);
            Console.WriteLine("After Update Car - List of Car");
            ListCarDetail(carService);
        }

        public static void GetCarById(CarService carService, int carId)
        {
            var car = carService.GetById(carId);
            Console.WriteLine("Car Id:" + carId);
            Console.WriteLine(car.Description);
        }
        #endregion


    }
}
