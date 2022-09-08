using Microsoft.EntityFrameworkCore;
using MyToToDemo.Api.Context.UnitOfWork;
using MyToToDemo.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToToDemo.Api.Context.Repository
{
    public class MemoRepository : Repository<Memo>, IRepository<Memo>
    {
        public MemoRepository(MyDbContext dbContext) : base(dbContext)
        {
        }
    }
}
