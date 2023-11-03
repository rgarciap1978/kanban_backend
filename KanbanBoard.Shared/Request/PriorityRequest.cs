using System.ComponentModel.DataAnnotations;

namespace KanbanBoard.Shared.Request
{
    public class PriorityRequest
    {
        [Required] public string Name { get; set; } = default!;
        [Required] public string Color { get; set; } = default!;
        [Required] public bool Status { get; set; } 
    }
}
