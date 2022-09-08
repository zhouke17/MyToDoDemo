using MyToDoDemo.Common.Parameters;
using MyToToDemo;
using System.Threading.Tasks;

namespace MyToDoDemo.Service
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<Response<TEntity>> AddAsync(TEntity entity);
        Task<Response> DeleteAsyc(int id);
        Task<Response<TEntity>> UpdateAsync(TEntity entity);
        Task<Response<TEntity>> GetFirstOrDefaultAsync(int id);
        Task<Response<PagedList<TEntity>>> GetAllAsync(QueryParameter param);
    }
}
