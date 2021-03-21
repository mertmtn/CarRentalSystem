using Core.DataAccess;
using Entities.Concrete; 

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        void UpdateUserInfo(User user);
        void UpdateUserPassword(User user);
    }
}
