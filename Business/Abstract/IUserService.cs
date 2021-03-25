using Core.Entities.Concrete;
using Core.Utilities.Results; 
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetById(int userId);
        IDataResult<List<User>> GetAll();
        IResult Add(User user);
        IResult UpdateUserInfo(User user);

        IResult Delete(User user);

        IDataResult<List<OperationClaim>> GetClaims(User user);

        IDataResult<User> GetByMail(string email);
    }
}
