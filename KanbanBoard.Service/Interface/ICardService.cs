using KanbanBoard.Shared.Request;
using KanbanBoard.Shared.Response;

namespace KanbanBoard.Service.Interface
{
    public interface ICardService
    {
        Task<ResponseGenericObject<ICollection<CardResponse>>> ListAsync();
        Task<ResponseGenericObject<CardResponse>> FindByIdAsync(int id);
        Task<ResponseGenericObject<int>> AddAsync(CardRequest request);
        Task<BaseResponse> UpdateAsync(int id, CardRequest request);
        Task<BaseResponse> DeleteAsync(int id);
    }
}
