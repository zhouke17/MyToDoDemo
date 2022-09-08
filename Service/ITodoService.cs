using MyToDoDemo.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoDemo.Service
{
    public interface ITodoService : IBaseService<ToDoDto>
    {
    }
}
