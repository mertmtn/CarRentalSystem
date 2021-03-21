using Core.Entities;

namespace Entities.DTOs
{
    public class CustomerDetailDTO:IDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
    }
}
