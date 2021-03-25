﻿using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic; 

namespace Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<Brand> GetById(int brandId);
        IDataResult<List<Brand>> GetAll();
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand brand);

        IResult AddTransactionalTest(Brand brand);
    }
}
