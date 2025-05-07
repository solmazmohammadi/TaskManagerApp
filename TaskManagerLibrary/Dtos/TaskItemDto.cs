namespace TaskManagerLibrary.Dtos
{
    public class TaskItemDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }

        public int CategoryId { get; set; }
    }
}
