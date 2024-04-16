using TodoList.Models;
using TodoList.Models.SeedWork;
using Task= TodoList.Api.Entitier.Task;

namespace TodoList.Api.Repositories
{
   public  interface ITaskRepository
    {
        Task<PageList<Task>> GetTasksList(TaskListSearch taskListSearch);

        Task<Task> Delete(Task task);

        Task<Task> Update(Task task);

        Task<Task> Create(Task task);

        Task<Task> GetByID(Guid id);

    }
}
