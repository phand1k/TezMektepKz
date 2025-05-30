using Microsoft.AspNetCore.Identity;
using TezMektepKz.Models;
using TezMektepKz.Models.Identity;
using TezMektepKz.Repositories.Interfaces;
using TezMektepKz.Services.Interfaces;

namespace TezMektepKz.Services.Implementations
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository gradeRepository;
        private readonly ICurrentUserService currentUserService;
        public GradeService(IGradeRepository gradeRepository, ICurrentUserService currentUserService)
        {
            this.gradeRepository = gradeRepository;
            this.currentUserService = currentUserService;
        }


        public async Task<Grade> AddAsync(Grade grade)
        {
            var user = await currentUserService.GetCurrentUserAsync();

            if (user == null || user.OrganizationId == null)
                throw new UnauthorizedAccessException("Пользователь не найден или не привязан к организации");
            grade.TeacherId = user.Id;
            grade.OrganizationId = user.OrganizationId;
            return await gradeRepository.AddAsync(grade);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Grade>> GetAllAsync()
        {
            var user = await currentUserService.GetOrganizationIdAsync();
            if (user == null)
                throw new UnauthorizedAccessException("Пользователь не найден или не привязан к организации");

            return await gradeRepository.GetAllAsync(user);
        }

        public Task<Grade> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Grade grade)
        {
            throw new NotImplementedException();
        }
    }
}
