using System.ComponentModel.DataAnnotations;

namespace KanbanBoard.Shared.Response
{
    public class CardResponse
    {
        public int Id { get; set; }
        public string Description { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? Deadline { get; set; }
        public bool Status { get; set; }

        public int StageId { get; set; }
        public string StageName { get; set; } = default!;

        public int UserId { get; set; }
        public string UserFirstname { get; set; } = default!;
        public string UserLastname { get; set; } = default!;
        public string UserInitials { get; set; } = default!;
        public string UserEmail { get; set; } = default!;

        public int PriorityId { get; set; }
        public string PriorityName { get; set; } = default!;
    }
}
