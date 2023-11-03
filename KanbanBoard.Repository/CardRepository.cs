using KanbanBoard.DataAccess;
using KanbanBoard.Entities;
using KanbanBoard.Repository.Interface;

namespace KanbanBoard.Repository
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(KanbanBoardDbContext dbContext) : base(dbContext)
        {
        }
    }
}
