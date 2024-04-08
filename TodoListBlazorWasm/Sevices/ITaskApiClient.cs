using TodoList.Models;

namespace TodoListBlazorWasm.Sevices
{
    public interface ITaskApiClient
    {
        Task<List<TaskDto>> GetTaskList();

        Task<TaskDto> GetTaskDetail(string id);
    }
}
