using TodoList.Models;

namespace TodoListBlazorWasm.Sevices
{
    public interface IUserApiClient
    {
        Task<List<AssigneeDto>> GetAssignees();
    }
}
