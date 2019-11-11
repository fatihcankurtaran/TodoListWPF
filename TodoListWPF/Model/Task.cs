using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListWPF.Model
{
    public class Task : Base
    {
        public int Id { get; set;  }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TaskListId { get; set; }
        [ForeignKey("TaskListId")]
        public TaskList TaskList { get; set; }
    }
}
