using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToToDemo.Api.Services
{
    public class ApiResponse
    {
        public ApiResponse(bool status,string message)
        {
            this.Status = status;
            this.Message = message;
        }
        public ApiResponse(bool status,object data)
        {
            this.Status = status;
            this.Data = data;
        }
        public bool Status { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
