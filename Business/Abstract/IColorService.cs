using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<Color> GetById(int carId);
        IDataResult<List<Color>> GetAll();
        IResult Add(Color car);
        IResult Update(Color car);
        IResult Delete(Color car);
    }
}
