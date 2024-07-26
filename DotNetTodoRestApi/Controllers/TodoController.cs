using DotNetTodoRestApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IResult> GetAllAsync()
        {
            var todos = await _context.Todos.ToListAsync();
            return TypedResults.Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetByIdAsync([FromRoute] int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(todo);
        }
    }
}
