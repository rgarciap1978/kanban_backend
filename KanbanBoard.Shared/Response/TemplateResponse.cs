namespace KanbanBoard.Shared.Response
{
    public class TemplateResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public bool Status { get; set; }
    }
}
