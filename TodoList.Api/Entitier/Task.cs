using System.ComponentModel.DataAnnotations;
using TodoList.Api.Enums;

namespace TodoList.Api.Entitier
{
    public class Task
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? Assignee { get; set; }
        public DateTime CreatedDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }     
    }
}
