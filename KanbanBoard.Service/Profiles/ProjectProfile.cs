using AutoMapper;
using KanbanBoard.Entities;
using KanbanBoard.Shared.Request;
using KanbanBoard.Shared.Response;

namespace KanbanBoard.Service.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<ProjectRequest, Project>()
                .ForMember(d => d.Name, m => m.MapFrom(o => o.Name))
                .ForMember(d => d.Description, m => m.MapFrom(o => o.Description))
                .ForMember(d => d.Status, m => m.MapFrom(o => o.Status));

            CreateMap<Project, ProjectResponse>()
                .ForMember(d => d.Id, m => m.MapFrom(d => d.Id))
                .ForMember(d => d.Name, m => m.MapFrom(d => d.Name))
                .ForMember(d => d.Description, m => m.MapFrom(d => d.Description))
                .ForMember(d => d.Status, m => m.MapFrom(d => d.Status));
        }
    }
}
