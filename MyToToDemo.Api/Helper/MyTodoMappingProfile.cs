using AutoMapper;
using MyToDoDemo.Common.Dtos;
using MyToToDemo.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToToDemo.Api.Helper
{
    public class MyTodoMappingProfile : Profile
    {
        public MyTodoMappingProfile()
        {
            CreateMap<ToDo, ToDoDto>();
            CreateMap<ToDoDto, ToDo>().ForMember(dest => dest.UpdateTime, config => config.MapFrom(src => DateTime.Now));
            CreateMap<Memo, MemoDto>().ReverseMap();
            CreateMap<MemoDto, Memo>().ForMember(dest => dest.UpdateTime, config => config.MapFrom(src => DateTime.Now));
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, User>().ForMember(dest => dest.UpdateTime, config => config.MapFrom(src => DateTime.Now));
        }
    }
}
