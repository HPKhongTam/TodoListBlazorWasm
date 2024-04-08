using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Repositories;
using Task = TodoList.Api.Entitier.Task;


namespace TodoList.Api.Controler
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskRepository.GetTasksList();
            return Ok(tasks);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Task task)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var _task = await _taskRepository.Create(task);
            return CreatedAtAction(nameof(GetById), _task);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(Guid id, Entitier.Task task)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var _task = await _taskRepository.GetByID(id);
            if (_task == null)
                return NotFound($"{id} is not fount");
            var tasks = await _taskRepository.Update(task);
            return Ok(tasks);
        }
        //api/task/id
        [HttpGet()]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var tasks = await _taskRepository.GetByID(id);
            if (tasks == null) return NotFound($"{id} is not found");
            return Ok(tasks);
        }
    }
}
