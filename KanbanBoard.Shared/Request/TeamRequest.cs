using System.ComponentModel.DataAnnotations;

namespace KanbanBoard.Shared.Request
{
    public class TeamRequest
    {
        [Required] public int ProjectId { get; set; }
        [Required] public int UserId { get; set; }
        [Required] public bool Status { get; set; }
    }
}
