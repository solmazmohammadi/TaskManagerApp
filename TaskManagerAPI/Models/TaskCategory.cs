using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models
{
    public class TaskCategory
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<TaskItem>? Tasks { get; set; }
    }
}
