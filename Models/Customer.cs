using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SambaBurguer.Models
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
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
        [Required]
        [StringLength(100)]
        public string Cep { get; set; }

        public string ImageUrl { get; set; }

        //public virtual List<Sale> Sales { get; set; }
        public ICollection<Sale> Sales = new List<Sale>();

    }
}
