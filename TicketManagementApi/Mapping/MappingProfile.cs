using AutoMapper;
using TicketManagementApi.Models;
using TicketManagementApi.Models.DTOs;

namespace TicketManagementApi.Mapping
{
    public class MappingProfile : Profile
    { 
        public MappingProfile()
        {
            CreateMap<CreateMatchDto, Match>();
            CreateMap<UpdateMatchDto, Match>();
            CreateMap<Match, MatchDto>();
            CreateMap<CreateUpdateStadiumDto, Stadium>();
            CreateMap<Stadium, StadiumDto>();

        }
    }
}
