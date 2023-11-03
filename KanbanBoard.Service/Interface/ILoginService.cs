using KanbanBoard.Shared.Request;
using KanbanBoard.Shared.Response;

namespace KanbanBoard.Service.Interface
{
    public interface ILoginService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}
