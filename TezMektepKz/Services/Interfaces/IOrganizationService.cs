using TezMektepKz.Models.Identity;

namespace TezMektepKz.Services.Interfaces
{
    public interface IOrganizationService
    {
        Task<Organization> GetByNumberAsync(string number);
        Task<Organization> GetByIdAsync(int id);
        Task<Organization> AddAsync(Organization organization);
        Task UpdateAsync(Organization organization);
        Task DeleteAsync(int id);
    }
}
