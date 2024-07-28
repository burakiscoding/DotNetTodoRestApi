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
    }
}
