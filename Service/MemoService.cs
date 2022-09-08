using MyToDoDemo.Common.Dtos;

namespace MyToDoDemo.Service
{
    public class MemoService : BaseService<MemoDto>, IMemoService
    {
        public MemoService(HttpClient httpClient, string contorlName) : base(httpClient, "Memo")
        {
        }
    }
}
