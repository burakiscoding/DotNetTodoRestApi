using DotNetTodoRestApi.Dtos.Todo;
using DotNetTodoRestApi.Mappers;
using DotNetTodoRestApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTodoRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var todos = await _todoRepository.GetAllAsync();
            return Ok(todos.Select(e => e.toTodoDto()));
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var todo = await _todoRepository.GetByIdAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo.toTodoDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTodoRequestDto todoDto)
        {
            var todo = todoDto.ToTodoFromCreateDto();
            await _todoRepository.CreateAsync(todo);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = todo.Id }, todo.toTodoDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTodoRequestDto todoDto)
        {
            var todo = await _todoRepository.UpdateAsync(id, todoDto.ToTodoFromUpdateDto());
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo.toTodoDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var todo = await _todoRepository.DeleteAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
