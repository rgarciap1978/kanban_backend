using AutoMapper;
using KanbanBoard.Entities;
using KanbanBoard.Shared.Request;
using KanbanBoard.Shared.Response;

namespace KanbanBoard.Service.Profiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            CreateMap<CardRequest, Card>()
                .ForMember(d => d.Description, m => m.MapFrom(o => o.Description))
                .ForMember(d => d.StartDate, m => m.MapFrom(o => o.StartDate))
                .ForMember(d => d.EndDate, m => m.MapFrom(o => o.EndDate))
                .ForMember(d => d.Deadline, m => m.MapFrom(o => o.Deadline.HasValue ? o.Deadline : null))
                .ForMember(d => d.Status, m => m.MapFrom(o => o.Status))
                .ForMember(d => d.StageId, m => m.MapFrom(o => o.StageId))
                .ForMember(d => d.UserId, m => m.MapFrom(o => o.UserId))
                .ForMember(d => d.PriorityId, m => m.MapFrom(o => o.PriorityId));

            CreateMap<Card, CardResponse>()
                .ForMember(d => d.Description, m => m.MapFrom(o => o.Description))
                .ForMember(d => d.StartDate, m => m.MapFrom(o => o.StartDate))
                .ForMember(d => d.EndDate, m => m.MapFrom(o => o.EndDate))
                .ForMember(d => d.Deadline, m => m.MapFrom(o => o.Deadline))
                .ForMember(d => d.Status, m => m.MapFrom(o => o.Status))
                .ForMember(d => d.StageId, m => m.MapFrom(o => o.StageId))
                .ForMember(d => d.StageName, m => m.MapFrom(o => o.Stage.Name))
                .ForMember(d => d.UserId, m => m.MapFrom(o => o.UserId))
                .ForMember(d => d.PriorityId, m => m.MapFrom(o => o.PriorityId))
                .ForMember(d => d.PriorityName, m => m.MapFrom(o => o.Priority.Name));
        }
    }
}
