namespace KanbanBoard.Entities
{
    public class Workflow : BaseEntity
    {
        public Template Template { get; set; } = default!;
        public Project Project { get; set; } = default!;

    }
}
