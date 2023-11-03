using KanbanBoard.Entities;

namespace KanbanBoard.Repository.Interface
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<ICollection<T>> ListAsync();
        Task<T?> FindAsync(int id);
        Task<int> AddAsync(T t);
        Task UpdateAsync();
        Task DeleteAsync(int id);
    }
}
