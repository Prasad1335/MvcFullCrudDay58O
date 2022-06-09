using System.ComponentModel.DataAnnotations.Schema;

namespace MvcFullCrudDay58O.Models
{
    [Table("Departments")]
    public class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
