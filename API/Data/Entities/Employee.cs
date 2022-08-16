using API.Entities;

namespace API.Data.Entities
{
    public class Employee: BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
