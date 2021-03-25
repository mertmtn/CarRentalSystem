using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Core.Utilities.Security.JsonWebToken
{
    public interface ITokenHelper
    { 
        //İlgili kullanıcının claimlerini içeren token üretecektir.
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}