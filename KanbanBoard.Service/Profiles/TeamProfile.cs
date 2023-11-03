using AutoMapper;
using KanbanBoard.Entities;
using KanbanBoard.Shared.Request;
using KanbanBoard.Shared.Response;

namespace KanbanBoard.Service.Profiles
{
    public class TeamProfile:Profile
    {
        public TeamProfile()
        {
            CreateMap<TeamRequest, Team>()
                .ForMember(d => d.Status, m => m.MapFrom(o => o.Status))
                .ForMember(d => d.ProjectId, m => m.MapFrom(o => o.ProjectId))
                .ForMember(d => d.UserId, m => m.MapFrom(o => o.UserId));

            CreateMap<Team, TeamResponse>()
                .ForMember(d => d.Id, m => m.MapFrom(d => d.Id))
                .ForMember(d => d.Status, m => m.MapFrom(o => o.Status))
                .ForMember(d => d.ProjectId, m => m.MapFrom(o => o.ProjectId))
                .ForMember(d => d.ProjectName, m => m.MapFrom(o => o.Project.Name))
                .ForMember(d => d.UserId, m => m.MapFrom(o => o.UserId));
        }
    }
}
