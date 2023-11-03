namespace KanbanBoard.Entities
{
    public class Team : BaseEntity
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; } = default!;

        public int UserId { get; set; }
        public User User { get; set; } = default!;
    }
}
