using TaskManagerAPI.Models;

namespace TaskManagerAPI.Data
{
    public class DataSeeder
    {
        private readonly TaskContext _context;

        public DataSeeder(TaskContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.TaskCategories.Any())
            {
                var categories = new List<TaskCategory>
                {
                    new TaskCategory { Name = "Work" },
                    new TaskCategory { Name = "Personal" },
                    new TaskCategory { Name = "Urgent" }
                };
                _context.TaskCategories.AddRange(categories);
                _context.SaveChanges();
            }
            if (!_context.Tasks.Any())
            {
                var tasks = new List<TaskItem>
                {
                    new TaskItem { Title = "Task 1", IsCompleted = false, CategoryId = 1 },
                    new TaskItem { Title = "Task 2", IsCompleted = true, CategoryId = 2 },
                    new TaskItem { Title = "Task 3", IsCompleted = false, CategoryId = 3 }
                };
                _context.Tasks.AddRange(tasks);
                _context.SaveChanges();
            }
        }
    }

}
