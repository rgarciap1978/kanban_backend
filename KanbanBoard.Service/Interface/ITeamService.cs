using KanbanBoard.Shared.Request;
using KanbanBoard.Shared.Response;

namespace KanbanBoard.Service.Interface
{
    public interface ITeamService
    {
        Task<ResponseGenericObject<ICollection<TeamResponse>>> ListAsync();
        Task<ResponseGenericObject<TeamResponse>> FindByIdAsync(int id);
        Task<ResponseGenericObject<int>> AddAsync(TeamRequest request);
        Task<BaseResponse> UpdateAsync(int id, TeamRequest request);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
