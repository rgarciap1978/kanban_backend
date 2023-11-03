using KanbanBoard.DataAccess;
using KanbanBoard.Entities;
using KanbanBoard.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(KanbanBoardDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User?> GetUserByIdAsync(int Id)
        {
            return await _dbContext.Set<User>()
                .FirstOrDefaultAsync(l => l.Id == Id);
        }
    }
}
