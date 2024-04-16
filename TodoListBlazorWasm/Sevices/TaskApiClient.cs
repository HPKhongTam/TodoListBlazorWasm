using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;
using TodoList.Models;
using TodoList.Models.SeedWork;

namespace TodoListBlazorWasm.Sevices
{
    public class TaskApiClient : ITaskApiClient
    {
        public HttpClient _httpClient;
        public TaskApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AssignTask(Guid id, AssignTaskRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/tasks/{id}/assign", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> CreateTask(TaskCreateRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/tasks", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTask(Guid Id)
        {
            var result = await _httpClient.DeleteAsync($"/api/tasks/{Id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<TaskDto> GetTaskDetail(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<TaskDto>($"/api/tasks/{id}");
            return result != null ? result : new TaskDto();
        }

        public async Task<PageList<TaskDto>> GetTaskList(TaskListSearch taskListSearch)
        {
            //string url = $"/api/tasks?name={taskListSearch.Name}" +
            //    $"&assigneeId={taskListSearch.AssigneeId}" +
            //    $"&priority={taskListSearch.Priority}";
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageNumber"] = taskListSearch.PageNumber.ToString()
            };
            if (!string.IsNullOrEmpty(taskListSearch.Name))
                queryStringParam.Add("name", taskListSearch.Name);
            if (taskListSearch.AssigneeId.HasValue)
                queryStringParam.Add("assigneeId", taskListSearch.AssigneeId.ToString());
            if (taskListSearch.Priority.HasValue)
                queryStringParam.Add("priority", taskListSearch.Priority.ToString());
            string url = QueryHelpers.AddQueryString("/api/tasks", queryStringParam);
            var result = await _httpClient.GetFromJsonAsync<PageList<TaskDto>>(url);
            return result != null ? result : new PageList<TaskDto>();
        }

        public async Task<bool> UpdateTask(Guid Id, TaskUpdateRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/tasks/{Id}", request);
            return result.IsSuccessStatusCode;
        }

    }
}
