using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDoDemo.Service
{
    public class RequestParams
    {
        public string Route { get; set; }

        public object Param { get; set; }
        public Method Method { get; set; }
        public string ContentType { get; set; } = "application/json";
    }
}
