using AutoMapper;
using ToDoApp.Application.Commons.Models;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Commons.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDoItem, ToDoItemDto>().ReverseMap();
            CreateMap<ToDoList, ToDoListDto>().ReverseMap();
        }
    }
}
