using KanbanBoard.Entities;
using KanbanBoard.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace KanbanBoard.Repository
{
    public class WorkflowRepository : BaseRepository<Workflow>, IWorkflowRepository
    {
        protected WorkflowRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
