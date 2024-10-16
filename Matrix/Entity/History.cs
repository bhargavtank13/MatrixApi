using System.ComponentModel.DataAnnotations;

namespace Matrix.Entity
{
    public class History : BaseEntity
    {
        [Key]
        public Guid HistoryID { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Guid SalesId { get; set; }
        public Sales Sales { get; set; }

    }
}
