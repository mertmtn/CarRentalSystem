using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetById(int userId);
        IDataResult<List<User>> GetAll();
        IResult Add(User user);
        IResult UpdateUserInfo(User user);
        IResult UpdatePassword(User user);
        IResult Delete(User user);
    }
}
