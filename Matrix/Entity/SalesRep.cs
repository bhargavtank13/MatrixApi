using System.ComponentModel.DataAnnotations;

namespace Matrix.Entity
{
    public class SalesRep : BaseEntity
    {
        [Key]
        public Guid SalesRepId { get; set; }
        [Required]
        public string SaleRepName { get; set; }
        [Required]
        public string SaleRepEmail { get; set; }
        [Required]
        public Guid RegionalSaleDirectorId { get; set; }
        public RegionalSaleDirector RegionalSaleDirector { get; set; }

    }
}
