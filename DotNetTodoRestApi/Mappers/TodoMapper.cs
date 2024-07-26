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
    }
}
