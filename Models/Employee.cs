using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SambaBurguer.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int? ShopId { get; set; }
        public virtual Shop? Shop { get; set; }
        [Required]
        [StringLength(80)]
        public string Name { get; set; }
        [Required]
        [StringLength(80)]
        public string Gender { get; set; }
        [Required]
        [StringLength(100)]
        public string Cpf { get; set; }
        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        [StringLength(200)]
        public string Address { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        [StringLength(200)]
        public string Type { get; set; }

        //public ICollection<Sale> Sales = new List<Sale>();

    }
}
