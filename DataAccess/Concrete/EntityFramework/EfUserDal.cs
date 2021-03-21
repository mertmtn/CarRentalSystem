using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
   public  class EfUserDal : EfEntityRepositoryBase<User, CarRentalDbContext>, IUserDal
    {
        public void UpdateUserInfo(User user)
        {
            using (var context = new CarRentalDbContext())
            {
                context.Entry(user).State = EntityState.Modified;
                context.Entry(user).Property(x => x.Password).IsModified = false;
                context.SaveChanges();
            }
        }

        public void UpdateUserPassword(User user)
        {
            using (var context = new CarRentalDbContext())
            {
                context.Entry(user).State = EntityState.Modified;
                context.Entry(user).Property(x => x.FirstName).IsModified = false;
                context.Entry(user).Property(x => x.LastName).IsModified = false;
                context.Entry(user).Property(x => x.Id).IsModified = false;
                context.Entry(user).Property(x => x.Email).IsModified = false; 
                context.SaveChanges();
            }
        }
    }
}
