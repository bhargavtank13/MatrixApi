using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Matrix.Entity
{
    public class Customer : BaseEntity     
    {
        [Key]
        public Guid CustomerId { get; set; }
        public int CustomerNumber { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
    }
}
