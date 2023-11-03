using KanbanBoard.Shared.Request;
using KanbanBoard.Shared.Response;

namespace KanbanBoard.Service.Interface
{
    public interface IStageService 
    {
        Task<ResponseGenericObject<ICollection<StageResponse>>> ListAsync();
        Task<ResponseGenericObject<StageResponse>> FindByIdAsync(int id);
        Task<ResponseGenericObject<int>> AddAsync(StageRequest request);
        Task<BaseResponse> UpdateAsync(int id, StageRequest request);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
