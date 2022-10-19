using MyToDoDemo.Common.Dtos;
using MyToDoDemo.Common.Parameters;
using MyToToDemo;
using System.Threading.Tasks;

namespace MyToDoDemo.Service
{
    public class TodoService : BaseService<ToDoDto>, ITodoService
    {
        private readonly HttpClient httpClient;

        public TodoService(HttpClient httpClient) : base(httpClient, "Todo")
        {
            this.httpClient = httpClient;
        }

        public async Task<Response<PagedList<ToDoDto>>> GetAllFilterAsync(ToDoParameter parameter)
        {
            RequestParams request = new RequestParams();
            request.Method = RestSharp.Method.GET;
            request.Param = parameter;
            request.Route = $"api/Todo/GetAll?pageIndex={parameter.PageIndex}" +
                $"&pageSize={parameter.PageSize}" +
                $"&search={parameter.Search}" + 
                $"&status={parameter.Status}";
            return await httpClient.ExectAsync<PagedList<ToDoDto>>(request);
        }
    }
}
