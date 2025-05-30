using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TezMektepKz.Data;
using TezMektepKz.Models.Identity;
using TezMektepKz.Repositories.Interfaces;

namespace TezMektepKz.Repositories.Implementations
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AspNetUser> _userManager;
        private readonly ApplicationDbContext _context;

        public CurrentUserService(
            IHttpContextAccessor httpContextAccessor,
            UserManager<AspNetUser> userManager,
            ApplicationDbContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _context = context;
        }

        public async Task<AspNetUser> GetCurrentUserAsync()
        {
            var userId = _userManager.GetUserId(_httpContextAccessor.HttpContext?.User);
            var user = await _context.Users
                .Include(u => u.Organization)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                throw new UnauthorizedAccessException("Пользователь не найден.");

            return user;
        }

        public async Task<int?> GetOrganizationIdAsync()
        {
            var user = await GetCurrentUserAsync();
            return user.OrganizationId;
        }
    }
}
