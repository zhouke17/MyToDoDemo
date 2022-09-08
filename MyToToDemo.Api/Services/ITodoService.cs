using MyToDoDemo.Common.Dtos;
using MyToDoDemo.Common.Parameters;
using System.Threading.Tasks;

namespace MyToToDemo.Api.Services
{
    public interface ITodoService : IBaseService<ToDoDto>
    {
        Task<ApiResponse> GetAllAsync(ToDoParameter queryParameter);
    }
}
