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


        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }        
        public List<CarImage> CarImageList { get; set; }
    }
}
