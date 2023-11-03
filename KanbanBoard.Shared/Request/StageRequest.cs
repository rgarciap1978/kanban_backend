using System.ComponentModel.DataAnnotations;

namespace KanbanBoard.Shared.Request
{
    public class StageRequest
    {
        [Required] public string Name { get; set; } = default!;
        [Required] public int Position { get; set; }
        [Required] public bool Status { get; set; }
        [Required] public int TemplateId { get; set; }
    }
}
