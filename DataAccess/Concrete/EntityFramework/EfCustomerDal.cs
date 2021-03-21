using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, CarRentalDbContext>, ICustomerDal
    {
        public List<CustomerDetailDTO> GetAllCustomerDetail()
        {
            using (var context = new CarRentalDbContext())
            {
                var result = from cus in context.Customer
                             join u in context.User on cus.UserId equals u.Id
                             join cmp in context.Company on cus.CompanyId equals cmp.Id
                              
                             select new CustomerDetailDTO
                             {
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Address = cmp.Address,
                                 CompanyName = cmp.CompanyName,
                                 Email = u.Email
                             };

                return result.ToList();
            }
        }
         
        public CustomerDetailDTO GetCustomerDetailById(int customerId)
        {
            using (var context = new CarRentalDbContext())
            {

                var result = from cus in context.Customer
                             join u in context.User on cus.UserId equals u.Id
                             join cmp in context.Company on cus.CompanyId equals cmp.Id
                             where cus.Id == customerId
                             select new CustomerDetailDTO
                             {
                                 FirstName=u.FirstName,
                                 LastName=u.LastName,
                                 Address=cmp.Address,
                                 CompanyName=cmp.CompanyName,
                                 Email=u.Email
                             };

                return result.SingleOrDefault();
            }
        }
    }
}
