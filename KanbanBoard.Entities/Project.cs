namespace KanbanBoard.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
