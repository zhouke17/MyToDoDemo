using MyToDoDemo.Common.Dtos;

namespace MyToDoDemo.Service
{
    public class TodoService : BaseService<ToDoDto>, ITodoService
    {
        public TodoService(HttpClient httpClient, string contorlName) : base(httpClient, "Todo")
        {
        }
    }
}
