using TezMektepKz.Models;

namespace TezMektepKz.Repositories.Interfaces
{
    public interface IGradeRepository
    {
        //IGradeRepository Clone();
        Task<Grade> AddAsync(Grade grade);
        Task<Grade> GetByIdAsync(int id);
        Task<IEnumerable<Grade>> GetAllAsync(int? organizationId);
        Task UpdateAsync(Grade grade);
        Task DeleteAsync(int id);
    }
}
