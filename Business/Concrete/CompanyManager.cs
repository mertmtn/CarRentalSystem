using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Results;
using Core.Utilities.Results.Success;
using DataAccess.Abstract;
using Entities.Concrete; 
using System.Collections.Generic; 

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private ICompanyDal _companyDal;
        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }
        public IResult Add(Company company)
        {
            _companyDal.Add(company);
            return new SuccessResult(CompanyMessage.CompanyAddedSuccessfully);
        }

        public IResult Delete(Company company)
        {
            _companyDal.Delete(company);
            return new SuccessResult(CompanyMessage.CompanyDeletedSuccessfully);
        }

        public IDataResult<List<Company>> GetAll()
        {
            return new SuccessDataResult<List<Company>>(_companyDal.GetAll());
        }

        public IDataResult<Company> GetById(int companyId)
        {
            return new SuccessDataResult<Company>(_companyDal.Get(c => c.Id == companyId));
        }

        public IResult Update(Company company)
        {
            _companyDal.Update(company);
            return new SuccessResult(CompanyMessage.CompanyUpdatedSuccessfully);
        }
    }
}
