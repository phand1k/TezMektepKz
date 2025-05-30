using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TezMektepKz.Models.Identity;

namespace TezMektepKz.Models
{
    public class Grade : BaseModel<int>
    {
        [MaxLength(5)] 
        [Required]
        public string Name { get; set; }

        [Required]
        public int GradeNumber { get; set; }

        [Required]
        [MaxLength(5)]
        public string GradeLetter { get; set; }

        [ForeignKey("TeacherId")]
        public string? TeacherId { get; set; }
        public AspNetUser? AspNetUser { get; set; }

        [ForeignKey("OrganizationId")]
        public int? OrganizationId { get; set; }
        public Organization? Organization { get; set; }
        public List<Student> Students { get; set; } = new ();
    }
}
