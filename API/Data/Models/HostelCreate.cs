using System.ComponentModel.DataAnnotations;

namespace API.Data.Models
{
    public class HostelCreate
    {
        [Required]
        public string Name { get; set; }
    }
}
