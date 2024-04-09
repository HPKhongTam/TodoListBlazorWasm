using TodoList.Api.Entitier;
using TodoList.Models;

namespace TodoList.Api.Repositories
{
    public interface IUserRepository
    {
       Task<List<User>> GetUserList();
    }
}
