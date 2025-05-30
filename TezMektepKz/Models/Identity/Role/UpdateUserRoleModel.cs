using System.ComponentModel.DataAnnotations;

namespace TezMektepKz.Models.Identity.Role
{
    public class UpdateUserRoleModel
    {
        [Required]
        public string RoleName { get; set; }

        public string? RoleId { get; set; }

        public string[]? AddIds { get; set; }

        public string[]? DeleteIds { get; set; }
    }
}
