using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.Constants.Validation;
using Core.Utilities.Results;
using Core.Utilities.Results.Error;
using Core.Utilities.Results.Success;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        //[SecuredOperation("rental.add")]
        public IResult Add(Rental rental)
        {
            var existingRental = _rentalDal.Get(r => r.CarId == rental.CarId && r.ReturnDate == null);

            if (existingRental == null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(RentalMessage.RentalAddedSuccessfully);
            }
            else
            {
                return new ErrorResult(RentalValidationMessage.RentalIsNullReturnedDate);
            }
        }
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(RentalMessage.RentalUpdatedSuccessfully);
        }
        public IDataResult<List<RentalDetailDTO>> GetRentalsByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<RentalDetailDTO>>(_rentalDal.GetRentalsByCustomerId(customerId));
        }
        public IDataResult<Rental> GetRentalById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == rentalId));
        }
        public IDataResult<RentalDetailDTO> GetRentalDetailById(int rentalId)
        {
            return new SuccessDataResult<RentalDetailDTO>(_rentalDal.GetRentalDetailById(rentalId));
        }
        public IDataResult<List<RentalDetailDTO>> GetAllRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDTO>>(_rentalDal.GetAllRentalDetail());
        }
    }
}
