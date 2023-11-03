using KanbanBoard.DataAccess;
using KanbanBoard.Entities;
using KanbanBoard.Repository.Interface;

namespace KanbanBoard.Repository
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(KanbanBoardDbContext dbContext) : base(dbContext)
        {
        }
    }
}
