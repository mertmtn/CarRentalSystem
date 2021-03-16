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
                             select new CarDetailDTO { BrandName = b.Name, CarName = c.Name, ColorName = clr.Name, DailyPrice = c.DailyPrice };

                return result.ToList();
            }
        }
    }
}
