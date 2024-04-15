using Microsoft.EntityFrameworkCore;
using TodoList.Api.Data;
using TodoList.Models;
using TodoList.Models.Enums;

namespace TodoList.Api.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TodoListDbContext _context;
        public TaskRepository(TodoListDbContext context)
        {
            _context = context;
        }
        public async Task<Entitier.Task> Create(Entitier.Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Entitier.Task> Delete(Entitier.Task task)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Entitier.Task> GetByID(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<IEnumerable<TaskDto>> GetTasksList(TaskListSearch taskListSearch)
        {
            var query = _context.Tasks.Include(x => x.Assignee).AsQueryable();
            if (!string.IsNullOrEmpty(taskListSearch.Name))
                query = query.Where(x => x.Name.Contains(taskListSearch.Name));
            if (taskListSearch.AssigneeId.HasValue && taskListSearch.AssigneeId.Value.ToString() != "0")
                query = query.Where(x => x.AssigneeId.Value == taskListSearch.AssigneeId.Value);
            if (taskListSearch.Priority.HasValue && taskListSearch.Priority.Value.ToString() != "100")
                query = query.Where(x => x.Priority == (int)taskListSearch.Priority.Value);
          

            return await query.Select(x => new TaskDto()
            {
                Status = (Status)x.Status,
                Name = x.Name != null ? x.Name : "",
                AsigneeId = x.AssigneeId,
                AssigneeName = x.Assignee != null ? x.Assignee.FirstName + ' ' + x.Assignee.LastName : "N/A",
                CreatedDate = x.CreatedDate,
                Priority = (Priority)x.Priority,
                Id = x.Id,
            }).OrderByDescending(x=>x.CreatedDate).ToListAsync();


        }

        public async Task<Entitier.Task> Update(Entitier.Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}
