using DotNetTodoRestApi.Dtos.Comment;
using DotNetTodoRestApi.Models;

namespace DotNetTodoRestApi.Repositories
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment comment);
        Task<Comment?> UpdateAsync(int id, UpdateCommentDto commentDto);
        Task<Comment?> DeleteAsync(int id);
    }
}
