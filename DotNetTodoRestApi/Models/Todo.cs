namespace DotNetTodoRestApi.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public List<Comment> Comments { get; set; } = [];
        public DateTime CreateadOn { get; set; }
    }
}
