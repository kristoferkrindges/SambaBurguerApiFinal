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
        public int ProductId { get; set; }
        //public virtual Product Product { get; set; }
        [Required]
        public int CustomerId { get; set; }
        //public virtual Customer Customer { get; set; }
        [Required]
        public int ShopId { get; set; }
        //public Shop Shop { get; set; }
        public DateTime Date { get; set; }
    }
}
