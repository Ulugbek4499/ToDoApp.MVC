using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDoItem, ToDoItem>().ReverseMap();
            CreateMap<ToDoList, ToDoItem>().ReverseMap();
        }
    }
}
