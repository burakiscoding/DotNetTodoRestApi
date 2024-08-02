using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetTodoRestApi.Models
{
    [Table("Todos")]
    public class Todo
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public List<Comment> Comments { get; set; } = [];
        public DateTime CreateadOn { get; set; }
        public List<LikedTodo> LikedTodos { get; set; } = [];
    }
}
