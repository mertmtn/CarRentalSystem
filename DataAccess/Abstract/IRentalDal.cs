﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IRentalDal: IEntityRepository<Rental>
    {
        List<RentalDetailDTO> GetRentalsByCustomerId(int customerId); 
        RentalDetailDTO GetRentalDetailById(int rentalId);
        List<RentalDetailDTO> GetAllRentalDetail();
    }
}
