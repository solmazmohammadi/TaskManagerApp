using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models
{
    public class TaskItem 
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public required string Title { get; set; }
        public bool IsCompleted { get; set; }
        public int CategoryId { get; set; }
        public TaskCategory? Category { get; set; }
        
    }
    
}
