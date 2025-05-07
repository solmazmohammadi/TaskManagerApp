using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskManagerAPI.Data;
using TaskManagerLibrary.Dtos;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Services
{
    public class TaskService: ITaskService
    {
        private readonly TaskContext _context;
        private readonly IMapper _mapper;

        public TaskService(TaskContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskItemDto>> GetTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return _mapper.Map<IEnumerable<TaskItemDto>>(tasks);
        }
        
        public async Task<TaskItemDto?> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task == null)
            {
                return null;
            }

            return _mapper.Map<TaskItemDto>(task);
        }

        public async Task<TaskItemDto> CreateTask(TaskItemDto taskDto)
        {
            var task = _mapper.Map<TaskItem>(taskDto);
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return _mapper.Map<TaskItemDto>(task);
        }


        public async Task<bool> UpdateTask(int id, TaskItemDto taskDto)
        {
            var task = _mapper.Map<TaskItem>(taskDto);
            if (id != task.Id)
            {
                return false;
            }
            _context.Entry(task).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await TaskExists(id))
                {
                    return false;
                }
                throw;
            }
            return true;
        }
        public async Task<bool> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return false;
            }
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
        private async Task<bool> TaskExists(int id)
        {
            return await _context.Tasks.AnyAsync(e => e.Id == id);
        }
    }
}
