using AutoMapper;
using Euro.Domain;
using Euro.Domain.ApiModels;
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
            CreateMap<Group, GroupApiModel>().ReverseMap();
            CreateMap<Team, TeamApiModel>().ReverseMap();
            CreateMap<Match, MatchApiModel>().ReverseMap();
        }
    }
}