using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using TodoList.Models;
using TodoList.Models.Enums;
using TodoList.Models.SeedWork;
using TodoListBlazorWasm.Compo;
using TodoListBlazorWasm.Pages.Components;
using TodoListBlazorWasm.Sevices;
using TodoListBlazorWasm.Shared;

namespace TodoListBlazorWasm.Pages
{
    public partial class TaskList
    {
        [Inject] private ITaskApiClient TaskApiClient { get; set; }
        [Inject] private IUserApiClient UserApiClient { get; set; }
        private List<TaskDto> Tasks;

        private Guid DeleteId { get; set; }
        protected Confirmation DeleteConfirmation { get; set; }
        protected AssignTask AssignTaskDialog { get; set; }

        private TaskListSearch TaskListSearch = new TaskListSearch();

        private MetaData MetaData { get; set; } = new MetaData();
        [CascadingParameter]
        private Error Error { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await GetTasks();

        }
        public async Task SearchTask(TaskListSearch taskListSearch)
        {
            TaskListSearch = taskListSearch;
            await GetTasks();
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
                await GetTasks();
            }
        }
        public void OpenAssignPopup(Guid id)
        {
            AssignTaskDialog.Show(id);
        }
        public async void AssignTaskSuccess(bool result)
        {
            if (result)
            {
                await GetTasks();
            }
        }
        private async Task GetTasks()
        {
            try
            {
                var pagingResponse = await TaskApiClient.GetTaskList(TaskListSearch);
                Tasks = pagingResponse.Items;
                MetaData = pagingResponse.MetaData;
            }
            catch (Exception ex)
            {
                Error.ProcessError(ex);
            }
        }
        private async Task SelectedPage(int page)
        {
            TaskListSearch.PageNumber = page;
            await GetTasks();
        }
    }

}
