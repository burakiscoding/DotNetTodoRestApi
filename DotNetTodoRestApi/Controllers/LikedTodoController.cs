using DotNetTodoRestApi.Extensions;
using DotNetTodoRestApi.Models;
using DotNetTodoRestApi.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace DotNetTodoRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikedTodoController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILikedTodoRepository _likedTodoRepository;
        public LikedTodoController(UserManager<AppUser> userManager, ILikedTodoRepository likedTodoRepository)
        {
            _userManager = userManager;
            _likedTodoRepository = likedTodoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var username = User.GetUsername();
            if (string.IsNullOrEmpty(username))
            {
                return Unauthorized();
            }

            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                return Unauthorized();
            }

            var likedTodos = await _likedTodoRepository.GetLikedTodosAsync(user.Id);
            return Ok(likedTodos);
        }
    }
}
