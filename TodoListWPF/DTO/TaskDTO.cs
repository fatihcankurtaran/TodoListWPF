using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListWPF.DTO
{
    public class TaskDTO : BaseDTO
    {
        public int Id { get; set; }
        public string Deadline { get; set; }
        public bool IsCompleted { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TaskListId { get; set; }
        
    }
}
