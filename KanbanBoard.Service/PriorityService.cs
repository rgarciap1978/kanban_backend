using AutoMapper;
using KanbanBoard.Entities;
using KanbanBoard.Repository.Interface;
using KanbanBoard.Service.Interface;
using KanbanBoard.Shared.Request;
using KanbanBoard.Shared.Response;

namespace KanbanBoard.Service
{
    public class PriorityService : IPriorityService
    {
        private readonly IPriorityRepository _repository;
        private readonly IMapper _mapper;

        public PriorityService(
            IPriorityRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseGenericObject<int>> AddAsync(PriorityRequest request)
        {
            var response = new ResponseGenericObject<int>();

            try
            {
                var priority = _mapper.Map<Priority>(request);
                await _repository.AddAsync(priority);
                response.Data = priority.Id;
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

        public async Task<ResponseGenericObject<PriorityResponse>> FindByIdAsync(int id)
        {
            var response = new ResponseGenericObject<PriorityResponse>();

            try
            {
                var priority = await _repository.FindAsync(id) ?? throw new ApplicationException("Not found");
                response.Data = _mapper.Map<PriorityResponse>(priority);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<ResponseGenericObject<ICollection<PriorityResponse>>> ListAsync()
        {
            var response = new ResponseGenericObject<ICollection<PriorityResponse>>();

            try
            {
                var priority = await _repository.ListAsync();
                response.Data = _mapper.Map<ICollection<PriorityResponse>>(priority);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id, PriorityRequest request)
        {
            var response = new BaseResponse();

            try
            {
                var priority = await _repository.FindAsync(id) ?? throw new ApplicationException("Not found");
                _mapper.Map(request, priority);
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
