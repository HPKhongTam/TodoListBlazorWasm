using TodoList.Models;

namespace TodoListBlazorWasm.Sevices
{
   public interface  IAuthService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task Logout();
    }
}
