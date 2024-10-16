using System.ComponentModel.DataAnnotations;

namespace Matrix.Entity
{
    public class BaseEntity
    {
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
