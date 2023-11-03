using AutoMapper;
using KanbanBoard.Entities;
using KanbanBoard.Shared.Request;
using KanbanBoard.Shared.Response;

namespace KanbanBoard.Service.Profiles
{
    public class StageProfile:Profile
    {
        public StageProfile()
        {
            CreateMap<StageRequest, Stage>()
                .ForMember(d => d.Name, m => m.MapFrom(o => o.Name))
                .ForMember(d => d.Position, m => m.MapFrom(o => o.Position))
                .ForMember(d => d.Status, m => m.MapFrom(o => o.Status))
                .ForMember(d => d.TemplateId, m => m.MapFrom(o => o.TemplateId));

            CreateMap<Stage, StageResponse>()
                .ForMember(d => d.Id, m => m.MapFrom(d => d.Id))
                .ForMember(d => d.Name, m => m.MapFrom(o => o.Name))
                .ForMember(d => d.Position, m => m.MapFrom(o => o.Position))
                .ForMember(d => d.Status, m => m.MapFrom(o => o.Status))
                .ForMember(d => d.TemplateId, m => m.MapFrom(o => o.TemplateId))
                .ForMember(d => d.TemplateName, m => m.MapFrom(o => o.Template.Name));
        }
    }
}
