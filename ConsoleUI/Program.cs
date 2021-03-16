using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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


        }

        #region Color Operations
        private static void DeleteColor(ColorService colorService)
        {
            var toDeleteColor = new Color { Id = 2 };
            var result = colorService.Delete(toDeleteColor);
            Console.WriteLine(result.Message);
        }

        private static void UpdateColor(ColorService colorService)
        {
            var toUpdateColor = new Color { Id = 2, Name = "Purple" };
            var result= colorService.Update(toUpdateColor);
            Console.WriteLine(result.Message);
        }

        private static void AddNewColor(ColorService colorService)
        {
            var addColor = new Color { Id = 2, Name = "Red" };
            var result = colorService.Add(addColor);
            Console.WriteLine(result.Message);
        }

        private static void GetColorById(ColorService colorService, int colorId)
        {
            var color = colorService.GetById(colorId);
            Console.WriteLine("Color Id:" + colorId);
            Console.WriteLine(color.Data.Name);
        }

        private static void GetAllColor(ColorService colorService)
        {
            Console.WriteLine("List of Color");
            var result = colorService.GetAll();
            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.Name);
                } 
            }
        }
        #endregion

        #region Brand Operations
        private static void DeleteBrand(BrandService brandService)
        {
            var toDeleteBrand = new Brand { Id = 2 };
            var result = brandService.Delete(toDeleteBrand);
            Console.WriteLine(result.Message);
        }

        private static void UpdateBrand(BrandService brandService)
        {
            var toUpdateBrand = new Brand { Id = 2, Name = "BMW" };
            var result=brandService.Update(toUpdateBrand);
            Console.WriteLine(result.Message);
        }

        private static void AddNewBrand(BrandService brandService)
        {
            var addBrand = new Brand { Id = 2, Name = "Peugeot" };
            var result = brandService.Add(addBrand);
            Console.WriteLine(result.Message);
        }

        private static void GetBrandById(BrandService brandService, int brandId)
        {
            var brand = brandService.GetById(brandId);
            Console.WriteLine("Brand Id:" + brandId);
            Console.WriteLine(brand.Data.Name);
        }

        private static void GetAllBrand(BrandService brandService)
        {
            Console.WriteLine("List of Brand");
            var result = brandService.GetAll();
            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.Name);
                } 
            }
        }
        #endregion

        #region Car Operations
        private static void ListCarDetail(CarService carService)
        {
            Console.WriteLine("List of Car Details");

            var result = carService.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + "/" + car.BrandName + "/" + car.DailyPrice);
                }
            }
        }

        public static void GetAllCar(CarService carService)
        {             
            ListCarDetail(carService);
        }

        public static void AddNewCar(CarService carService)
        {
            var addCar = new Car { Id = 4, BrandId = 2, ColorId = 2, Description = "New Car 4", DailyPrice = 230000, ModelYear = 2015, Name = "Araba 4" };
            var result=carService.Add(addCar);
            Console.WriteLine(result.Message);
            
        }

        public static void DeleteCar(CarService carService)
        {
            var toDeleteCar = new Car { Id = 4 };
            var result=carService.Delete(toDeleteCar);
            Console.WriteLine(result.Message);
             
        }

        public static void UpdateCar(CarService carService)
        {
            var toUpdateCar = new Car { Id = 2, BrandId = 2, ColorId = 2, Description = "Update Desc", DailyPrice = 300000, ModelYear = 2021, Name = "Araba 2" };
            var result=carService.Update(toUpdateCar);
            Console.WriteLine(result.Message);
            
        }

        public static void GetCarById(CarService carService, int carId)
        {
            var car = carService.GetById(carId);
            Console.WriteLine("Car Id:" + carId);
            Console.WriteLine(car.Data.Description);
        }
        #endregion


    }
}
