using MyToDoDemo.Common.Dtos;
using MyToToDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoDemo.Service
{
    public  interface ILoginService
    {
        Task<Response> Login(UserDto user);
        Task<Response> Register(UserDto user);
    }
}
