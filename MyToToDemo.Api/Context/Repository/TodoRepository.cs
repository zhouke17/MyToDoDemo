using Microsoft.EntityFrameworkCore;
using MyToDoDemo.Common.Dtos;
using MyToToDemo.Api.Context.UnitOfWork;
using MyToToDemo.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToToDemo.Api.Context.Repository
{
    public class TodoRepository : Repository<ToDo>, IRepository<ToDo>
    {
        public TodoRepository(MyDbContext dbContext) : base(dbContext)
        {
        }
    }
}
