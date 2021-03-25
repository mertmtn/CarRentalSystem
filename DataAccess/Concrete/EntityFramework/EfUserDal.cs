using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System.Linq;
using System.Collections.Generic;
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
                context.Entry(user).Property(x => x.PasswordHash).IsModified = false;
                context.Entry(user).Property(x => x.PasswordSalt).IsModified = false;
                context.SaveChanges();
            }
        }

         

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new CarRentalDbContext())
            {
                var result = from operationClaim in context.OperationClaim
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
