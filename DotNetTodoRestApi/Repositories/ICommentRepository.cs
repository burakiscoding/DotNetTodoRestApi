using DotNetTodoRestApi.Models;

namespace DotNetTodoRestApi.Repositories
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment comment);
    }
}
