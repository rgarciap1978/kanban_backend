using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanBoard.Shared.Response
{
    public class LoginResponse : BaseResponse
    {
        public string Token { get; set; } = default!;
        public string Fullname { get; set; } = default!;
        public string Initials { get; set; } = default!;
        public List<string> Roles { get; set; } = default!;
    }
}
