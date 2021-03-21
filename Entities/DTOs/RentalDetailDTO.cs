using Core.Entities;
using System;

namespace Entities.DTOs
{
    public class RentalDetailDTO:IDTO
    {
        public string BrandName { get; set; }
        public string CarName { get; set; }        
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }        
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
