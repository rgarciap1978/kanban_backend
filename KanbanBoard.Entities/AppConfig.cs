namespace KanbanBoard.Entities
{
    public class AppConfig
    {
        public Jwt Jwt { get; set; } = default!;
    }

    public class Jwt
    {
        public string SecretKey { get; set; } = default!;
        public string Audience { get; set; } = default!;
        public string Issuer { get; set; } = default!;
    }
}
