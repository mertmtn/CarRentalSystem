using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Results;
using Core.Utilities.Results.Success;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic; 

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(CustomerMessage.CustomerAddedSuccessfully);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(CustomerMessage.CustomerDeletedSuccessfully);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<List<CustomerDetailDTO>> GetAllCustomerDetail()
        {
            return new SuccessDataResult<List<CustomerDetailDTO>>(_customerDal.GetAllCustomerDetail());
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.Id== customerId));
        }

        public IDataResult<CustomerDetailDTO> GetCustomerDetailById(int customerId)
        {
            return new SuccessDataResult<CustomerDetailDTO>(_customerDal.GetCustomerDetailById(customerId));
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(CustomerMessage.CustomerUpdatedSuccessfully);
        }
    }
}
