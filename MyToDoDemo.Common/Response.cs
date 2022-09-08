using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToToDemo
{
    public class Response
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }

    public class Response<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public T Data { get; set; }
    }
}
