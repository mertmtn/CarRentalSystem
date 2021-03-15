using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return _carList.AsQueryable().SingleOrDefault(filter);
        }

        public List<Car> GetAll()
        {
            return _carList;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return filter == null ? _carList : _carList.AsQueryable().Where(filter).ToList();
        }

        public Car GetById(int carId)
        {
            return _carList.SingleOrDefault(c => c.Id == carId);
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carList.Where(c => c.Id == brandId).ToList();
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carList.Where(c => c.Id == colorId).ToList();
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
