namespace KanbanBoard.Entities
{
    public class Priority:BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Color { get; set; } = default!;
    }
}
