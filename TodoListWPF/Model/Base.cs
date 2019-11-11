using System;

namespace TodoListWPF.Model
{
    public class Base
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public int? CreatedUserId { get; set; }
        public int? ModifiedUserId { get; set; }


        public bool IsDeleted { get; set; } = false;

    }
}
