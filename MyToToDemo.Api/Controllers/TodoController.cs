using Microsoft.AspNetCore.Mvc;
using MyToDoDemo.Common.Dtos;
using MyToDoDemo.Common.Parameters;
using MyToToDemo.Api.Services;
using System.Threading.Tasks;

namespace MyToToDemo.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService todoService;

        public TodoController(ITodoService todoService)
        {
            this.todoService = todoService;
        }

        [HttpGet]
        public async Task<ApiResponse> Get(int id) => await todoService.GetSingleAsync(id);

        [HttpGet]
        public async Task<ApiResponse> GetAll([FromQuery] ToDoParameter queryParameter) => await todoService.GetAllAsync(queryParameter);

        [HttpPost]
        public async Task<ApiResponse> Add([FromBody] ToDoDto toDo) => await todoService.AddAsync(toDo);

        [HttpDelete]
        public async Task<ApiResponse> Delete(int id) => await todoService.DeleteAsync(id);

        [HttpPost]
        public async Task<ApiResponse> Update([FromBody] ToDoDto toDo) => await todoService.UpdateAsync(toDo);

    }

}

