using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace KanbanBoard.DataAccess
{
    public class KanbanBoardLoginIdentity : IdentityUser
    {
        [StringLength(100)]
        public string FirstName { get; set; } = default!;

        [StringLength(100)]
        public string LastName { get; set; } = default!;
    }
}
