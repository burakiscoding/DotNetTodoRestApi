using DotNetTodoRestApi.Dtos.Comment;
using DotNetTodoRestApi.Models;

namespace DotNetTodoRestApi.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto toCommentDto(this Comment comment)
        {
            return new CommentDto
            {
                Id = comment.Id,
                Content = comment.Content,
                CreateadOn = comment.CreateadOn,
                TodoId = comment.TodoId,
            };
        }

        public static Comment toCommentFromCreate(this CreateCommentDto dto, int todoId)
        {
            return new Comment
            {
                Content = dto.Content,
                CreateadOn = DateTime.Now,
                TodoId = todoId,
            };
        }
    }
}
