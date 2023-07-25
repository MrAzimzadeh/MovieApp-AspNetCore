using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MovieApp.Entities.Concrete;
using MovieApp.Entities.DTOs.ActorDTOs;

namespace MovieApp.Business.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Actor, ActorDTO>().ReverseMap();

            CreateMap<Actor, ActorCreateDTO>().ReverseMap();
            
            CreateMap<Actor, ActorUpdateDTO>().ReverseMap();



        }
    }
}
