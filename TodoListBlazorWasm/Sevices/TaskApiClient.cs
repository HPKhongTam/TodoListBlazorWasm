using System.Net.Http.Json;
using TodoList.Models;

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
            return result!=null?result:new TaskDto();
        }

        public async Task<List<TaskDto>> GetTaskList(TaskListSearch taskListSearch)
        {
            string url = $"/api/tasks?name={taskListSearch.Name}&assigneeId={taskListSearch.AssigneeId}&priority={taskListSearch.Priority}";
            var result = await _httpClient.GetFromJsonAsync<List<TaskDto>>(url);
            return result!=null?result:new List<TaskDto>();
        }

        public async Task<bool> UpdateTask(Guid Id, TaskUpdateRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/tasks/{Id}", request);
            return result.IsSuccessStatusCode;
        }

    }
}
