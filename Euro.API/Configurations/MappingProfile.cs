using AutoMapper;
using Euro.Domain;
using Euro.Domain.ApiModels;
using Euro.Shared.In;
using Euro.Shared.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro.API.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Group, GroupResultApiModel>().ReverseMap();
            CreateMap<Team, TeamApiModel>().ReverseMap();
            CreateMap<Team, TeamResultApiModel>().ReverseMap();
            CreateMap<Match, MatchApiModel>().ReverseMap();
            CreateMap<Match, MatchResultApiModel>().ReverseMap();
        }
    }
}