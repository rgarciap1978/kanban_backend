using System.ComponentModel.DataAnnotations;

namespace KanbanBoard.Shared.Request
{
    public class CardRequest
    {
        [Required] public string Description { get; set; } = default!;
        [Required] public DateTime StartDate { get; set; }
        [Required] public DateTime EndDate { get; set; }
        public DateTime? Deadline { get; set; } = default!;
        [Required] public bool Status { get; set; }
        [Required] public int StageId { get; set; }
        [Required] public int PriorityId { get; set; }
        [Required] public int UserId { get; set; }
    }
}
