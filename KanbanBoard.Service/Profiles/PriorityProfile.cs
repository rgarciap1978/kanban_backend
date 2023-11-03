using AutoMapper;
using KanbanBoard.Entities;
using KanbanBoard.Shared.Request;
using KanbanBoard.Shared.Response;

namespace KanbanBoard.Service.Profiles
{
    public class PriorityProfile : Profile
    {
        public PriorityProfile()
        {
            CreateMap<PriorityRequest, Priority>()
                .ForMember(d => d.Name, m => m.MapFrom(o => o.Name))
                .ForMember(d => d.Color, m => m.MapFrom(o => o.Color))
                .ForMember(d => d.Status, m => m.MapFrom(o => o.Status));

            CreateMap<Priority, PriorityResponse>()
                .ForMember(d => d.Name, m => m.MapFrom(o => o.Name))
                .ForMember(d => d.Color, m => m.MapFrom(o => o.Color))
                .ForMember(d => d.Status, m => m.MapFrom(o => o.Status));
        }
    }
}
