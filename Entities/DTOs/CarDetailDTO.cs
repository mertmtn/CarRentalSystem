using Core.Entities;
using Entities.Concrete;
using System.Collections.Generic;

namespace Entities.DTOs
{
    public class CarDetailDTO:IDTO
    {
        public CarDetailDTO()
        {
            CarImageList=new List<CarImage>();
        }

        public int CarId { get; set; }
        public string CarName { get; set; }
        public string CarDescription { get; set; }
        public int ModelYear { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }        
        public List<CarImage> CarImageList { get; set; }
    }
}
