using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        public static void Main(string[] args)
        {
            var carService = new CarService(new EfCarDal());

            var addNewCar = new Car { BrandId = 1,Name="Opel Corsa", ColorId = 1, DailyPrice = 10000, ModelYear = 2000, Id = 1, Description = "Günlük 10000 TL" };

            //TODO: Geliştirme aşamasında validasyon kuralları kullanılarak kontrol eklenecektir.
            //Web tarafında fluent validation olabilir.

            /*
             Kural 1: Araba ismi minimum 2 karakter olmalıdır.
             Kural 2: Araba günlük fiyatı 0'dan büyük olmalıdır.
             */

            if (addNewCar.DailyPrice > 0 && (!string.IsNullOrEmpty(addNewCar.Name) && addNewCar.Name.Length >= 2))
            {
                carService.Add(addNewCar);
            }
            else
            {
                if (!(addNewCar.DailyPrice > 0))
                {
                    Console.WriteLine("Araba günlük fiyatı 0'dan büyük olmalıdır.");
                }

                if (string.IsNullOrEmpty(addNewCar.Name) || addNewCar.Name.Length < 2)
                {
                    Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır.");
                }                
            }

            //GetAllCar(carService);
            //GetCarById(carService,1);
            //AddNewCar(carService);
            //DeleteCar(carService);
            //UpdateCar(carService);
        }



        #region InMemoryAltYapısı
        public static void GetAllCar(CarService carService)
        {
            Console.WriteLine("List of Car");
            foreach (var car in carService.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }

        public static void AddNewCar(CarService carService)
        {
            var addCar = new Car { Id = 6, BrandId = 4, ColorId = 2, Description = "New Car", DailyPrice = 300000, ModelYear = 2021 };
            carService.Add(addCar);
            Console.WriteLine("After Add New Car - List of Car");
            foreach (var car in carService.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }

        public static void DeleteCar(CarService carService)
        {
            var toDeleteCar = new Car { Id = 5 };
            carService.Delete(toDeleteCar);
            Console.WriteLine("After Deleted Car - List of Car");
            foreach (var car in carService.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }

        public static void UpdateCar(CarService carService)
        {
            var toUpdateCar = new Car { Id = 3, BrandId = 2, ModelYear = 2020, ColorId = 2, DailyPrice = 140000, Description = "Update Desc" };
            carService.Update(toUpdateCar);
            Console.WriteLine("After Update Car - List of Car");
            foreach (var car in carService.GetAll())
            {
                Console.WriteLine(car.Description);
            }
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
