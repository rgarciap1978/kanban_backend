using KanbanBoard.Shared.Request;
using KanbanBoard.Shared.Response;

namespace KanbanBoard.Service.Interface
{
    public interface IProjectService
    {
        Task<ResponseGenericObject<ICollection<ProjectResponse>>> ListAsync();
        Task<ResponseGenericObject<ProjectResponse>> FindByIdAsync(int id);
        Task<ResponseGenericObject<int>> AddAsync(ProjectRequest request);
        Task<BaseResponse> UpdateAsync(int id, ProjectRequest request);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
