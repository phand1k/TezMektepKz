using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TezMektepKz.Models.Identity;

namespace TezMektepKz.Models
{
    public class Student : BaseModel<int>
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string SurName { get; set; }

        [Required]
        [StringLength(12)]
        public string? IndividualNumber { get; set; }

        [ForeignKey("AspNetUserId")]
        public string AspNetUserId { get; set; }
        public AspNetUser? AspNetUser { get; set; }
    }
}
