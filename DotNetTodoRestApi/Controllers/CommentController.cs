using DotNetTodoRestApi.Dtos.Comment;
using DotNetTodoRestApi.Mappers;
using DotNetTodoRestApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTodoRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly ITodoRepository _todoRepository;
        public CommentController(ICommentRepository commentRepository, ITodoRepository todoRepository)
        {
            _commentRepository = commentRepository;
            _todoRepository = todoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var comments = await _commentRepository.GetAllAsync();
            return Ok(comments.Select(e => e.toCommentDto()));
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.toCommentDto());
        }

        [HttpPost("{todoId:int}")]
        public async Task<IActionResult> CreateAsync([FromRoute] int todoId, [FromBody] CreateCommentDto commentDto)
        {
            if (!await _todoRepository.AnyAsync(todoId))
            {
                return NotFound();
            }
            var comment = commentDto.toCommentFromCreate(todoId);
            await _commentRepository.CreateAsync(comment);
            return CreatedAtAction(nameof(GetByIdAsync), new { id = comment.Id }, comment.toCommentDto());
        }
    }
}
