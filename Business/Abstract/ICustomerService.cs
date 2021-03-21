

using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<CustomerDetailDTO> GetCustomerDetailById(int customerId);
        IDataResult<List<CustomerDetailDTO>> GetAllCustomerDetail();
        IDataResult<Customer> GetById(int customerId);
        IDataResult<List<Customer>> GetAll();
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
    }
}
