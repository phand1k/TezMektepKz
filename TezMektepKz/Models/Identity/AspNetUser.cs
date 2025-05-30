using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TezMektepKz.Models.Identity
{
    public class AspNetUser : IdentityUser
    {
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        public bool? IsDeleted { get; set; } = false;
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? DeletedAt { get; set; } = null;

        [ForeignKey("OrganizationId")]
        public int? OrganizationId { get; set; }
        public Organization? Organization { get; set; }

        [Required]
        [StringLength(12)]
        public string IndividualNumber { get; set; }

        public DateOnly? DateOfBorn { get; set; }
    }
}
