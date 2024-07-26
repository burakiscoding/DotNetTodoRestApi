namespace DotNetTodoRestApi.Dtos.Todo
{
    public class UpdateTodoRequestDto
    {
        public string Content { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
    }
}
