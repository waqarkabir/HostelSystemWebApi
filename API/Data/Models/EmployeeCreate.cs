using System.ComponentModel.DataAnnotations;

namespace API.Data.Models
{
    public class EmployeeCreate
    {
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
