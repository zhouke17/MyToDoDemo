using MyToDoDemo.Common.Dtos;
using MyToDoDemo.Common.Parameters;
using MyToToDemo;
using MyToToDemo.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoDemo.Service
{
    public interface ITodoService : IBaseService<ToDoDto>
    {
        Task<Response<PagedList<ToDoDto>>> GetAllFilterAsync(ToDoParameter parameter);
    }
}
