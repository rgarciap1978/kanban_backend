using AutoMapper;
using KanbanBoard.Entities;
using KanbanBoard.Repository.Interface;
using KanbanBoard.Service.Interface;
using KanbanBoard.Shared.Request;
using KanbanBoard.Shared.Response;

namespace KanbanBoard.Service
{
    public class TemplateService : ITemplateService
    {
        private readonly ITemplateRepository _repository;
        private readonly IMapper _mapper;

        public TemplateService(
            ITemplateRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseGenericObject<int>> AddAsync(TemplateRequest request)
        {
            var response = new ResponseGenericObject<int>();

            try
            {
                var entity = _mapper.Map<Template>(request);
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

        public async Task<ResponseGenericObject<TemplateResponse>> FindByIdAsync(int id)
        {
            var response = new ResponseGenericObject<TemplateResponse>();

            try
            {
                var entity = await _repository.FindAsync(id) ?? throw new ApplicationException("Not found");
                response.Data = _mapper.Map<TemplateResponse>(entity);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<ResponseGenericObject<ICollection<TemplateResponse>>> ListAsync()
        {
            var response = new ResponseGenericObject<ICollection<TemplateResponse>>();

            try
            {
                var entity = await _repository.ListAsync();
                response.Data = _mapper.Map<ICollection<TemplateResponse>>(entity);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id, TemplateRequest request)
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
