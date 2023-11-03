using System.ComponentModel.DataAnnotations;

namespace KanbanBoard.Entities
{
    public class User : BaseEntity
    {
        public string LoginId { get; set; } = default!;
    }
}
