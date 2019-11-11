using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListWPF.Model
{
    public class TaskList : Base
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
