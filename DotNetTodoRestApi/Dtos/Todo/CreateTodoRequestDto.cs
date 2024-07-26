namespace DotNetTodoRestApi.Dtos.Todo
{
    public class CreateTodoRequestDto
    {
        public string Content { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public DateTime CreateadOn { get; set; }
    }
}
