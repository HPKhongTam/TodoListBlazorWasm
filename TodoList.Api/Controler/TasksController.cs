using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Enums;
using TodoList.Api.Repositories;
using TodoList.Models;
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
        public async Task<IActionResult> GetAll([FromQuery] TaskListSearch taskListSearch)
        {
            var tasks = await _taskRepository.GetTasksList(taskListSearch);
            return Ok(tasks);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskCreateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var _task = await _taskRepository.Create(new Task()
            {
                Name = request.Name,
                Status = (int)Status.Open,
                CreatedDate = DateTime.Now,
                Priority = request.Priority.HasValue? (int)request.Priority.Value:(int)Priority.Low,
                Id = request.Id

            });
            return CreatedAtAction(nameof(GetById), new { id = _task.Id }, _task);
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
            _task.Name = task.Name;
            _task.Priority = task.Priority; 
            var tasks = await _taskRepository.Update(_task);
            return Ok(new TaskDto()
            {
                Name = tasks.Name != null ? tasks.Name : "",
                Status = (Models.Enums.Status)tasks.Status,
                Id = tasks.Id,
                CreatedDate = tasks.CreatedDate,
                AsigneeId = tasks.AssigneeId,
                Priority = (Models.Enums.Priority)tasks.Priority
            });
        }
        //api/task/id
        [HttpGet()]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var tasks = await _taskRepository.GetByID(id);
            if (tasks == null) return NotFound($"{id} is not found");
            return Ok(tasks);
        }
    }
}
