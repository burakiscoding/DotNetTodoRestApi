using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetTodoRestApi.Models
{
    [Table("LikedTodos")]
    public class LikedTodo
    {
        public string AppUserId { get; set; } = null!;
        public int TodoId { get; set; }
        public AppUser AppUser { get; set; } = null!;
        public Todo Todo { get; set; } = null!;
    }
}
