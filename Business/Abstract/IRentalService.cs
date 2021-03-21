using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IDataResult<Rental> GetRentalById(int rentalId);
        IDataResult<List<RentalDetailDTO>> GetRentalsByCustomerId(int customerId);        
        IDataResult<RentalDetailDTO> GetRentalDetailById(int rentalId);
        IDataResult<List<RentalDetailDTO>> GetAllRentalDetail();

    }
}
