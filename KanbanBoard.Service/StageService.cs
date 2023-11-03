using AutoMapper;
using KanbanBoard.Entities;
using KanbanBoard.Repository.Interface;
using KanbanBoard.Service.Interface;
using KanbanBoard.Shared.Request;
using KanbanBoard.Shared.Response;

namespace KanbanBoard.Service
{
    public class StageService : IStageService
    {
        private readonly IStageRepository _repository;
        private readonly IMapper _mapper;

        public StageService(
            IStageRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseGenericObject<int>> AddAsync(StageRequest request)
        {
            var response = new ResponseGenericObject<int>();

            try
            {
                var entity = _mapper.Map<Stage>(request);
                await _repository.AddAsync(entity);
                response.Data = entity.Id;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var response = new BaseResponse();

            try
            {
                await _repository.DeleteAsync(id);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<ResponseGenericObject<StageResponse>> FindByIdAsync(int id)
        {
            var response = new ResponseGenericObject<StageResponse>();

            try
            {
                var entity = await _repository.FindAsync(id) ?? throw new ApplicationException("Not found");
                response.Data = _mapper.Map<StageResponse>(entity);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<ResponseGenericObject<ICollection<StageResponse>>> ListAsync()
        {
            var response = new ResponseGenericObject<ICollection<StageResponse>>();

            try
            {
                var entity = await _repository.ListAsync();
                response.Data = _mapper.Map<ICollection<StageResponse>>(entity);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id, StageRequest request)
        {
            var response = new BaseResponse();

            try
            {
                var entity = await _repository.FindAsync(id) ?? throw new ApplicationException("Not found");
                _mapper.Map(request, entity);
                await _repository.UpdateAsync();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
    }
}
