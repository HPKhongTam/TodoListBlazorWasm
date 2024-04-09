using System.Globalization;
using System.Net.Http.Json;
using TodoList.Models;

namespace TodoListBlazorWasm.Sevices
{
    public class UserApiClient : IUserApiClient
    {
        public HttpClient _httpClient;
        public UserApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<AssigneeDto>> GetAssignees()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssigneeDto>>($"/api/users");
            return result != null ? result : new List<AssigneeDto>();
        }
    }
}
