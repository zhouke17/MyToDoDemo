using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToToDemo.Api.Entities
{
    public class Memo: BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
