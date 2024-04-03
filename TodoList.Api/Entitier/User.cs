using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Api.Entitier
{
    public class User:IdentityUser<Guid>
    {
        [MaxLength(1000)]
        public string FirstName { get; set; }
        [MaxLength(1000)]
        public string LastName { get; set; }
    }
}
