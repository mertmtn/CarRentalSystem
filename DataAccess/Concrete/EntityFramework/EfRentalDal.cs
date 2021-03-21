using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalDbContext>, IRentalDal
    {
        public List<RentalDetailDTO> GetAllRentalDetail()
        {
            using (var context = new CarRentalDbContext())
            {
 
                var result = from r in context.Rental
                             join cus in context.Customer on r.CustomerId equals cus.Id
                             join cmp in context.Company on cus.CompanyId equals cmp.Id
                             join u in context.User on cus.UserId equals u.Id
                             join c in context.Car on r.CarId equals c.Id
                             join b in context.Brand on c.BrandId equals b.Id
                             join clr in context.Color on c.ColorId equals clr.Id
                             select new RentalDetailDTO
                             {
                                 BrandName = b.Name,
                                 CarName = c.Name,
                                 ColorName = clr.Name,
                                 ModelYear = c.ModelYear,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 DailyPrice = c.DailyPrice,
                                 CustomerFirstName = u.FirstName,
                                 CustomerLastName = u.LastName
                             };

                return result.ToList();
            }
        }

        public RentalDetailDTO GetRentalDetailById(int rentalId)
        {
            using (var context = new CarRentalDbContext())
            {
 
                var result = from r in context.Rental
                             join cus in context.Customer on r.CustomerId equals cus.Id
                             join cmp in context.Company on cus.CompanyId equals cmp.Id
                             join u in context.User on cus.UserId equals u.Id
                             join c in context.Car on r.CarId equals c.Id
                             join b in context.Brand on c.BrandId equals b.Id
                             join clr in context.Color on c.ColorId equals clr.Id
                             where r.Id==rentalId
                             select new RentalDetailDTO
                             {
                                 BrandName = b.Name,
                                 CarName = c.Name,
                                 ColorName = clr.Name,
                                 ModelYear = c.ModelYear,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 DailyPrice = c.DailyPrice,
                                 CustomerFirstName = u.FirstName,
                                 CustomerLastName = u.LastName
                             };

                return result.SingleOrDefault();
            }
        }

        public List<RentalDetailDTO> GetRentalsByCustomerId(int customerId)
        {
            using (var context = new CarRentalDbContext())
            {
 
                var result = from r in context.Rental
                             join cus in context.Customer on r.CustomerId equals cus.Id
                             join cmp in context.Company on cus.CompanyId equals cmp.Id
                             join u in context.User on cus.UserId equals u.Id
                             join c in context.Car on r.CarId equals c.Id
                             join b in context.Brand on c.BrandId equals b.Id
                             join clr in context.Color on c.ColorId equals clr.Id
                             where r.CustomerId == customerId
                             select new RentalDetailDTO
                             {
                                 BrandName = b.Name,
                                 CarName = c.Name,
                                 ColorName = clr.Name,
                                 ModelYear = c.ModelYear,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 DailyPrice = c.DailyPrice,
                                 CustomerFirstName = u.FirstName,
                                 CustomerLastName = u.LastName
                             };

                return result.ToList();
            }
        }
    }
}
