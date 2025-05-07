using TaskManagerAPI.Models;
using TaskManagerLibrary.Dtos;

namespace TaskManagerAPI.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItemDto>> GetTasks();
        Task<TaskItemDto?> GetTask(int id);
        Task<TaskItemDto> CreateTask(TaskItemDto taskDto);
        Task<bool> UpdateTask(int id, TaskItemDto taskDto);
        Task<bool> DeleteTask(int id);
    }
}
