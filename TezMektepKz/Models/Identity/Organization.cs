using System.ComponentModel.DataAnnotations;

namespace TezMektepKz.Models.Identity
{
    public class Organization : BaseModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(12)]
        public string Number { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }


    }
}
