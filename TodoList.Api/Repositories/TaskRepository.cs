using Microsoft.EntityFrameworkCore;
using TodoList.Api.Data;

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

        public async Task<IEnumerable<Entitier.Task>> GetTasksList()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Entitier.Task> Update(Entitier.Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}
