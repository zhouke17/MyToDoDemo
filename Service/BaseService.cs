using MyToDoDemo.Common.Parameters;
using MyToToDemo;
using System.Threading.Tasks;

namespace MyToDoDemo.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly HttpClient httpClient;
        private readonly string contorlName;

        public BaseService(HttpClient httpClient, string contorlName)
        {
            this.httpClient = httpClient;
            this.contorlName = contorlName;
        }
        public async Task<Response<TEntity>> AddAsync(TEntity entity)
        {
            RequestParams request = new RequestParams();
            request.Method = RestSharp.Method.POST;
            request.Param = entity;
            request.Route = $"api/{contorlName}/Add";
            return await httpClient.ExectAsync<TEntity>(request);
        }

        public async Task<Response> DeleteAsyc(int id)
        {
            RequestParams request = new RequestParams();
            request.Method = RestSharp.Method.DELETE;
            request.Route = $"api/{contorlName}/Delete?id={id}";
            return await httpClient.ExectAsync(request);
        }

        public async Task<Response<PagedList<TEntity>>> GetAllAsync(QueryParameter param)
        {
            RequestParams request = new RequestParams();
            request.Method = RestSharp.Method.GET;
            request.Route = $"api/{contorlName}/GetAll?pageIndex={param.PageIndex}&pageSize={param.PageSize}&search={param.Search}";
            return await httpClient.ExectAsync<PagedList<TEntity>>(request);
        }

        public async Task<Response<TEntity>> GetFirstOrDefaultAsync(int id)
        {
            RequestParams request = new RequestParams();
            request.Method = RestSharp.Method.GET;
            request.Route = $"api/{contorlName}/Get?id={id}";
            return await httpClient.ExectAsync<TEntity>(request);
        }


        public async Task<Response<TEntity>> UpdateAsync(TEntity entity)
        {
            RequestParams request = new RequestParams();
            request.Method = RestSharp.Method.POST;
            request.Param = entity;
            request.Route = $"api/{contorlName}/Update";
            return await httpClient.ExectAsync<TEntity>(request);
        }
    }
}
