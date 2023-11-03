namespace KanbanBoard.Entities
{
    public class Stage : BaseEntity
    {
        public string Name { get; set; } = default!;
        public int Position { get; set; }

        public int TemplateId { get; set; }
        public Template Template { get; set; } = default!;
    }
}
