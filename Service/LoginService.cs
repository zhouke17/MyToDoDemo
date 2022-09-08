using MyToDoDemo.Common.Dtos;
using MyToToDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoDemo.Service
{
    public class LoginService : ILoginService
    {
        private readonly string apiName = "User";
        private readonly HttpClient httpClient;

        public LoginService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<Response> Login(UserDto user)
        {
            RequestParams request = new RequestParams();
            request.Method = RestSharp.Method.POST;
            request.Param = user;
            request.Route = $"api/{apiName}/Login";
            return await httpClient.ExectAsync(request);
        }

        public async Task<Response> Register(UserDto user)
        {
            RequestParams request = new RequestParams();
            request.Method = RestSharp.Method.POST;
            request.Param = user;
            request.Route = $"api/{apiName}/Register";
            return await httpClient.ExectAsync(request);
        }
    }
}
