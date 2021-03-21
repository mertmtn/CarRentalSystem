using Core.Entities;

namespace Entities.Concrete
{
    public class Company:IEntity
    {
        public int Id { get; set; }        
        public string CompanyName { get; set; }
        public string Address { get; set; }
    }
}
