using TezMektepKz.Models.Identity;

namespace TezMektepKz.Repositories.Interfaces
{
    public interface IOrganizationRepository
    {
        /// <summary>
        ///     Gets the organization by its ID.
        /// </summary>
        /// <param name="id">The ID of the organization.</param>
        /// <returns>The organization with the specified ID.</returns>
        Task<Organization> GetByIdAsync(int id);
        /// <summary>
        ///     Adds a new organization.
        /// </summary>
        /// <param name="organization">The organization to add.</param>
        /// <returns>The added organization.</returns>
        Task<Organization> AddAsync(Organization organization);
        /// <summary>
        ///     Updates an existing organization.
        /// </summary>
        /// <param name="organization">The organization to update.</param>
        Task UpdateAsync(Organization organization);
        /// <summary>
        ///     Deletes an organization by its ID.
        /// </summary>
        /// <param name="id">The ID of the organization to delete.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Get organization by number
        /// </summary>
        /// <param name="number">The number of the organization to get.</param>

        Task<Organization> GetByNumberAsync(string number);

        Task<bool> Exists(string number);
    }
}
