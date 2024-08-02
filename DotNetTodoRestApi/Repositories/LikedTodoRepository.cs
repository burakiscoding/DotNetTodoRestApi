using DotNetTodoRestApi.Data;
using DotNetTodoRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetTodoRestApi.Repositories
{
    public class LikedTodoRepository : ILikedTodoRepository
    {
        private readonly ApplicationDbContext _context;
        public LikedTodoRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Todo>> GetLikedTodosAsync(string userId)
        {
            return await _context.LikedTodos.Where(e => string.Equals(e.AppUserId, userId))
                .Select(e => new Todo
                {
                    Id = e.TodoId,
                    Content = e.Todo.Content,
                    IsCompleted = e.Todo.IsCompleted,
                    Comments = e.Todo.Comments,
                    CreateadOn = e.Todo.CreateadOn,
                }).ToListAsync();
        }
    }
}
