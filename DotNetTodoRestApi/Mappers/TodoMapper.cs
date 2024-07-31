using DotNetTodoRestApi.Dtos.Todo;
using DotNetTodoRestApi.Models;

namespace DotNetTodoRestApi.Mappers
{
    public static class TodoMapper
    {
        public static TodoDto toTodoDto(this Todo todo)
        {
            return new TodoDto
            {
                Id = todo.Id,
                Content = todo.Content,
                IsCompleted = todo.IsCompleted,
                Comments = todo.Comments.Select(e => e.toCommentDto()).ToList(),
                CreateadOn = todo.CreateadOn,
            };
        }

        public static Todo ToTodoFromCreateDto(this CreateTodoRequestDto todoDto)
        {
            return new Todo
            {
                Content = todoDto.Content,
                IsCompleted = todoDto.IsCompleted,
                CreateadOn = todoDto.CreateadOn,
            };
        }

        public static Todo ToTodoFromUpdateDto(this UpdateTodoRequestDto todoDto)
        {
            return new Todo
            {
                Content = todoDto.Content,
                IsCompleted = todoDto.IsCompleted,
            };
        }
    }
}
