namespace KanbanBoard.Shared.Response
{
    public class TeamResponse
    {
        public int Id { get; set; }
        public bool Status { get; set; } = default!;

        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = default!;

        public int UserId { get; set; }
        public string UserFirstname { get; set; } = default!;
        public string UserLastname { get; set;} = default!;
        public string UserEmail { get; set; } = default!;
    }
}
