using Microsoft.AspNetCore.Identity;

namespace TezMektepKz.Models.Identity.Role
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<AspNetUser> Members { get; set; }
        public IEnumerable<AspNetUser> NonMembers { get; set; }
    }
}
