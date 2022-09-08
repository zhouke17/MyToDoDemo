using Microsoft.AspNetCore.Mvc;
using MyToDoDemo.Common.Dtos;
using MyToDoDemo.Common.Parameters;
using MyToToDemo.Api.Services;
using System.Threading.Tasks;

namespace MyToToDemo.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MemoController : ControllerBase
    {
        private readonly IMemoService memoService;

        public MemoController(IMemoService memoService)
        {
            this.memoService = memoService;
        }

        [HttpGet]
        public async Task<ApiResponse> Get(int id) => await memoService.GetSingleAsync(id);

        [HttpGet]
        public async Task<ApiResponse> GetAll([FromQuery]QueryParameter queryParameter) => await memoService.GetAllAsync(queryParameter);

        [HttpPost]
        public async Task<ApiResponse> Add(MemoDto memo) => await memoService.AddAsync(memo);

        [HttpDelete]
        public async Task<ApiResponse> Delete(int id) => await memoService.DeleteAsync(id);

        [HttpPost]
        public async Task<ApiResponse> Update(MemoDto memo) => await memoService.UpdateAsync(memo);

    }

}

