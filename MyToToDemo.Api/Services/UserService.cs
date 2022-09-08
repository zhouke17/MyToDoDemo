using AutoMapper;
using MyToDoDemo.Api;
using MyToDoDemo.Common.Dtos;
using MyToToDemo.Api.Context.UnitOfWork;
using MyToToDemo.Api.Entities;
using System;
using System.Threading.Tasks;

namespace MyToToDemo.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IMapper mapper,IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse> LoginAsync(string account, string passWord)
        {
            try
            {
                var pwd = passWord.GetMD5();
                var repository = unitOfWork.GetRepository<User>();
                var user = await repository.GetFirstOrDefaultAsync(predicate: s => s.Account.Equals(account) && s.PassWord.Equals(pwd));
                if (user == null)
                {
                    return new ApiResponse(false, "账号或密码错误，请重试！");
                }
                return new ApiResponse(true, "登录成功！");
            }
            catch (Exception ex)
            {
                return new ApiResponse(false,$"登录失败！{ex}");
            }
            
        }

        public async Task<ApiResponse> Register(UserDto userDto)
        {
            try
            {
                var model = mapper.Map<User>(userDto);
                var repository = unitOfWork.GetRepository<User>();
                var user = await repository.GetFirstOrDefaultAsync(predicate: s => s.Account.Equals(model.Account));
                if (user != null)
                {
                    return new ApiResponse(false, $"用户{userDto.Account}已存在，请重新注册！");
                }
                model.CreateTime = DateTime.Now;
                model.PassWord = userDto.PassWord.GetMD5();
                await repository.InsertAsync(model);
                if (await unitOfWork.SaveChangesAsync() > 0)
                {
                    return new ApiResponse(true,"注册成功");
                }
                return new ApiResponse(false,"注册失败，请重试！");
            }
            catch (Exception ex)
            {
                return new ApiResponse(false, $"注册失败：{ex}，请重试！");
            }
        }

    }
}
