using AutoMapper;
using KanbanBoard.Entities;
using KanbanBoard.Repository.Interface;
using KanbanBoard.Service.Interface;
using KanbanBoard.Shared.Request;
using KanbanBoard.Shared.Response;

namespace KanbanBoard.Service
{
    public class TeamService : ITeamService
    {

        private readonly ITeamRepository _repository;
        private readonly IMapper _mapper;

        public TeamService(
            ITeamRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseGenericObject<int>> AddAsync(TeamRequest request)
        {
            var response = new ResponseGenericObject<int>();

            try
            {
                var entity = _mapper.Map<Team>(request);
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

        public async Task<ResponseGenericObject<TeamResponse>> FindByIdAsync(int id)
        {
            var response = new ResponseGenericObject<TeamResponse>();

            try
            {
                var entity = await _repository.FindAsync(id) ?? throw new ApplicationException("Not found");
                response.Data = _mapper.Map<TeamResponse>(entity);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<ResponseGenericObject<ICollection<TeamResponse>>> ListAsync()
        {
            var response = new ResponseGenericObject<ICollection<TeamResponse>>();

            try
            {
                var entity = await _repository.ListAsync();
                response.Data = _mapper.Map<ICollection<TeamResponse>>(entity);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id, TeamRequest request)
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
