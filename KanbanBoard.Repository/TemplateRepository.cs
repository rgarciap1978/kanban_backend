using KanbanBoard.DataAccess;
using KanbanBoard.Entities;
using KanbanBoard.Repository.Interface;

namespace KanbanBoard.Repository
{
    public class TemplateRepository : BaseRepository<Template>, ITemplateRepository
    {
        public TemplateRepository(KanbanBoardDbContext dbContext) : base(dbContext)
        {
        }
    }
}
