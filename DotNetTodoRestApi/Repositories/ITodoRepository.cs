using DotNetTodoRestApi.Models;

namespace DotNetTodoRestApi.Repositories
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetAllAsync();
        Task<Todo?> GetByIdAsync(int id);
        Task<Todo> CreateAsync(Todo todo);
        Task<Todo?> UpdateAsync(int id, Todo todo);
        Task<Todo?> DeleteAsync(int id);
    }
}
