using Microsoft.AspNetCore.Identity;
using TodoList.Api.Entitier;
using Task = System.Threading.Tasks.Task;

namespace TodoList.Api.Data
{
    public class TodoListDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        public async Task SeedAsync(TodoListDbContext context, ILogger<TodoListDbContextSeed> logger)
        {

            if (!context.Tasks.Any())
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mr",
                    LastName = "Abc",
                    Email = "admin@gmail.com",
                    PhoneNumber = "1234567890",
                    UserName = "admin",
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = false,
                    AccessFailedCount = 0,
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Admin@123$");
                context.Users.Add(user);
            }
            if (!context.Tasks.Any())
            {
                context.Tasks.Add(new Entitier.Task()
                {
                    Id = Guid.NewGuid(),
                    Name = "Same task 1",
                    CreatedDate = DateTime.Now,
                    Priority = Enums.Priority.High,
                    Status = Enums.Status.Open,
                    AssigneeId = Guid.NewGuid(),
                    Assignee = new User() { }

                });
            }
            await context.SaveChangesAsync();



        }
    }
}
