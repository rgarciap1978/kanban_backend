using KanbanBoard.DataAccess;
using KanbanBoard.Entities;
using KanbanBoard.Repository.Interface;

namespace KanbanBoard.Repository
{
    public class StageRepository : BaseRepository<Stage>, IStageRepository
    {
        public StageRepository(KanbanBoardDbContext dbContext) : base(dbContext)
        {
        }
    }
}
