using MyToDoDemo.Common.Dtos;
using System.Threading.Tasks;

namespace MyToToDemo.Api.Services
{
    public interface IUserService
    {
        Task<ApiResponse> LoginAsync(string account,string passWord);
        Task<ApiResponse> Register(UserDto userDto);
    }
}
