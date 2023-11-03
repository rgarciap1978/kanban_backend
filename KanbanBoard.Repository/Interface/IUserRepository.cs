using KanbanBoard.Entities;

namespace KanbanBoard.Repository.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserByIdAsync(int Id);
    }
}
