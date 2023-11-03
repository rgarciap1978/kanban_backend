using KanbanBoard.DataAccess;
using KanbanBoard.Entities;
using KanbanBoard.Repository.Interface;

namespace KanbanBoard.Repository
{
    public class PriorityRepository : BaseRepository<Priority>, IPriorityRepository
    {
        public PriorityRepository(KanbanBoardDbContext dbContext) : base(dbContext)
        {
        }
    }
}
