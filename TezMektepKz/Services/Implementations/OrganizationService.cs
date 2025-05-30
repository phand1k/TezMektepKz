using Microsoft.Extensions.Localization;
using TezMektepKz.Exceptions;
using TezMektepKz.Models.Identity;
using TezMektepKz.Repositories.Interfaces;
using TezMektepKz.Services.Interfaces;

namespace TezMektepKz.Services.Implementations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository organizationRepository;
        private readonly IStringLocalizer<OrganizationService> localizer;
        public OrganizationService(IOrganizationRepository organizationRepository, IStringLocalizer<OrganizationService> localizer)
        {
            this.organizationRepository = organizationRepository;
            this.localizer = localizer;
        }

        public async Task<Organization> AddAsync(Organization organization)
        {
            if (organizationRepository.Exists(organization.Number).Result == true)
            {
                throw new BusinessException(localizer["OrganizationExists"]);
            }

            return await organizationRepository.AddAsync(organization);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Organization> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Organization> GetByNumberAsync(string number)
        {
            return await organizationRepository.GetByNumberAsync(number);
        }

        public Task UpdateAsync(Organization organization)
        {
            throw new NotImplementedException();
        }
    }
}
