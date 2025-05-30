using TezMektepKz.Repositories.Interfaces;
using TezMektepKz.Data;
using TezMektepKz.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace TezMektepKz.Repositories.Implementations
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly ApplicationDbContext context;
        public OrganizationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Exists(string number)
        {
            return await context.Organizations.AnyAsync(x => x.Number == number);
        }

        public async Task<Organization> AddAsync(Organization organization)
        {
            await context.Organizations.AddAsync(organization);
            await context.SaveChangesAsync();
            return organization;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Organization> GetByNumberAsync(string number)
        {
            return await context.Organizations.FirstOrDefaultAsync(x => x.Number == number);
        }
        public async Task<Organization> GetByIdAsync(int id)
        {
            return await context.Organizations.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public Task UpdateAsync(Organization organization)
        {
            throw new NotImplementedException();
        }
    }
}
