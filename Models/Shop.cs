using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SambaBurguer.Models
{
    [Table("Shops")]
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string State { get; set; }
        [Required]
        [StringLength(100)]
        public string Cep { get; set; }
        [Required]
        [StringLength(200)]
        public string City { get; set; }
        public string ImageUrl { get; set; }
        //public virtual List<Sale> Sales { get; set; }
        // Navegação
        //public ICollection<Sale> Sales = new List<Sale>();
        //public virtual List<Employee> Employees { get; set; }
        public ICollection<Employee> Employees = new List<Employee>();
    }
}
