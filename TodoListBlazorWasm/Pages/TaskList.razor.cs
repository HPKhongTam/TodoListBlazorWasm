using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TodoList.Models;
using TodoList.Models.Enums;
using TodoListBlazorWasm.Sevices;

namespace TodoListBlazorWasm.Pages
{
    public partial class TaskList
    {
        [Inject] private ITaskApiClient TaskApiClient { get; set; }
        [Inject] private IUserApiClient UserApiClient { get; set; }
        private List<TaskDto> Tasks;
        private List<AssigneeDto> Assignees;
        private TaskListSearch TaskListSearch = new TaskListSearch();
      
        protected override async Task OnInitializedAsync()
        {
            Tasks = await TaskApiClient.GetTaskList(TaskListSearch);
            Assignees = await UserApiClient.GetAssignees();
        }
        private async Task SearchForm(EditContext editContext)
        {
            Tasks = await TaskApiClient.GetTaskList(TaskListSearch);
        }
    }
    
}
