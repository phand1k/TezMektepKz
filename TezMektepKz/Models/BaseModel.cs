using System.ComponentModel.DataAnnotations;

namespace TezMektepKz.Models
{
    public abstract class BaseModel<T>
    {
        [Key]
        public T Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; } = null;
        public string? CreatedBy { get; set; } = null;
        public string? UpdatedBy { get; set; } = null;
        public string? DeletedBy { get; set; } = null;
    }
}
