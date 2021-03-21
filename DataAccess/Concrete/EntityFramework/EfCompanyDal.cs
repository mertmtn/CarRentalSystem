using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete; 

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCompanyDal: EfEntityRepositoryBase<Company, CarRentalDbContext>, ICompanyDal
    {
    }
}
