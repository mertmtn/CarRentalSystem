using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic; 

namespace Business.Abstract
{
    public interface ICarService
    {
        Car GetById(int carId);
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);

        List<CarDetailDTO> GetCarDetails();
    }
}
