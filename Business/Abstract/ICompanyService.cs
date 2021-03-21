using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICompanyService
    {
        IDataResult<Company> GetById(int companyId);
        IDataResult<List<Company>> GetAll();
        IResult Add(Company company);
        IResult Update(Company company);
        IResult Delete(Company company);
    }
}
