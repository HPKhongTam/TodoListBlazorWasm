using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Repositories;
using TodoList.Models;

namespace TodoList.Api.Controler
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetUserList();
            var assigines = users.Select(x=> new AssigneeDto()
            {
                Id= x.Id,
                FullName =x.FirstName + " " + x.LastName
            });
            return Ok(assigines);
        }

    }
}
