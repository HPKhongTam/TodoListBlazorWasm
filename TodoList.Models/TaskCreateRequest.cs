using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Models.Enums;

namespace TodoList.Models
{
    public class TaskCreateRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(250,ErrorMessage ="Bạn không thể nhập quá 250 kí tự!")]
        [Required(ErrorMessage ="Xin vui lòng nhập tên!")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Vui lòng chọn Priority!")]
        public Priority? Priority { get; set; }

    }
}
