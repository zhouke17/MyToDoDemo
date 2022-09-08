using MyToDoDemo.Common.Parameters;
using System.Threading.Tasks;

namespace MyToToDemo.Api.Services
{
    public interface IBaseService<T>
    {
        Task<ApiResponse> GetSingleAsync(int id);

        Task<ApiResponse> GetAllAsync(QueryParameter queryParameter);
        Task<ApiResponse> UpdateAsync(T model);
        Task<ApiResponse> DeleteAsync(int id);
        Task<ApiResponse> AddAsync(T model);
    }
}
