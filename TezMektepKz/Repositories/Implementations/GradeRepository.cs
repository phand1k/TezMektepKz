using Microsoft.EntityFrameworkCore;
using TezMektepKz.Data;
using TezMektepKz.Models;
using TezMektepKz.Repositories.Interfaces;

namespace TezMektepKz.Repositories.Implementations
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ApplicationDbContext context;
        public GradeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }


        public async Task<Grade> AddAsync(Grade grade)
        {
            await context.AddAsync(grade);
            await context.SaveChangesAsync();
            return grade;
        }

        public async Task<Grade> GetByIdAsync(int id)
        {
            return await context.Grades.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<IEnumerable<Grade>> GetAllAsync(int? organizationId)
        {
            return await context.Grades.Where(x=>x.OrganizationId == organizationId).ToListAsync();
        }

        public async Task UpdateAsync(Grade grade)
        {

        }
        public async Task DeleteAsync(int id)
        {

        }
    }
}
