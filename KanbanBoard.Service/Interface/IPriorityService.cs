using KanbanBoard.Shared.Request;
using KanbanBoard.Shared.Response;

namespace KanbanBoard.Service.Interface
{
    public interface IPriorityService
    {
        Task<ResponseGenericObject<ICollection<PriorityResponse>>> ListAsync();
        Task<ResponseGenericObject<PriorityResponse>> FindByIdAsync(int id);
        Task<ResponseGenericObject<int>> AddAsync(PriorityRequest request);
        Task<BaseResponse> UpdateAsync(int id, PriorityRequest request);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
