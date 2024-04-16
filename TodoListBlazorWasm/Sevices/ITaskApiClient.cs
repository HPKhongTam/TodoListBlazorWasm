using TodoList.Models;
using TodoList.Models.SeedWork;

namespace TodoListBlazorWasm.Sevices
{
    public interface ITaskApiClient
    {
        Task<PageList<TaskDto>> GetTaskList(TaskListSearch taskListSearch);

        Task<TaskDto> GetTaskDetail(string id);

        Task<bool> CreateTask(TaskCreateRequest request);

        Task<bool> UpdateTask(Guid Id, TaskUpdateRequest request);

        Task<bool>AssignTask(Guid id,AssignTaskRequest request);

        Task<bool> DeleteTask(Guid Id); 
    }
}
