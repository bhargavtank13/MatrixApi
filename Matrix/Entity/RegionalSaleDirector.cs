using System.ComponentModel.DataAnnotations;

namespace Matrix.Entity
{
    public class RegionalSaleDirector : BaseEntity
    {
        [Key]
        public Guid RegionalSaleDirectorId { get; set; }
        [Required]
        public string RegionalSaleDirectorName { get; set; }
        [Required]
        public string RegionalSaleDirectorEmail { get; set; }
    }
}
