using DotNetTodoRestApi.Models;

namespace DotNetTodoRestApi.Repositories
{
    public interface ILikedTodoRepository
    {
        Task<List<Todo>> GetLikedTodosAsync(string userId);
    }
}
