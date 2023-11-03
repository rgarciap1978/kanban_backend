using System.ComponentModel.DataAnnotations;

namespace KanbanBoard.Shared.Request
{
    public class TemplateRequest
    {
        [Required] public string Name { get; set; } = default!;
        [Required] public bool Status { get; set; }
    }
}
