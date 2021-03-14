using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _carList;

        public InMemoryCarDal()
        {
            _carList = new List<Car>
            {
                new Car {Id=1,BrandId=1,ModelYear=2015,ColorId=1,DailyPrice=120000,Description="Desc for 1" },
                new Car {Id=2,BrandId=1,ModelYear=1998,ColorId=4,DailyPrice=130000,Description="Desc for 2" },
                new Car {Id=3,BrandId=2,ModelYear=2020,ColorId=2,DailyPrice=140000,Description="Desc for 3" },
                new Car {Id=4,BrandId=4,ModelYear=2015,ColorId=3,DailyPrice=150000,Description="Desc for 4" },
                new Car {Id=5,BrandId=4,ModelYear=2006,ColorId=5,DailyPrice=320000,Description="Desc for 5" },
            };
        }

        public void Add(Car car)
        {
            _carList.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _carList.SingleOrDefault(c => c.Id == car.Id);
            _carList.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _carList;
        }

        public Car GetById(int carId)
        {
            return _carList.SingleOrDefault(c => c.Id == carId);
        }

        public void Update(Car car)
        {
            var carToUpdate = _carList.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
