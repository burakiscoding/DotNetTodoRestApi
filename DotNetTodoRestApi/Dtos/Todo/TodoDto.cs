using DotNetTodoRestApi.Dtos.Comment;

namespace DotNetTodoRestApi.Dtos.Todo
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public List<CommentDto> Comments { get; set; } = [];
        public DateTime CreateadOn { get; set; }
    }
}
