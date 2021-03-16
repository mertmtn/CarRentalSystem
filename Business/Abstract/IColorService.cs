using Entities.Concrete;
using System.Collections.Generic;


namespace Business.Abstract
{
    public interface IColorService
    {
        Color GetById(int carId);
        List<Color> GetAll();
        void Add(Color car);
        void Update(Color car);
        void Delete(Color car);
    }
}
