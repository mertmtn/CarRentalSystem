using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;
 
namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalDbContext>, ICarDal
    {
        public List<CarDetailDTO> GetCarDetails()
        {
            using (var context = new CarRentalDbContext())
            {
                //INNER JOIN
                /*
                 SELECT b.Name,c.Name,clr.Name,c.DailyPrice
                        FROM [CARRENTALDB].[dbo].[Car] c
                                INNER JOIN Brand b ON c.BrandId=b.Id  
                                INNER JOIN Color clr ON c.ColorId=clr.Id  
                 */
                var result = from c in context.Car
                             
                             join b in context.Brand on c.BrandId equals b.Id
                             join clr in context.Color on c.ColorId equals clr.Id
                             select new CarDetailDTO {
                                 CarId = c.Id,
                                 CarDescription=c.Description,ModelYear=c.ModelYear,BrandName = b.Name, CarName = c.Name, ColorName = clr.Name, DailyPrice = c.DailyPrice,
                                 CarImageList= context.CarImage.Where(x=>x.CarId==c.Id).ToList() };

                return result.ToList();
            }
        }
        public CarDetailDTO GetCarDetailByCarId(int carId)
        {
            using (var context = new CarRentalDbContext())
            {
 
                var result = from c in context.Car

                             join b in context.Brand on c.BrandId equals b.Id
                             join clr in context.Color on c.ColorId equals clr.Id
                             where c.Id==carId
                             select new CarDetailDTO
                             {
                                 CarDescription = c.Description,
                                 ModelYear = c.ModelYear,
                                 CarId =c.Id,
                                 BrandName = b.Name,
                                 CarName = c.Name,
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice,
                                 CarImageList = context.CarImage.Where(x => x.CarId == c.Id).ToList()
                             };

                return result.SingleOrDefault();
            }
        }
        public List<CarDetailDTO> GetCarDetailsByColorId(int colorId)
        {
            using (var context = new CarRentalDbContext())
            {
               
                var result = from c in context.Car

                             join b in context.Brand on c.BrandId equals b.Id
                             join clr in context.Color on c.ColorId equals clr.Id
                             where clr.Id== colorId
                             select new CarDetailDTO
                             {
                                 CarDescription = c.Description,
                                 ModelYear = c.ModelYear,
                                 CarId = c.Id,
                                 BrandName = b.Name,
                                 CarName = c.Name,
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice,
                                 CarImageList = context.CarImage.Where(x => x.CarId == c.Id).ToList()
                             };

                return result.ToList();
            }
        }

        public List<CarDetailDTO> GetCarDetailsByBrandId(int brandId)
        {
            using (var context = new CarRentalDbContext())
            {
 
                var result = from c in context.Car

                             join b in context.Brand on c.BrandId equals b.Id
                             join clr in context.Color on c.ColorId equals clr.Id
                             where b.Id==brandId
                             select new CarDetailDTO
                             {
                                 CarDescription = c.Description,
                                 ModelYear = c.ModelYear,
                                 CarId = c.Id,
                                 BrandName = b.Name,
                                 CarName = c.Name,
                                 ColorName = clr.Name,
                                 DailyPrice = c.DailyPrice,
                                 CarImageList = context.CarImage.Where(x => x.CarId == c.Id).ToList()
                             };

                return result.ToList();
            }
        }
    }
}
