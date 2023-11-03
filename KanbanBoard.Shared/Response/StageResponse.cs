namespace KanbanBoard.Shared.Response
{
    public class StageResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int Position { get; set; }
        public bool Status { get; set; }

        public int TemplateId { get; set; }
        public string TemplateName { get; set; } = default!;
    }
}
