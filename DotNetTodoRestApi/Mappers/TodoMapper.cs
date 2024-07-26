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
    }
}
