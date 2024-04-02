using Microsoft.AspNetCore.Identity;

namespace TodoList.Api.Entitier
{
    public class Role:IdentityRole<Guid>
    {
        public string Descriptions { get; set; }
    }
}
