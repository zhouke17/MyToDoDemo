using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoDemo.Common.Parameters
{
    public class ToDoParameter : QueryParameter
    {
        public int? Status { get; set; }
    }
}
