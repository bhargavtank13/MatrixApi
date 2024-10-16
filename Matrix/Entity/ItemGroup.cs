using System.ComponentModel.DataAnnotations;

namespace Matrix.Entity
{
    public class ItemGroup : BaseEntity
    {
        [Key]
        public Guid ItemGoupId { get; set; }
        [Required]
        public string ItemGroupName { get; set; }
        [Required]
        public Guid SourcingId { get; set; }
        public Sourcing Sourcing { get; set; }
    }
}
