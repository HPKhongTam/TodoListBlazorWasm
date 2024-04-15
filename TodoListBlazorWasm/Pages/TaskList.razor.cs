using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TodoList.Models;
using TodoList.Models.Enums;
using TodoListBlazorWasm.Compo;
using TodoListBlazorWasm.Pages.Components;
using TodoListBlazorWasm.Sevices;

namespace TodoListBlazorWasm.Pages
{
    public partial class TaskList
    {
        [Inject] private ITaskApiClient TaskApiClient { get; set; }
        [Inject] private IUserApiClient UserApiClient { get; set; }
        private List<TaskDto> Tasks;

        private Guid DeleteId {  get; set; }        
        protected Confirmation DeleteConfirmation { get; set; }
        protected AssignTask AssignTaskDialog { get; set; }

        private TaskListSearch TaskListSearch = new TaskListSearch();
      
        protected override async Task OnInitializedAsync()
        {
            Tasks = await TaskApiClient.GetTaskList(TaskListSearch);
           
        }
        public async Task SearchTask(TaskListSearch taskListSearch)
        {
            TaskListSearch = taskListSearch;
            Tasks = await TaskApiClient.GetTaskList(TaskListSearch);
        }
        public void OnDeleteTask(Guid deleteid)
        {
            DeleteId = deleteid;
           
            DeleteConfirmation.Show();
        }
        public async Task OnConfirmDeleteTask(bool deleteConfirmed)
        {
            if (deleteConfirmed) 
            {
                await TaskApiClient.DeleteTask(DeleteId);
                Tasks = await TaskApiClient.GetTaskList(TaskListSearch);
            }
        }
        public void OpenAssignPopup(Guid id)
        {
            AssignTaskDialog.Show(id);
        }
        public async void AssignTaskSuccess(bool result)
        {
            if(result)
            {
                Tasks = await TaskApiClient.GetTaskList(TaskListSearch);
            }    
        }
    }
    
}
