using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDTO> GetCarDetails();
        List<CarDetailDTO> GetCarDetailsByColorId(int colorId);
        List<CarDetailDTO> GetCarDetailsByBrandId(int brandId);
        CarDetailDTO GetCarDetailByCarId(int carId);
    }
}
