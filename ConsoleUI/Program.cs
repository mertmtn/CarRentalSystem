using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    { 
        public static void Main(string[] args)
        {
            var carService = new CarService(new InMemoryCarDal());
            GetAllCar(carService);
            GetCarById(carService,1);
            AddNewCar(carService);
            DeleteCar(carService);
            UpdateCar(carService);
        }

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

    }
}
