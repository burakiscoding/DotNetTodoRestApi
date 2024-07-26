using DotNetTodoRestApi.Data;
using DotNetTodoRestApi.Dtos.Todo;
using DotNetTodoRestApi.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace DotNetTodoRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var todos = await _context.Todos.Select(e => e.toTodoDto()).ToListAsync();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var todo = await _context.Todos.FindAsync(id);
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
            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetByIdAsync), new { id = todo.Id }, todo.toTodoDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTodoRequestDto todoDto)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.Content = todoDto.Content;
            todo.IsCompleted = todoDto.IsCompleted;
            await _context.SaveChangesAsync();
            return Ok(todo.toTodoDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if(todo == null)
            {
                return NotFound();
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
