using Microsoft.AspNetCore.Components;
using TodoList.Models;
using TodoList.Models.Enums;
using TodoListBlazorWasm.Sevices;

namespace TodoListBlazorWasm.Pages
{
    public partial class TaskList
    {
        [Inject] private ITaskApiClient TaskApiClient { get; set; }
        private List<TaskDto> Tasks;
        private TaskListSearch TaskListSearch = new TaskListSearch();
        protected override async Task OnInitializedAsync()
        {
            Tasks = await TaskApiClient.GetTaskList();
        }
    }
    public class TaskListSearch
    {
        public string Name { get; set; }
        public Guid AssigneeId { get; set; }
        public Priority Priority { get; set; }
    }
}
