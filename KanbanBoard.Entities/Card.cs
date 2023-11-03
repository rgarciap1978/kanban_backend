namespace KanbanBoard.Entities
{
    public class Card : BaseEntity
    {
        public string Description { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Deadline { get; set; }
        
        public int StageId { get; set; }
        public Stage Stage { get; set; } = default!;

        public int UserId { get; set; }
        public User User { get; set; } = default!;

        public int PriorityId { get; set; }
        public Priority Priority { get; set; } = default!;
    }
}
