using System.ComponentModel.DataAnnotations;

namespace Matrix.Entity
{
    public class Sourcing : BaseEntity
    {
        [Key]
        public Guid SourcingID{ get; set; }
        [Required]
        public string SourcingName { get; set; }
        [Required]
        public string SourcingEmail { get; set; }

    }
}
