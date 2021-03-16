using Entities.Concrete;
using System.Collections.Generic; 

namespace Business.Abstract
{
    public interface IBrandService
    {
        Brand GetById(int brandId);
        List<Brand> GetAll();
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);
    }
}
