using Microsoft.AspNetCore.Identity;

namespace DotNetTodoRestApi.Models
{
    public class AppUser : IdentityUser
    {
        public List<LikedTodo> LikedTodos { get; set; } = [];
    }
}
