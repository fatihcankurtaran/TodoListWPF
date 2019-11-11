using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListWPF.DTO
{
   public class BaseDTO
    {
        public string CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }


        public bool IsDeleted { get; set; } = false;
    }
}
