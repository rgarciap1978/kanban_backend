using AutoMapper;
using KanbanBoard.Entities;
using KanbanBoard.Shared.Request;
using KanbanBoard.Shared.Response;

namespace KanbanBoard.Service.Profiles
{
    public class TemplateProfile : Profile
    {
        public TemplateProfile()
        {
            CreateMap<TemplateRequest, Template>()
                .ForMember(d => d.Name, m => m.MapFrom(o => o.Name))
                .ForMember(d => d.Status, m => m.MapFrom(o => o.Status));

            CreateMap<Template, TemplateResponse>()
                .ForMember(d => d.Id, m => m.MapFrom(d => d.Id))
                .ForMember(d => d.Name, m => m.MapFrom(o => o.Name))
                .ForMember(d => d.Status, m => m.MapFrom(o => o.Status));
        }
    }
}
