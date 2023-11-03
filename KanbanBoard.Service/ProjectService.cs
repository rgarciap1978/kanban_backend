using AutoMapper;
using KanbanBoard.Entities;
using KanbanBoard.Repository.Interface;
using KanbanBoard.Service.Interface;
using KanbanBoard.Shared.Request;
using KanbanBoard.Shared.Response;

namespace KanbanBoard.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly IMapper _mapper;

        public ProjectService(
            IProjectRepository repository,
            IMapper mapper
        )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseGenericObject<int>> AddAsync(ProjectRequest request)
        {
            var response = new ResponseGenericObject<int>();

            try
            {
                var project = _mapper.Map<Project>(request);
                await _repository.AddAsync(project);
                response.Data = project.Id;
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

        public async Task<ResponseGenericObject<ProjectResponse>> FindByIdAsync(int id)
        {
            var response = new ResponseGenericObject<ProjectResponse>();

            try
            {
                var project = await _repository.FindAsync(id) ?? throw new ApplicationException("Not found");
                response.Data = _mapper.Map<ProjectResponse>(project);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<ResponseGenericObject<ICollection<ProjectResponse>>> ListAsync()
        {
            var response = new ResponseGenericObject<ICollection<ProjectResponse>>();

            try
            {
                var project = await _repository.ListAsync();
                response.Data = _mapper.Map<ICollection<ProjectResponse>>(project);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
            }

            return response;
        }

        public async Task<BaseResponse> UpdateAsync(int id, ProjectRequest request)
        {
            var response = new BaseResponse();

            try
            {
                var project = await _repository.FindAsync(id) ?? throw new Exception("Not found");
                _mapper.Map(request, project);
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
