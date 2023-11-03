using KanbanBoard.Shared.Request;
using KanbanBoard.Shared.Response;

namespace KanbanBoard.Service.Interface
{
    public interface ITemplateService
    {
        Task<ResponseGenericObject<ICollection<TemplateResponse>>> ListAsync();
        Task<ResponseGenericObject<TemplateResponse>> FindByIdAsync(int id);
        Task<ResponseGenericObject<int>> AddAsync(TemplateRequest request);
        Task<BaseResponse> UpdateAsync(int id, TemplateRequest request);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
