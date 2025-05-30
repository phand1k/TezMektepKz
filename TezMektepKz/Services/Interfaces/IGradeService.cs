using TezMektepKz.Models;

namespace TezMektepKz.Services.Interfaces
{
    public interface IGradeService
    {
        Task<Grade> AddAsync(Grade grade);
        Task<Grade> GetByIdAsync(int id);
        Task<IEnumerable<Grade>> GetAllAsync();
        Task UpdateAsync(Grade grade);
        Task DeleteAsync(int id);
    }
}
