using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoList.Api.Entitier;
namespace TodoList.Api.Data
{
    public class TodoListDbContext:IdentityDbContext<User,Role,Guid>
    {
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options):base(options) 
        { 
        
        }
        public DbSet<Entitier.Task> Tasks { get; set; }
    }
}
