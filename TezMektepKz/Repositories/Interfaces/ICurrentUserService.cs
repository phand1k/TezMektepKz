using TezMektepKz.Models.Identity;

namespace TezMektepKz.Repositories.Interfaces
{
    // Services/Interfaces/ICurrentUserService.cs
    public interface ICurrentUserService
    {
        Task<AspNetUser> GetCurrentUserAsync();
        Task<int?> GetOrganizationIdAsync();
    }

}
