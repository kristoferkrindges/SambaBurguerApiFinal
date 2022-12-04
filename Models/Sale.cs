using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SambaBurguer.Models
{
    [Table("Sales")]
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        [Required]
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [Required]
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public DateTime Date { get; set; }
    }
}
