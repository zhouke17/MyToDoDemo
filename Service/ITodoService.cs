using MyToDoDemo.Common.Dtos;
using MyToDoDemo.Common.Parameters;
using MyToToDemo;
using System.Threading.Tasks;

namespace MyToDoDemo.Service
{
    public interface ITodoService : IBaseService<ToDoDto>
    {
        Task<Response<PagedList<ToDoDto>>> GetAllFilterAsync(ToDoParameter parameter);
        Task<Response<SummaryDto>> GetSummaryAsync();
    }
}
