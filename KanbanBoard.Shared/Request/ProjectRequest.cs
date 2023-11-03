using System.ComponentModel.DataAnnotations;

namespace KanbanBoard.Shared.Request
{
    public class ProjectRequest
    {
        [Required] public string Name { get; set; } = default!;
        [Required] public string Description { get; set; } = default!;
        [Required] public bool Status { get; set; } = default!;
    }
}
