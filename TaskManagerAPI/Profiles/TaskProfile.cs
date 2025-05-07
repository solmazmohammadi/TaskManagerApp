using AutoMapper;
using TaskManagerAPI.Models;
using TaskManagerLibrary.Dtos;

namespace TaskManagerAPI.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskItem, TaskItemDto>();
            CreateMap<TaskItemDto, TaskItem>();
        }
    }
}
